using Demons;
using UnityEngine;

namespace Sinners
{
    public class Sinner
    {
        public Sprite _sprite;
        public Confesion Confesion;

        public Sinner(Sprite spr, Confesion confesion)
        {
            _sprite = spr;
            Confesion = confesion;

        }

    }
}