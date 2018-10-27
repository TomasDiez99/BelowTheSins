
namespace InputManager
{
    using UnityEngine;

    public class DiscreteKeyboard : AbstractDiscreteInput
    {
        public KeyCode Key { get; set; }
        public bool KeyDown { get; set; }
        public override event InputEvent Event;
        public DiscreteKeyboard(KeyCode key)
        {
            Key = key;
            KeyDown = true;
        }
        public DiscreteKeyboard(KeyCode key , bool keyDown)
        {
            Key = key;
            KeyDown = keyDown;
        }
        public override void Update()
        {
            if(KeyDown && Input.GetKeyDown(Key))
            {
                Event?.Invoke();
            }
            if (!KeyDown && Input.GetKeyUp(Key))
            {
                Event?.Invoke();
            }
        }
    }

}