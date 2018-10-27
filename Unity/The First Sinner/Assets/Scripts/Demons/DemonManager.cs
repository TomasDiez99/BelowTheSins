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
        public IDemonParsed Gula { get; } = new LogicalDemonParsed("Gula");
        public IDemonParsed Envidia { get; } = new LogicalDemonParsed("Envidia");
        public IDemonParsed Lujuria { get; } = new LogicalDemonParsed("Lujuria");
        public IDemonParsed Soberbia { get; } = new LogicalDemonParsed("Soberbia");
        public IDemonParsed Ira { get; } = new LogicalDemonParsed("Ira");
        public IDemonParsed Pereza { get; } = new LogicalDemonParsed("Pereza");
        public IDemonParsed Codicia { get; } = new LogicalDemonParsed("Codicia");
        
        public List<IDemonParsed> EveryDemon { get; } = new List<IDemonParsed>();
            
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

        public IDemonParsed GetDemon(string name)
        {
            return EveryDemon.First(e => e.Sin==name);
        }
        
        public IDemonParsed Random()
        {
            return EveryDemon.ToArray().Rand();
        }
    
    
    
    
    
    }
}