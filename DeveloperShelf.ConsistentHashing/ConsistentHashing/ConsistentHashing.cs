using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsistentHashing
{
    public class ConsistentHashing : IConsistentHashing
    {
        private readonly IHasher _hasher;
        private bool _hasBeenSetup;

        public ConsistentHashing(IHasher hasher)
        {
            _hasher = hasher;
        }

        public Dictionary<int, Node> Nodes { get; private set; }

        public void Setup(int nodeCount)
        {
            Nodes = new Dictionary<int, Node>(nodeCount);

            //todo clean this up - no need for two lists
            var list = new List<Node>(nodeCount);
            for (var i = 0; i < nodeCount; i++)
            {
                var node = new Node(i.ToString());
                list.Add(node);
            }

            var list2 = list.OrderBy(t => t.Id);
            foreach (var entry in list2)
            {
                Nodes.Add(entry.Id, entry);
            }

            _hasBeenSetup = true;
        }

        public void Setup(string[] nodeNames)
        {
            Nodes = new Dictionary<int, Node>(nodeNames.Length);

            var list = new List<Node>(nodeNames.Length);
            list.AddRange(nodeNames.Select(name => new Node(name)));

            //todo clean this up - no need for two lists
            var list2 = list.OrderBy(t => t.Id);
            foreach (var entry in list2)
            {
                Nodes.Add(entry.Id, entry);
            }

            _hasBeenSetup = true;
        }

        public void AddNode(string key)
        {
            HasBeenConfigured();
            key.CheckIsNullEmptyOrWhitespace();

            //remap
            throw new NotImplementedException();
        }

        public void RemoveNode(string key)
        {
            HasBeenConfigured();
            key.CheckIsNullEmptyOrWhitespace();

            //remap
            throw new NotImplementedException();
        }

        public int ComputeHash(string key)
        {
            HasBeenConfigured();
            key.CheckIsNullEmptyOrWhitespace();

            var hash = _hasher.ComputeHash(key);

            var node = FindNode(hash);

            node.Add(new Entry(key, hash));

            return hash;
        }

        private Node FindNode(int hash)
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

        private void HasBeenConfigured()
        {
            if (!_hasBeenSetup)
            {
                throw new Exception("Consistent Hashing library has not been setup");
            }
        }
    }
}