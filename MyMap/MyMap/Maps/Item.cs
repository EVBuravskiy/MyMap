namespace MyMap.Maps
{
    public class Item<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Item(TKey key, TValue value)
        {
            if (key == null && value == null) throw new ArgumentNullException("Key or value is null", nameof(value));
            Key = key;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
