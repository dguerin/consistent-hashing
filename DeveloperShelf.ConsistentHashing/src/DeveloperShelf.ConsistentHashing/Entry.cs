namespace DeveloperShelf.ConsistentHashing
{
    public class Entry
    {
        public Entry(string key, int hash)
        {
            Key = key;
            Hash = hash;
        }


        public string Key { get; }

        public int Hash { get; }

    }
}