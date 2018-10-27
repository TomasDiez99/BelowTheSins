namespace InputManager
{
    public abstract class AbstractContinueInput : AbstractInput
    {
        public abstract bool Happens { get; }
        public AbstractContinueInput Not()
        {
            return new NotContinueInput(this);
        }
        public static implicit operator bool(AbstractContinueInput p)
        {
            return p.Happens;
        }

    }

    internal class NotContinueInput : AbstractContinueInput
    {

        private AbstractContinueInput Inp;
        public NotContinueInput(AbstractContinueInput inp)
        {
            Inp = inp;
        }
        public override bool Happens => !Inp;
    }


}
