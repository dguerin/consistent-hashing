using System.Linq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DeveloperShelf.ConsistentHashing.Tests
{
    public class ConsistentHashTests
    {
        private readonly ConsistentHash _consistentHash;
        private readonly Sha256Hash _hasher = new Sha256Hash();

        public ConsistentHashTests()
        {
            _consistentHash = new ConsistentHash(_hasher);
            _consistentHash.AddNode("node1");
            _consistentHash.AddNode("node2");
        }

        [Theory]
        [InlineData("Key", 736194604)]
        public void CheckHash(string value, int expectedHash)
        {
            _consistentHash.Insert(value);
            var hash = _hasher.ComputeHash(value);

            var node = _consistentHash.Search(hash);

            Assert.NotEqual(default, node.Id);
            Assert.Equal(expectedHash, node.Id);
        }

        [Theory]
        [InlineData("Key", 2)]
        [InlineData("Donkey", 4)]
        [InlineData("http://service.com", 0)]
        [InlineData("http://service.com/api/v2/entity", 4)]
        public void CheckNodeHashAllocation(string value, int expectedNodeIndex)
        {
            _consistentHash.Insert(value);

            var key = _consistentHash.Nodes.Keys.ToList();
            Assert.NotEmpty(_consistentHash.Nodes[key[expectedNodeIndex]].Entries);
        }
    }
}