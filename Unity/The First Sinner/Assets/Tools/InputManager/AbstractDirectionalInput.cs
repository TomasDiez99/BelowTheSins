using System.Linq;
using UnityEngine;
namespace InputManager
{
    public abstract class AbstractDirectionalInput : AbstractInput
    {
        public abstract Vector2 Direction { get; }        

        public static implicit operator Vector2(AbstractDirectionalInput d)
        {
            return d.Direction;
        }
        public static implicit operator Vector3(AbstractDirectionalInput d)
        {
            return d.Direction;
        }

    }

}
