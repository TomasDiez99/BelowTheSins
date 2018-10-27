

using Patterns;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.Assertions;

public class Writer : ScriptSingleton<Writer>, IWriter
{
    private int delay=10, frame=0, i=0;
    private string textToShow = "";
    private bool working = false;


    private string Text
    {
        get { return GetComponent<TextMeshProUGUI>().text; }
        set { GetComponent<TextMeshProUGUI>().text = value; }
    }


    public void SetText(string text)
    {
        if (working) return;
        textToShow = text;
        i = 0;
        working = true;
    }

    public void HurryUp()
    {
        Text = textToShow;
        i = 0;
        working = false;
    }

    public void SetDelay(int x) => delay = x;

    public bool IsWorking() => working;

    private void Update()
    {
        frame++;
        if(!working||frame%delay!=0)return;

        if (Completion())
        {
            working = false;
        }
        else
        {
            Text += textToShow[i++];
        }
    }

    private bool Completion() => textToShow.Length <= i;
    
}