using System;
using System.Linq;
using Demons;
using JetBrains.Annotations;
using Patterns;
using Random = UnityEngine.Random;

namespace Sinners
{
    public class SinnerGetter : ScriptSingleton<SinnerGetter>
    {
        
        public Sinner GetOne()
        {
		    return new Sinner(Buckets.Instance.Sinners.Rand(),
		        new Confesion(DemonManager.Instance.Random(),RandStr() ));
            
        }

        private string RandStr()
        {
            string[] g =
            {
                "Me gusta comer todo el dia",
                "Me gusta garchar todo el dia",
                "Me gusta pegarle a la gente",
                "soy lo mas",
                "Todo ese dinero es mio",
                "voy a matarlo porque me gusta su remera",
                "na, que paja",
            };
            return g.Rand();
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