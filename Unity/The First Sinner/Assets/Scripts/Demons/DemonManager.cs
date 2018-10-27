using System.Collections;
using Patterns;
using UnityEngine;

namespace Demons
{
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
}