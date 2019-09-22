using Xunit;

namespace ConsistentHashing.Tests
{
    public class HasherTests
    {
        [Theory]
        [InlineData("dog")]
        [InlineData("http://dog.com")]
        [InlineData("jlasjdlfkjalsjdflaskjd")]
        [InlineData("")]
        public void IsNotEmpty(string key)
        {
            var hasher = new Hasher();
            var value = hasher.ComputeHash(key);
            Assert.NotEqual(default, value);
        }
    }

    public class NodeTests
    {
        [Theory]
        [InlineData("Bob", 667437439)]
        [InlineData("http://service.com", 166124589)]
        public void EnsureDeterministicNodeId(string key, int expectedId)
        {
            var node = new Node(key);

            Assert.NotNull(node.Key);
            Assert.Equal(expectedId, node.Id);
        }
    }

    public class StringExtensionTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("donkey", true)]
        [InlineData(null, false)]
        [InlineData("Hello World", false)]
        public void Evaluate(string value, bool expectation)
        {

        }
    }
}
