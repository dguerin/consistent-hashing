using System.Collections.Generic;

namespace ConsistentHashing
{
    public class Node
    {
        public Node(string key)
        {
            key.CheckIsNullEmptyOrWhitespace();

            var hasher = new Hasher();
            Id = hasher.ComputeHash(key);
            Key = key;

            Entries = new List<Entry>(100);
        }

        /// <summary>
        /// The current id of the node in the Hash Ring
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The key used to seed this node
        /// </summary>
        public string Key { get; }

        public List<Entry> Entries { get; }

        public void Add(Entry entry)
        {
            Entries.Add(entry);
        }

        public void Remove(Entry entry)
        {
            Entries.Remove(entry);
        }
    }
}