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
        public static HalosBars Halos => HalosBars.Instance;
        public IDemonParsed Gula { get; } = new LogicalDemonParsed("Gula", Halos.HaloGluttony);
        public IDemonParsed Envidia { get; } = new LogicalDemonParsed("Envidia", Halos.HaloEnvy);
        public IDemonParsed Lujuria { get; } = new LogicalDemonParsed("Lujuria", Halos.HaloLust);
        public IDemonParsed Soberbia { get; } = new LogicalDemonParsed("Soberbia", Halos.HaloPride);
        public IDemonParsed Ira { get; } = new LogicalDemonParsed("Ira", Halos.HaloPride);
        public IDemonParsed Pereza { get; } = new LogicalDemonParsed("Pereza", Halos.HaloSloth);
        public IDemonParsed Codicia { get; } = new LogicalDemonParsed("Codicia", Halos.HaloGreed);

        public List<IDemonParsed> EveryDemon { get; } = new List<IDemonParsed>();

        public override void Constructor()
        {
            EveryDemon.Add(Gula);
            Gula.Health = 30;
            EveryDemon.Add(Envidia);
            EveryDemon.Add(Lujuria);
            EveryDemon.Add(Soberbia);
            EveryDemon.Add(Ira);
            EveryDemon.Add(Pereza);
            EveryDemon.Add(Codicia);
        }

        public string[] DemonNames =
        {
            "Ira", "Soberbia", "Pereza", "Lujuria","Envidia", "Codicia","Gula"
        };

        public IDemonParsed GetDemon(string name)
        {
            return EveryDemon.First(e => e.Sin == name);
        }

        public IDemonParsed GetDemon(int i)
        {
            return GetDemon(DemonNames.[0]);
        }

        public IDemonParsed Random()
        {
            return EveryDemon.ToArray().Rand();
        }
    }
}