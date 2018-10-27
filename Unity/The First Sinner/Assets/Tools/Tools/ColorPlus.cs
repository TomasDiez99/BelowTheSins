using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorPlus
{
    public static Color Alpha (this Color c, float a)
    {
        Color co = c;
        co.a = a;        
        return co;
    }	
}
