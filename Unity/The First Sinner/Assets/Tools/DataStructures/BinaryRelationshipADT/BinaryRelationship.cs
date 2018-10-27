using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class BinaryRelationship<K,V> : Dictionary<K,HashSet<V>>{


    public int size;

    public new int Count => size;

    public new V this[K key]
    {
        get
        {
            V ret = default(V);
            if (ContainsKey(key))
            {
                ret = base[key].First();
            }
            else
            {
                throw new KeyNotFoundException("The key was not founded");
            }
            return ret;
        }
        set
        {
            if (!ContainsKey(key))
            {
               base[key] = new HashSet<V>();
            }
            base[key].Add(value);
            size++;
        }
    }

    public bool Remove(K key, V value)
    {
        bool x = false;
        if (!ContainsKey(key))
        {
            HashSet<V> s = base[key];
            if (s.Contains(value))
            {
                s.Remove(value);
                size--;               
            }
            if(s.Count < 1)
            {
                base.Remove(key);
            }
        }
        return x;
    }

    public V RemoveOne(K key)
    {
        V x = default(V);
        if (ContainsKey(key))
        {
            HashSet<V> s = base[key];
            x = s.Last();
            s.Remove(x);
            size--;
            if (s.Count < 1)
            {
                base.Remove(key);
            }
        }
        return x;
    }
        

}
