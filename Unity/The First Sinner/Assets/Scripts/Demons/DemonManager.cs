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
            Gula = new LogicalDemonParsed("Gula", Halos.HaloGluttony,Halos.HaloGluttonyOut);
            Envidia = new LogicalDemonParsed("Envidia", Halos.HaloEnvy,Halos.HaloEnvyOut);
            Lujuria = new LogicalDemonParsed("Lujuria", Halos.HaloLust,Halos.HaloLustOut);
            Soberbia = new LogicalDemonParsed("Soberbia", Halos.HaloPride,Halos.HaloPrideOut);
            Ira = new LogicalDemonParsed("Ira", Halos.HaloWrath,Halos.HaloWrathOut);
            Pereza = new LogicalDemonParsed("Pereza", Halos.HaloSloth,Halos.HaloSlothOut);
            Codicia = new LogicalDemonParsed("Codicia", Halos.HaloGreed,Halos.HaloGreedOut);


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