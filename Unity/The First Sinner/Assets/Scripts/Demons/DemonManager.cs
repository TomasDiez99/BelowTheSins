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
        public IDemonParsed Gula { get; set; }
        public IDemonParsed Envidia { get; set; }
        public IDemonParsed Lujuria { get; set; }
        public IDemonParsed Soberbia { get; set; }
        public IDemonParsed Ira { get; set; }
        public IDemonParsed Pereza { get; set; }
        public IDemonParsed Codicia { get; set; }

        public List<IDemonParsed> EveryDemon { get; } = new List<IDemonParsed>();

        public override void Constructor()
        {
            Gula = new LogicalDemonParsed("Gula", Halos.HaloGluttony);
            Envidia = new LogicalDemonParsed("Envidia", Halos.HaloEnvy);
            Lujuria = new LogicalDemonParsed("Lujuria", Halos.HaloLust);
            Soberbia = new LogicalDemonParsed("Soberbia", Halos.HaloPride);
            Ira = new LogicalDemonParsed("Ira", Halos.HaloWrath);
            Pereza = new LogicalDemonParsed("Pereza", Halos.HaloSloth);
            Codicia = new LogicalDemonParsed("Codicia", Halos.HaloGreed);


            EveryDemon.Add(Gula);
            EveryDemon.Add(Envidia);
            EveryDemon.Add(Lujuria);
            EveryDemon.Add(Soberbia);
            EveryDemon.Add(Ira);
            EveryDemon.Add(Pereza);
            EveryDemon.Add(Codicia);
        }

        public string[] DemonNames =
        {
            "Lujuria", "Pereza", "Envidia", "Soberbia", "Ira", "Codicia", "Gula"
        };

        public IDemonParsed GetDemon(string name)
        {
            return EveryDemon.First(e => e.Sin == name);
        }

        public IDemonParsed GetDemon(int i)
        {
            return GetDemon(DemonNames[i]);
        }

        public IDemonParsed Random()
        {
            return EveryDemon.ToArray().Rand();
        }
    }
}