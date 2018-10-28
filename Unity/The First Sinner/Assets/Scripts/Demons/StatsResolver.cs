using Patterns;

namespace Demons
{
    public class StatsResolver:ScriptSingleton<StatsResolver>
    {

        public StrategyStats point { get; set; }=new NormalStats();
        
        public void Increment(IDemonParsed logical)
        {
            point.Increment(logical);
        }

        public void Decrement(IDemonParsed logical)
        {
            point.Decrement(logical);
        }
    }
}