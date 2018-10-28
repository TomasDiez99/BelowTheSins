namespace Demons
{
    public interface StrategyStats
    {
        void Increment(IDemonParsed d);
        void Decrement(IDemonParsed d);
    }
}