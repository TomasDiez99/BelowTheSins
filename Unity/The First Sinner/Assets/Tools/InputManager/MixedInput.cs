namespace InputManager
{
    public class MixedInput : AbstractInput
    {
        public AbstractDiscreteInput Discrete { get; private set; }
        public AbstractContinueInput Continue { get; private set; }
        private MixedInput(AbstractDiscreteInput Discrete, AbstractContinueInput Continue)
        {
            this.Discrete = Discrete;
            this.Continue = Continue;
        }
    }

}
