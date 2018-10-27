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
            writenow, //A
            enqueue, //B
            writecommon,//C
            hurryup;//D
            
        private void Awake()
        {
            writenow = new DiscreteKeyboard(KeyCode.A);
            enqueue = new DiscreteKeyboard(KeyCode.B);
            writecommon = new DiscreteKeyboard(KeyCode.C);
            hurryup = new DiscreteKeyboard(KeyCode.D);
            
            writenow.Event += WritenowOnEvent;
            enqueue.Event += EnqueueOnEvent;  
            writecommon.Event += WritecommonOnEvent;
            hurryup += 
        }

        private void WritecommonOnEvent()
        {
            Writer.SetText(text);
        }

        private void EnqueueOnEvent()
        {
            Writer.LazySetText(text);
        }

        private void WritenowOnEvent()
        {
            Writer.SetTextNow(text);
        }
        
        
        
        
    }
}