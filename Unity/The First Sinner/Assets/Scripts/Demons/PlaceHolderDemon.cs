using UnityEngine;

namespace Demons
{
    public class PlaceHolderDemon : IDemon
    {
        public string Sin { get; private set; }
        public float Health { get; private set; }

        public PlaceHolderDemon(string name)
        {
            Sin = name;
        }
    }
}