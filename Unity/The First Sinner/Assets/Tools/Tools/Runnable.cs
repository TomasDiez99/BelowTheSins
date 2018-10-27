


namespace Tools
{
    using Listeners;
    using System.Collections.Generic;
    public class Runnable  : IUpdatable
    {
        public delegate void Lambda();
        private Queue<Lambda> Tasks;

        public bool Paused => false;

        private Runnable()
        {
            Queue<Lambda> t = new Queue<Lambda>();
        }
        private Runnable(Lambda r)
        {
            Queue<Lambda> t = new Queue<Lambda>();
            t.Enqueue(r);            
            Tasks = t;
        }

        private Runnable(IEnumerable<Runnable> x)
        {
            Queue<Lambda> t = new Queue<Lambda>();
            foreach(Runnable r in x)
            {
                foreach(Lambda rn in r.Tasks)
                {
                    t.Enqueue(rn);
                }
            }
            Tasks = t;
        }
        
        public void Invoke()
        {
            foreach(Lambda r in Tasks)
            {
                r?.Invoke();
            }            
        }

        public bool IsEmpty() => Tasks.Count == 0;

        public Runnable Dequeue()
        {
            if(Tasks.Count == 0)
            {
                throw new RunnableException("You cant Dequeue in an Empty Runnable, use IsEmpty(): bool to check it");
            }
            return Tasks.Dequeue();
        }

        public void Enqueue(Runnable r)
        {
            foreach(Lambda rn in r.Tasks)
            {
                Tasks.Enqueue(rn);
            }            
        }

        public void ExcecuteOne()
        {
            Dequeue()?.Invoke();
        }

        public void ExcecuteAll()
        {
            while (Tasks.Count > 0)
            {
                ExcecuteOne();
            }
        }

        public static implicit operator Runnable(Lambda r) => new Runnable(r);
        public static Runnable Empty() => new Runnable();
        public void Update() => Invoke();
    }
    


}