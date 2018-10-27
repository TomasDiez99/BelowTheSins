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
        public IDemon Gula { get; } = new PlaceHolderDemon("Gula");
        public IDemon Envidia { get; } = new PlaceHolderDemon("Envidia");
        public IDemon Lujuria { get; } = new PlaceHolderDemon("Lujuria");
        public IDemon Soberbia { get; } = new PlaceHolderDemon("Soberbia");
        public IDemon Ira { get; } = new PlaceHolderDemon("Ira");
        public IDemon Pereza { get; } = new PlaceHolderDemon("Pereza");
        public IDemon Codicia { get; } = new PlaceHolderDemon("Codicia");
        
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

        public IDemon GetDemon(string name)
        {
            return EveryDemon.First(e => e.Sin==name);
        }
        
        public IDemon Random()
        {
            return EveryDemon.ToArray().Rand();
        }
    
    
    
    
    
    }
}