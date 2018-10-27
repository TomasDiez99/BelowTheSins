using System.Collections.Generic;
using Patterns;

namespace UI
{
    public class Messages : ScriptSingleton<Messages>
    {
        private DialogWriter Writer => DialogWriter.Instance;
        private Queue<string> _textQueue = new Queue<string>();
        private int Limit = 50;
        
        public void AddMessage(string message)
        {
            ParseAndEnqueue(message);
            if (!Writer.IsWorking())
            {
                Writer.SetText(_textQueue.Dequeue());
            }
        }

        private void ParseAndEnqueue(string message)
        {
            if (message.Length > Limit)
            {
                var newMsg = "";
                var words = message.Split(',', ' ', '.');
                var i = 0;
                while (newMsg.Length < Limit && i<words.Length)
                {
                    newMsg += words[i] + " ";
                    i++;
                }
                _textQueue.Enqueue(newMsg);
                var crap = "";
                for (var j = i; j < words.Length; j++)
                {
                    crap += words[j]+" ";
                }
                ParseAndEnqueue(crap);
            }
            else
            {
                _textQueue.Enqueue(message);
            }
        }

        public void Enter()
        {
            if (Writer.IsWorking())
                Writer.HurryUp();
            else
            {
                if (_textQueue.Count <= 0) return;
                Writer.SetText(_textQueue.Dequeue());
            }
        }

        public int remainingMessages()
        {
            return _textQueue.Count;
        }
        
        
    }
}