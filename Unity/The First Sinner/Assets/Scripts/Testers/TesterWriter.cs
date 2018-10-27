using InputManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Testers
{
    public class TesterWriter : MonoBehaviour
    {

        private Writer Writer => Writer.Instance;

        [FormerlySerializedAs("Texto a ingresar")][SerializeField]
        private string text = "";

        private AbstractDiscreteInput

            settext, //B
            hurryup;//D

        private void Awake()
        {

            settext = new DiscreteKeyboard(KeyCode.E);
            
            hurryup = new DiscreteKeyboard(KeyCode.H);
            
 


            settext.Event += SettextOnEvent;
            hurryup.Event += Writer.HurryUp;

        }

        private void HurryupOnEvent()
        {
            Writer.HurryUp();
        }


        private void SettextOnEvent()
        {
            Writer.SetText(text);
        }
        
        
    }
}