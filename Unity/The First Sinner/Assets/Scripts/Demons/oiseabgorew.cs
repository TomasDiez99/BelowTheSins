using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Patterns;
using UnityEngine;

namespace Demons
{
    
    /// <summary>
    /// Contents all demons (Statically)
    /// </summary>
    public class DemonManager : ScriptSingleton<DemonManager>
    {
        public IDemon Gula { get; } = new PlaceHolderDemon();
        public IDemon Envidia { get; } = new PlaceHolderDemon();
        public IDemon Lujuria { get; } = new PlaceHolderDemon();
        public IDemon Soberbia { get; } = new PlaceHolderDemon();
        public IDemon Ira { get; } = new PlaceHolderDemon();
        public IDemon Pereza { get; } = new PlaceHolderDemon();
        public IDemon Codicia { get; } = new PlaceHolderDemon();
        
        public List<IDemon> EveryDemon { get; } = new List<IDemon>();
            
        public override void Constructor()
        {
            EveryDemon.Add(Gula);
            EveryDemon.Add(Envidia);
            EveryDemon.Add(Lujuria);
            EveryDemon.Add(Soberbia);
            EveryDemon.Add(Ira);
            EveryDemon.Add(Pereza);
            EveryDemon.Add(Codicia);
        }

       
        
        public IDemon Random()
        {
            return EveryDemon.ToArray().Rand();
        }
    }
}