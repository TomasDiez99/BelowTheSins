using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Demons
{
    public class LogicalDemonParsed : IDemonParsed
    {
        public Image Halo { get; }
        public string Sin { get; private set; }
        [Range(0,100)]private float _healt=5;
        
        public float Health
        {
            get { return _healt; }
            set
            {
                var fill=Halo.DOFillAmount(value/10,2);
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