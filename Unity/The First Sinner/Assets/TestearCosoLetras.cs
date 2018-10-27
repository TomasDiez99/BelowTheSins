using UnityEngine;
using UnityEngine.Serialization;

public class TestearCosoLetras : MonoBehaviour
{
    [FormerlySerializedAs("Texto a Enviar")]
    public string mandarTexto;

    
    [Range(1,20)]public int delay = 1;
    private static Writer Write => FindObjectOfType<Writer>();
		
    private void Update()
    {
        Write.SetDelay(delay);
        if (Write.IsWorking()) return;
        Write.SetText(mandarTexto);
    }
    
    
}