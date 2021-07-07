namespace DeveloperShelf.ConsistentHashing
{
    public interface IConsistentHasher
    {
        /// <summary>
        /// Adds a new node to the existing cluster. Causes the cluster to rebalanced when a node is added.
        /// </summary>
        /// <param name="name"></param>
        void AddNode(string name);

        /// <summary>
        /// Removes an existing node from the cluster. Causes the cluster to rebalance when a node is removed
        /// </summary>
        /// <param name="value"></param>
        void RemoveNode(string value);

        /// <summary>
        /// Associates a piece of content to a particular existing node
        /// </summary>
        /// <param name="key"></param>
        void Insert(string key);

        /// <summary>
        /// Removes a piece of content from a particular existing node.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// Searches the tree to get the node which is allocated the content key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Node Search(string key);

        /// <summary>
        /// Searches the tree to get the node which is allocated the content hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        Node Search(int hash);
    }
}