using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolSet : IBoolCollection
{
    public int Count => Trues + Falses;
    public int Falses { get;  protected set; }
    public int Trues { get; protected set; }
    public float AssertionFactor => ((float)Trues) / Count;

    public BoolSet()
    {
        Trues = Falses = 0;
    }

    public bool Add(bool item)
    {
        if (item)
        {
            Trues++;
        }
        else
        {
            Falses++;
        }
        return item;
    }

    public void Clear()
    {
        Trues = 0;
        Falses = 0;
    }

    public IEnumerator<bool> GetEnumerator()
    {
        for(int i=0; i<Falses; i++)
            yield return false;
        for (int i=0; i<Trues; i++)
            yield return true;
    }

    public bool Remove(bool item)
    {
        int C = Count;
        if (item)
        {
            Trues--;
        }
        else
        {
            Falses--;
        }
        if (C == Count)
        {
            throw new BoolCollectionException("There is not a "+item+ "in the structure");
        }
        return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
