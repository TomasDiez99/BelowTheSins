using System;
using System.Collections.Generic;
using Demons;
using JetBrains.Annotations;
using Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sinners
{
    public class SinnerGetter : ScriptSingleton<SinnerGetter>
    {
        private List<IPhrase> _phrases =new List<IPhrase>();
        private Phrase[] _phrasesArray;
        private bool isInit;

        private void Init()
        {
            isInit = true;
            PhraseCharger.GetCollection(_phrases);
            int num = 0;
            _phrasesArray = new Phrase[_phrases.Count];
            foreach (Phrase phrase in _phrases)
            {
                _phrasesArray[num] = phrase;
            }
        }

        public Sinner GetOne()
        {
            if(!isInit) Init();
            var p = RandStr();
		    return new Sinner(Buckets.Instance.Sinners.Rand(),
		        new Confesion(p),p);
        }

        private Phrase RandStr()
        {
            return _phrasesArray.Rand();
        }
    }
}

public static class ExtenderArreglo
{
    [ContractAnnotation("ar: null=>false")]
    public static T Rand<T>(this T[] ar)
    {
        return ar[Random.Range(0, ar.Length)];
    }
}