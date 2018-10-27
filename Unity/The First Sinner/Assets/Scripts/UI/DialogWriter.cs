using Patterns;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]

    public class DialogWriter : ScriptSingleton<DialogWriter>, IWriter
    {
        private int delay=10, frame=0, i=0;
        private string textToShow ;
        private bool working = false;

        private TextMeshProUGUI TMP => GetComponent<TextMeshProUGUI>();
    
    

        public void SetText(string text)
        {
            if (working) return;
            textToShow = text;
            TMP.text = "";
            i = 0;
            working = true;
        }

        public void HurryUp()
        {
            TMP.text = textToShow;
            i = 0;
            working = false;
        }

        public void SetDelay(int x) => delay = x;

        public bool IsWorking() => working;

        private void Update()
        {
            frame++;
            if(!working)return;
            if(frame%delay!=0)return;

            if (Completion())
            {
                working = false;
            }
            else
            {
                TMP.text += textToShow[i++];
            }
        }

        private bool Completion() => textToShow.Length <= i;
    
    }
}