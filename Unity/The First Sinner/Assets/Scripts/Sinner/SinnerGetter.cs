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
        private string[] _phrasesContent;
        private bool isInit;

        private void Init()
        {
            isInit = true;
            PhraseCharger.GetCollection(_phrases);
            int num = 0;
            _phrasesContent = new string[_phrases.Count];
            foreach (var phrase in _phrases)
            {
                _phrasesContent[num++] = phrase.Content;
            }
        }


        public Sinner GetOne()
        {
            if(!isInit) Init();
		    return new Sinner(Buckets.Instance.Sinners.Rand(),
		        new Confesion(DemonManager.Instance.Random(),RandStr() ));
        }

        private string RandStr()
        {
            return _phrasesContent.Rand();
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