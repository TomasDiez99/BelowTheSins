using UnityEngine;

namespace Demons
{
    public class LogicalDemonParsed : IDemonParsed
    {
        public string Sin { get; private set; }
        public float Health { get; private set; }

        public LogicalDemonParsed(string name)
        {
            Sin = name;
        }
    }
}