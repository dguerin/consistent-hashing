using System.Linq;
using Xunit;

namespace ConsistentHashing.Tests
{
    public class ConsistentHashingTests
    {
        private readonly ConsistentHashing _consistentHasher;

        public ConsistentHashingTests()
        {
            var hasher = new Hasher();
            _consistentHasher = new ConsistentHashing(hasher);
        }

        [Theory]
        [InlineData("Key", 736194604)]
        public void CheckHash(string value, int expectedHash)
        {
            _consistentHasher.Setup(10);

            var result = _consistentHasher.ComputeHash(value);

            Assert.NotEqual(default, result);
            Assert.Equal(expectedHash, result);
        }

        [Theory]
        [InlineData("Key", 2)]
        [InlineData("Donkey", 4)]
        [InlineData("http://service.com", 0)]
        [InlineData("http://service.com/api/v2/entity", 4)]
        public void CheckNodeHashAllocation(string value, int expectedNodeIndex)
        {
            _consistentHasher.Setup(10);
            _consistentHasher.ComputeHash(value);

            var key = _consistentHasher.Nodes.Keys.ToList();
            Assert.NotEmpty(_consistentHasher.Nodes[key[expectedNodeIndex]].Entries);
        }
    }
}