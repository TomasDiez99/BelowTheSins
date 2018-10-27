using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

public interface IDemon
{
    float Health { get; }
}



public interface IPhrase
{
    string Demon { get; }
    string Content { get; }
    List<IDemon> SinsRelated { get; }
}
/// <summary>
/// Contents all demons (Statically)
/// </summary>
public class DemonManager : ScriptSingleton<DemonManager>
{
    public IDemon Gula { get; } = new PlaceHolderDemon();
    public IDemon Envidia { get; } = new PlaceHolderDemon();
    public IDemon Lujuria { get; } = new PlaceHolderDemon();
    public IDemon Soberbia { get; } = new PlaceHolderDemon();
    public IDemon Ira { get; } = new PlaceHolderDemon();
    public IDemon Pereza { get; } = new PlaceHolderDemon();
    public IDemon Codicia { get; } = new PlaceHolderDemon();
}

public class PlaceHolderDemon : IDemon
{
    public float Health { get; }
}
