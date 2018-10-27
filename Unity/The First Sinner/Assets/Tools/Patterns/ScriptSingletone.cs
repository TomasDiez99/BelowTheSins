
namespace Patterns
{
    using UnityEngine;
    public abstract class ScriptSingleton<S> : MonoBehaviour where S : ScriptSingleton<S>
    {

        
        
        private static S s_instance;

        public static S Instance
        {
            get
            {
                if (s_instance == null)
                {
                    GameObject g = new GameObject("Singletone [Don't Touch]");
                    g.AddComponent<S>();
                }
                return s_instance;
            }

            private set
            {
                s_instance = value;
            }
        }
        public void Awake()
        {
            Instance = (S)this;
            Constructor();
            
        }
        public virtual void Constructor(){}
    }
}