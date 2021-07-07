using System.Collections.Generic;

namespace DeveloperShelf.ConsistentHashing
{
    public class Node
    {
        public Node(string name)
        {
            name.CheckIsNullEmptyOrWhitespace();

            var hasher = new Sha256Hash();
            Id = hasher.ComputeHash(name);
            Name = name;

            Entries = new List<Entry>(100);
        }

        /// <summary>
        /// The current id of the node in the Hash Ring
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The key used to seed this node
        /// </summary>
        public string Name { get; }

        public List<Entry> Entries { get; }

        public void Add(Entry entry)
        {
            Entries.Add(entry);
        }
    }
}