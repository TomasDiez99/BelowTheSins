using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NullAutocheck{

	public static implicit operator bool (NullAutocheck n)
    {
        return n != null;
    }

}
