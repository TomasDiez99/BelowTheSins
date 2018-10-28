using System.Collections.Generic;

namespace Demons
{
    public class Phrase : IPhrase
    {
        public string Content { get; protected set; }
        public List<IDemonParsed> SinsRelated { get; }

        public Phrase(string content)
        {
            Content = content;
            SinsRelated= new List<IDemonParsed>();
        }
    }
}