using System.Collections;
using System.Collections.Generic;
using Tools;

namespace Listeners
{
    public interface IUpdatable
    {
        bool Paused { get; }
        void Update();
    }
    public class GenericUpdatable : IUpdatable
    {        
        private Runnable Actions;

        public bool Paused { get; set; }
        public void EnqueueAction(Runnable r) => Actions.Enqueue(r);
        public Runnable DequeueAction(Runnable r) => Actions.Dequeue();

        public GenericUpdatable()
        {
            Actions = Runnable.Empty();
            Paused = false;
        }

        public void Update()
        {
            if (!Paused)
                Actions.Invoke();
        }
    }
}
