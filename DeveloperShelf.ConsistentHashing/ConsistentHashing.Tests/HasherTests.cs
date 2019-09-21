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
        public void HasNotNull(string key)
        {
            var hasher = new Hasher();
            var value = hasher.ComputeHash(key);
            Assert.NotNull(value);
        }

        [Theory]
        [InlineData("dog")]
        [InlineData("http://dog.com")]
        [InlineData("jlasjdlfkjalsjdflaskjd")]
        [InlineData("")]
        public void HasNotEmpty(string key)
        {
            var hasher = new Hasher();
            var value = hasher.ComputeHash(key);
            Assert.NotEmpty(value);
        }
    }
}
