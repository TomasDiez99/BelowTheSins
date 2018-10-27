using Demons;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mechanics
{
    public class Demon: MonoBehaviour
    {
        
        [FormerlySerializedAs("Point")][SerializeField]
        private Transform _placeInTable;
        
        public IDemonParsed _related;

        
        private void Start()
        {
            var tw = transform.DOMove(_placeInTable.position, 2);
            tw.SetEase(Ease.InOutCubic);
            GetComponent<SpriteRenderer>().DOColor(Color.white, 3);
        }
    }
}