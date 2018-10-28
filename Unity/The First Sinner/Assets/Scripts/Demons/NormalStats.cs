namespace Demons
{
    public class NormalStats:StrategyStats
    {
        public void Increment(IDemonParsed d)
        {
            d.Health++;
        }

        public void Decrement(IDemonParsed d)
        {
            d.Health--;
        }
    }
}