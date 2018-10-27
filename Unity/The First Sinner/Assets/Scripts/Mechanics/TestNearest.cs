using DG.Tweening;
using InputManager;
using UnityEngine;

namespace Mechanics
{
    public class TestNearest : MonoBehaviour
    {
        private AbstractDiscreteInput click;
        private Demons Dem => Demons.Instance;
        
        private void Start()
        {
            click = new DiscreteClick();
            click.Event += MouseinMap;
        }

        private void MouseinMap()
        {
            var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var meyDem = Dem.GetNearestDemon(worldPoint);
            Debug.Log("--");
            if (!meyDem) return;
            
            Debug.Log("dentró");
            meyDem.GetComponent<SpriteRenderer>().DOColor(new Color(0.39f, 0.65f, 0f,0),.5f);
        }
    }
}