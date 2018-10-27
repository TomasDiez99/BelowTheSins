


namespace InputManager
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class ContinueKeyboard : AbstractContinueInput
    {
        public KeyCode Key { get; private set; }
        public override bool Happens => Input.GetKey(Key);
        public ContinueKeyboard(KeyCode key) { Key = key; } // monoline 
    }

    public class ContinueKeyboardSetAnd : AbstractContinueInput
    {
        public List<KeyCode> Keys { get; private set; }
        public override bool Happens
        {
            get
            {
                foreach(KeyCode k in Keys)
                {
                    if (!Input.GetKey(k))
                        return false;
                }
                return true;
            }
        }
        public ContinueKeyboardSetAnd(KeyCode[] keys) { Keys = keys.ToList(); } // monoline 
        public ContinueKeyboardSetAnd(IEnumerable<KeyCode> keys) { Keys = keys.ToList(); } // monoline 
    }

    public class ContinueKeyboardSetOr : AbstractContinueInput
    {
        public List<KeyCode> Keys { get; private set; }
        public override bool Happens
        {
            get
            {
                foreach(KeyCode k in Keys)
                {
                    if (Input.GetKey(k))
                        return true;
                }
                return false;
            }
        }

        public ContinueKeyboardSetOr(KeyCode[] keys) { Keys = keys.ToList(); } // monoline 
        public ContinueKeyboardSetOr(IEnumerable<KeyCode> keys) { Keys = keys.ToList(); } // monoline 
    }



}