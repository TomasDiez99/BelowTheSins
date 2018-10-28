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
        public List<IPhrase> _phrases =new List<IPhrase>();
        private Confesion[] _confesionsArray;
        private bool isInit;
        private int index;

        private void Init()
        {
            isInit = true;
            PhraseCharger.GetCollection(_phrases);
            int num = 0;
            _confesionsArray = new Confesion[_phrases.Count];
            foreach (Confesion phrase in _phrases)
            {
                _confesionsArray[num++] = phrase;
            }

            index = _phrases.Count;
        }

        public Sinner GetOne()
        {
            if(!isInit) Init();
            return new Sinner(Buckets.Instance.Sinners.Rand(),RandStr());
        }

        private Confesion RandStr()
        {
            Confesion a= _confesionsArray[index--];
            if (index == 0)
            {
                GameItself.Instance.Win = true;
            }

            return a;
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