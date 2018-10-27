using System.Collections.Generic;
using UnityEngine;
namespace InputManager
{
    /// <summary>
    /// UNSAFE!!!! <<= Test with a better joystick
    /// </summary>
    //TODO: Conseguir un joystick y testear esto
    public class DirectionalJoystick : AbstractDirectionalInput
    {
        
        public Stick Stick { get; private set; }
        private Dictionary<Stick, string> Maping => new Dictionary<Stick, string>
        {
            [Stick.Left] = "JoyLeft",
            [Stick.Right] = "JoyRight"
        };
        private enum Axis {X,Y}
        private string GetKey(Stick s, Axis eje) => Maping[s] + eje.ToString();        

        public override Vector2 Direction
        {
            get
            {
                float x = Input.GetAxis(GetKey(Stick, Axis.X));
                float y = Input.GetAxis(GetKey(Stick, Axis.Y));
                Vector2 v = new Vector2(x, -y);
                return (v.magnitude < 0.01f) ? Vector2.zero :  v;                
                
            }
        }
        /// <summary>
        /// Default Left Stick
        /// </summary>
        public DirectionalJoystick() : this(Stick.Left) { }
        public DirectionalJoystick(Stick stick)
        {
            Debug.Log("this module has not yet been tested please use another directional or first test this module correctly with another joystick");            
            Stick = stick;            
        }
        
    }
}
