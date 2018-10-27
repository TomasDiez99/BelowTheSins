using InputManager;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Testers
{
    public class TesterWriter : MonoBehaviour
    {

        private DialogWriter Wt => DialogWriter.Instance;

        [FormerlySerializedAs("Texto a ingresar")][SerializeField]
        private string text = "";

        private AbstractDiscreteInput

            encolar,
            enter;
        private Messages _messages => Messages.Instance;
        
        private void Awake()
        {
            encolar = new DiscreteKeyboard(KeyCode.E);
            enter = new DiscreteKeyboard(KeyCode.H);
            encolar.Event += () => _messages.AddMessage(text);
            enter.Event += () => _messages.Enter();
        }

        
        
    }
}