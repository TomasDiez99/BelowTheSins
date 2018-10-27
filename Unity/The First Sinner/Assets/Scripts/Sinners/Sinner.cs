using Demons;
using UnityEngine;

namespace Sinners
{
    public class Sinner
    {
        public Sprite _sprite;
        public Confesion _conf;

        public Sinner(Sprite spr, Confesion c)
        {
            _sprite = spr;
            _conf = c;
        }

    }

    public struct Confesion
    {
        public string text;
        [Range(1,15)]public int delayAtShowText;
        public IDemon demon;

        public Confesion(IDemon demon, string text)
        {
            delayAtShowText = 10;
            this.text = text;
            this.demon = demon;    
        }
    }
}