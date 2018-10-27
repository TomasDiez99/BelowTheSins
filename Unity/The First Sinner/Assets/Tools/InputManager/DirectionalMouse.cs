using UnityEngine;
using Tools;
namespace InputManager
{
    public class DirectionalMouse : AbstractDirectionalInput
    {
        public override Vector2 Direction
        {
            get
            {
                Camera cam = Camera.main;
                if (!cam)
                {
                    cam = GameObject.FindObjectOfType<Camera>();
                }
                Vector2 refInCanvas = Reference!=null? cam.WorldToScreenPoint(Reference.position) : Vector3.zero;
                    
                    Vector2 rawDirection = refInCanvas.GoTo(Input.mousePosition) * 0.05f;
                    return rawDirection.magnitude > 1 ? rawDirection.normalized : rawDirection;
                

                
            }
        }
        public Transform Reference { get; set; }

        public DirectionalMouse (Transform reference)
        {
            Reference = reference;
        }

    }
}
