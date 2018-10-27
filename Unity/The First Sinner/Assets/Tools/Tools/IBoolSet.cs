using System.Collections.Generic;

public interface IBoolCollection : IEnumerable<bool>
{
    
    int Count { get; }

    bool Add(bool item);

    void Clear();    
        
    bool Remove(bool item);        

    int Falses { get; }

    int Trues { get; }

    /// <summary>
    /// returns a number between 0 and 1 that represents the number of true ones over the total
    /// </summary>
    float AssertionFactor { get; }

}