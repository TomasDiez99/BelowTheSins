using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Demons
{
    public class PhraseCharger
    {
        public static void GetCollection(List<IPhrase> phrases)
        {
            StreamReader r = new StreamReader("Assets/Scripts/Demons/Phrases.json");
            string json = r.ReadToEnd();
            r.Close();
            PhraseField[] toPhrases = JsonConvert.DeserializeObject<PhraseField[]>(json);
            foreach (PhraseField phraseField in toPhrases )
            {
                IPhrase phrase= new Confesion(phraseField.Content);
                phrases.Add(phrase);
                foreach (string sin in phraseField.Demons)
                {
                    phrase.SinsRelated.Add(DemonManager.Instance.GetDemon(sin));
                }
            }
        }
    }
}