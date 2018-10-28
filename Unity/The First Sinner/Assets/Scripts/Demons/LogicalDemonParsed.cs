using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Demons
{
    public class LogicalDemonParsed : IDemonParsed
    {
        public Image Halo { get; }
        public string Sin { get; private set; }
        [Range(0,100)]private float _healt=50;
        public float Health
        {
            get { return _healt; }
            set
            {
                var fill=Halo.DOFillAmount(value/100,2);
                fill.OnComplete(() => _healt = value);
            }
        }

        public LogicalDemonParsed(string name, Image halos)
        {
            Halo = halos;
            Sin = name;
            Health = 40;
        }
    }

    
}