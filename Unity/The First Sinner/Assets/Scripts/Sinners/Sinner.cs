using Demons;
using UnityEngine;

namespace Sinners
{
    public class Sinner
    {
        public Sprite _sprite;
        public Confesion _conf;
        public Phrase _phrase;
        

        public Sinner(Sprite spr, Confesion c,Phrase phrase)
        {
            _sprite = spr;
            _conf = c;
            _phrase = phrase;

        }

    }

    public class Confesion
    {
        public string text;
        [Range(1,15)]public int delayAtShowText;

        public Confesion(Phrase phrase)
        {
            delayAtShowText = 10;
            this.text = phrase.Content;
        }
    }
}