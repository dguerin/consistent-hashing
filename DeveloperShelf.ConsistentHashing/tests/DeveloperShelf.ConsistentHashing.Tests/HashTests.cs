using Xunit;

namespace DeveloperShelf.ConsistentHashing.Tests
{
    public class HashTests
    {
        [Theory]
        [InlineData("dog")]
        [InlineData("http://dog.com")]
        [InlineData("jlasjdlfkjalsjdflaskjd")]
        [InlineData("")]
        public void IsNotEmpty(string key)
        {
            var hasher = new Sha256Hash();
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

            Assert.NotNull(node.Name);
            Assert.Equal(expectedId, node.Id);
        }
    }

    public class StringExtensionTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("donkey")]
        [InlineData(null)]
        [InlineData("Hello World")]
        public void Evaluate(string value)
        {
            value.CheckIsNullEmptyOrWhitespace();
        }
    }
}
