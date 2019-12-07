namespace DeveloperShelf.ConsistentHashing
{
    public interface IConsistentHashing
    {
        void Setup(int nodeCount);

        void Setup(string[] nodeNames);

        void AddNode(string key);

        void RemoveNode(string key);

        int ComputeHash(string key);
    }
}