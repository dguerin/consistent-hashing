using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperShelf.ConsistentHashing
{
    public class ConsistentHash : IConsistentHasher
    {
        private readonly IHash _hash;

        public ConsistentHash(IHash hash)
        {
            _hash = hash;
            Nodes = new Dictionary<int, Node>();
        }

        public Dictionary<int, Node> Nodes { get; private set; }

        public void AddNode(string name)
        {
            name.CheckIsNullEmptyOrWhitespace();

            var hash = _hash.ComputeHash(name);

            if (Nodes.ContainsKey(hash))
            {
                throw new ArgumentException("Node with specified name already exists");
            }

            Nodes.Add(hash, new Node(name));
            //Rebalance();
        }

        public void RemoveNode(string value)
        {
            Rebalance();
            Nodes.Remove(_hash.ComputeHash(value));
        }

        public void Insert(string key)
        {
            var hash = _hash.ComputeHash(key);

            var node = Search(hash);

            node.Add(new Entry(key, hash));
        }

        public void Remove(string key)
        {
            key.CheckIsNullEmptyOrWhitespace();

            var hash = _hash.ComputeHash(key);

            if (!Nodes.ContainsKey(hash))
            {
                throw new ArgumentException("Node does not exist to remove");
            }

            Rebalance();
            Nodes.Remove(hash);
        }

        private void Rebalance()
        {
            throw new NotImplementedException("Need to implement cluster rebalancer logic");
        }

        public Node Search(string key)
        {
            return Search(_hash.ComputeHash(key));
        }

        public Node Search(int hash)
        {
            var hit = Nodes.ContainsKey(hash);
            if (hit)
            {
                return Nodes[hash];
            }

            var keys = Nodes.Keys.ToList();
            for (var i = 0; i < Nodes.Count; i++)
            {
                if (hash < Nodes[keys[i]].Id)
                {
                    return Nodes[keys[i]];
                }
            }

            return Nodes[Nodes.Count];
        }
    }
}