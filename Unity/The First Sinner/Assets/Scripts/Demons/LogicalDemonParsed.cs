using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Demons
{
    public class LogicalDemonParsed : IDemonParsed
    {
        public Image HaloOut { get; }
        public Image HaloIn { get; set; }
        public string Sin { get; private set; }
        [Range(0,100)]private float _healt=0;
        
        public float Health
        {
            get { return _healt; }
            set
            {
                var fill=HaloIn.DOFillAmount(value/10,2);
                fill.OnComplete(() => _healt = value);
            }
        }

        public LogicalDemonParsed(string name, Image haloIn,Image haloOut)
        {
            HaloOut = haloOut;
            HaloIn = haloIn;
            HaloOut.enabled = false;
            HaloIn.enabled = false;
            
            Sin = name;
            Health=5;
        }
    }

    
}