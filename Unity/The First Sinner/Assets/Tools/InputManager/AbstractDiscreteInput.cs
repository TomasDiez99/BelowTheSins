namespace InputManager
{
    using Listeners;
    public delegate void InputEvent();
    public abstract class AbstractDiscreteInput : AbstractInput, IUpdatable
    {
        public bool Paused { get; } = false;
        
        public AbstractDiscreteInput()
        {
            Updater.Instance.Add(this);
        }

        public abstract event InputEvent Event;
        public abstract void Update();                
    }

    public class DummyDiscreteInput : AbstractDiscreteInput
    {
        public override event InputEvent Event;

        public void BroadCast()
        {
            Event?.Invoke();
        }
        public override void Update()
        {
            
        }
    }

}
