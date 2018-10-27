using System.Collections.Generic;

namespace Demons
{
    public class Phrase : IPhrase
    {
        public string Demon { get; protected set; }
        public string Content { get; protected set; }
        public List<IDemon> SinsRelated { get; }

        public Phrase(string content)
        {
            Content = content;
            SinsRelated= new List<IDemon>();
        }
    }
}