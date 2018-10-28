using System.Collections.Generic;
using UnityEngine;

namespace Demons
{
    public class Confesion : IPhrase
    {
        public string Content { get; protected set; }
        public List<IDemonParsed> SinsRelated { get; }
        [Range(1,15)]public int delayAtShowText;

        public Confesion(string content)
        {
            Content = content;
            delayAtShowText = 10;
            SinsRelated= new List<IDemonParsed>();
        }
    }
}