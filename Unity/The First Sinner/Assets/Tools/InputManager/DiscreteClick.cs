namespace InputManager
{
    using UnityEngine;

    public class DiscreteClick : AbstractDiscreteInput
    {
        public override event InputEvent Event;
        public bool Down { get; set; }
        public MouseClickType Type { get; set; }


        /// <summary>
        /// Default Mouse Left Click and ClickDown
        /// </summary>
        public DiscreteClick() : this(MouseClickType.Left, true) { }
        /// <summary>
        /// Default ClickDown
        /// </summary>
        /// <param name="type"></param>
        public DiscreteClick(MouseClickType type) : this(type, true) { }
        public DiscreteClick(MouseClickType type , bool clickDown)
        {
            Type = type;
            Down = clickDown;
        }

        public override void Update()
        {
            if (Type == MouseClickType.Left && Down)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                    Event?.Invoke();
            }
            if (Type == MouseClickType.Right && Down)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                    Event?.Invoke();
            }
            if (Type == MouseClickType.Middle && Down)
            {
                if (Input.GetKeyDown(KeyCode.Mouse2))
                    Event?.Invoke();
            }
            if (Type == MouseClickType.Left && !Down)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                    Event?.Invoke();
            }
            if (Type == MouseClickType.Right && !Down)
            {
                if (Input.GetKeyUp(KeyCode.Mouse1))
                    Event?.Invoke();
            }
            if (Type == MouseClickType.Middle && !Down)
            {
                if (Input.GetKeyUp(KeyCode.Mouse2))
                    Event?.Invoke();
            }
        }
    }
}
