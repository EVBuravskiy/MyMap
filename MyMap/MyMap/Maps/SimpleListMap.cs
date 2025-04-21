using System.Collections;

namespace MyMap.Maps
{
    public class SimpleListMap<TKey, TValue> : IEnumerable
    {
        private List<Item<TKey, TValue>> Items;

        private List<TKey> Keys;

        public int Count { get { return Items.Count; } }

        public SimpleListMap()
        {
            Items = new List<Item<TKey, TValue>>();
            Keys = new List<TKey>();
        }

        public void Add(Item<TKey, TValue> item)
        {
            if (!Keys.Contains(item.Key))
            {
                Items.Add(item);
                Keys.Add(item.Key);
            }
        }

        public TValue Get(TKey key)
        {
            if (Keys.Contains(key))
            {
                return Items.SingleOrDefault(x => x.Key.Equals(key)).Value;
            }
            return default(TValue);
            //throw new NullReferenceException("Value is null");
        }

        public void Remove(TKey key)
        {
            if (Keys.Contains(key))
            {
                Items.Remove(Items.SingleOrDefault(x => x.Key.Equals(key)));
                Keys.Remove(key);
                return;
            }
            throw new NullReferenceException("Value is null");
        }

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }

    }
}
