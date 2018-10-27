using System;
using System.Collections.Generic;
using Patterns;
using Tools;
using UnityEngine;


namespace Mechanics
{
    public class Demons : ScriptSingleton<Demons>
    {
        public Demon Codicia, Ira, Pereza, Gula, Envidia, Lujuria, Orgullo;
        private Demon[] __demons;

        
        private float bigDistance = 1;
        
        public IEnumerable<Demon> EveryDemons
        {
            get
            {
                if(__demons==null || __demons.Length<=0)
                    __demons = new[]{ Codicia, Ira, Pereza, Gula, Envidia, Lujuria, Orgullo};
                return __demons;
            }
        }

        private void Start()
        {
            
        }


        public Demon GetNearestDemon(Vector2 clickPoint)
        {
            Demon near = null;
            var minDist = bigDistance;
            foreach (var demon in EveryDemons)
            {
                var currentDistance = Vector2.Distance(demon.transform.position, clickPoint);
                Debug.Log("current "+currentDistance + " -- "+bigDistance);
                if (currentDistance < minDist)
                {
                    near = demon;
                    minDist = currentDistance;
                }
            }
            return near;
        }
        
    }
}