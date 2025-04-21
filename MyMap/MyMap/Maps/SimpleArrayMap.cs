using System.Collections;

namespace MyMap.Maps
{
    public class SimpleArrayMap<TKey, TValue> : IEnumerable
    {
        private Item<TKey, TValue>[] Items;
        private int[] Keys; 
        private int Size { get; set; }

        public int Count { get; private set; }
        public SimpleArrayMap(int size = 2)
        {
            Size = size;
            Items = new Item<TKey, TValue>[Size];
            Keys = new int[Size];
            Count = 0;
        }

        public void Add(Item<TKey, TValue> item)
        {
            if (Count < Items.Length)
            {
                int hash = GetHash(item.Key);
                if (Items[hash] != null && Items[hash].Key.Equals(item.Key) && Items[hash].Value.Equals(item.Value))
                {
                    return;
                }
                if (Items[hash] == null)
                {
                    Items[hash] = item;
                    Count++;
                    Keys[hash] += 1;
                    return;
                }
                else
                {
                    for (int i = hash + 1; i < Items.Length; i++)
                    {
                        if (Items[i] == null)
                        {
                            Items[i] = item;
                            Count++;
                            Keys[hash] += 1;
                            return;
                        }
                        if (Items[i] != null && Items[i].Key.Equals(item.Key))
                        {
                            continue;
                        }
                    }
                    for (int i = 0; i < hash; i++)
                    {
                        if (Items[i] != null && Items[i].Key.Equals(item.Key))
                        {
                            continue;
                        }
                        if (Items[i] == null)
                        {
                            Items[i] = item;
                            Count++;
                            Keys[hash] += 1;
                            return;
                        }
                    }
                }
            }
            else
            {
                Size *= 2;
                Item<TKey, TValue>[] newItems = new Item<TKey, TValue>[Size];
                int[] newKeys = new int[Size];
                for (int i = 0; i < Items.Length; i++)
                {
                    int newHash = GetHash(Items[i].Key);
                    newKeys[newHash] = Keys[i];
                    if (newItems[newHash] == null)
                    {
                        newItems[newHash] = Items[i];
                    }
                    else
                    {
                        bool fl = false;
                        for (int j = newHash + 1; j < newItems.Length; j++)
                        {
                            if (newItems[j] == null)
                            {
                                newItems[j] = Items[i];
                                fl = true;
                                break;
                            }
                        }
                        if (!fl)
                        {
                            for (int j = 0; j < newHash; j++)
                            {
                                if (newItems[j] == null)
                                {
                                    newItems[j] = Items[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                Keys = newKeys;
                Items = newItems;
                Add(item);
            }

        }

        public TValue Get(TKey key)
        {
            int hash = GetHash(key);
            if (Keys[hash] == 0)
            {
                return default(TValue);
            }
            if (Items[hash] != null && Items[hash].Key.Equals(key))
            {
                return Items[hash].Value;
            }
            else
            {
                for (int i = hash; i < Items.Length; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        return Items[i].Value;
                    }
                }
                for (int i = 0; i < hash; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        return Items[i].Value;
                    }
                }
            }
            return default(TValue);
        }

        public void Remove(TKey key)
        {
            int hash = GetHash(key);
            if (Items[hash] == null && Keys[hash] == 0)
            {
                return;
            }
            if (Items[hash] != null && Items[hash].Key.Equals(key))
            {
                Items[hash] = null;
                Keys[hash] -= 1;
                Count--;
                return;
            }
            else
            {
                for (int i = hash + 1; i < Items.Length; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Count--;
                        Keys[hash] -= 1;
                        return;
                    }
                }
                for (int i = 0; i < hash; i++)
                {
                    if (Items[i] != null && Items[i].Key.Equals(key))
                    {
                        Items[i] = null;
                        Count--;
                        Keys[hash] -= 1;
                        return;
                    }
                }
            }
            return;
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % Size;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
