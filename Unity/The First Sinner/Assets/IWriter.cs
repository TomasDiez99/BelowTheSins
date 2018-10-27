public interface IWriter
{
    
    /// <summary>
    /// Setea un texto (usar is working antes)
    /// asume que no se esta escribiendo antes
    /// para interrumpir use SetTextNow
    /// </summary>
    /// <param name="text"></param>
    void SetText(string text);
    /// <summary>
    /// Apurar el texto
    /// </summary>
    void HurryUp();
    /// <summary>
    /// setea el delay
    /// </summary>
    /// <param name="x"></param>
    void SetDelay(int x);
    /// <summary>
    /// pregunta si estas escribiendo
    /// </summary>
    /// <returns></returns>
    bool IsWorking();
    
}