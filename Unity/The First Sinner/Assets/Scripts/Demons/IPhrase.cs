using System;
using System.Collections.Generic;
using UnityEngine;

namespace Demons
{
    public interface IPhrase
    {
        string Content { get; }
        List<IDemonParsed> SinsRelated { get; }
        
    }
}