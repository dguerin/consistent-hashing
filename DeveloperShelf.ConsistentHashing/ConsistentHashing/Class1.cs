using System;
using System.Collections.Generic;

namespace ConsistentHashing
{
    public interface IConsistentHashing
    {
        void AddNode();

        void RemoveNode(int id);

        int ComputeHash(string key);
    }

    public class Node
    {
        private int _id;

        public Node(int id)
        {
            _id = id;
            ContainedHashes = new List<string>(100);
        }

        public List<string> ContainedHashes { get; }

        public void Add(string value)
        {
            ContainedHashes.Add(value);
        }

        public void Remove(string value)
        {
            ContainedHashes.Remove(value);
        }
    }

    public class ConsistentHashing : IConsistentHashing
    {
        private readonly IHasher _hasher;
        private List<Node> _nodes;
        private bool _hasBeenSetup;

        public ConsistentHashing(IHasher hasher)
        {
            _hasher = hasher;
        }

        public void Setup(int nodeCount)
        {
            _nodes = new List<Node>(nodeCount);
            _hasBeenSetup = true;
        }

        public void AddNode()
        {
            HasBeenConfigured();
            throw new NotImplementedException();
        }

        public void RemoveNode(int id)
        {
            HasBeenConfigured();
            throw new NotImplementedException();
        }

        public int ComputeHash(string key)
        {
            HasBeenConfigured();

            var hash = _hasher.ComputeHash(key);

            return default;
        }

        private void HasBeenConfigured()
        {
            if (!_hasBeenSetup)
            {
                throw new Exception("Consistent Hashing library has not been setup");
            }
        }
    }
}
