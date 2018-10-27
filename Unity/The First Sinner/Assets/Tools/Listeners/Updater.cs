using Patterns;
using System.Collections.Generic;
using UnityEngine;

namespace Listeners
{
    public class Updater : MonoBehaviour
    {
        /// <summary>
        /// AutoFactory
        /// </summary>
        private static Updater instance;

        public static Updater Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject g = new GameObject();
                    instance = g.AddComponent<Updater>();
                    instance.Updatables = new List<IUpdatable>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            instance = this;
            gameObject.name = "SystemUpdater";
        }

        private IList<IUpdatable> Updatables { get; set; }        
        
        public bool Add(IUpdatable updatable)
        {
            if (Updatables == null) Updatables = new List<IUpdatable>();
            bool ret = !Updatables.Contains(updatable);
            if (ret)
            {
                Updatables.Add(updatable);                
            }
            return ret;
        }

        public bool Remove(IUpdatable updatable)
        {
            bool ret = Updatables.Contains(updatable);
            if (ret)
            {
                Updatables.Remove(updatable);
            }
            return ret;
        }

        private void Update()
        {
            foreach(IUpdatable up in Updatables)
            {
                if(!up.Paused)
                    up.Update();
            }
        }

    }
}
