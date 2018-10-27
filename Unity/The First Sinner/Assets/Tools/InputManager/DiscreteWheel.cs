namespace InputManager
{
    using UnityEngine;

    public class DiscreteWheel : AbstractDiscreteInput
    {
        public override event InputEvent Event;

        public bool Up { get; set; }
        public DiscreteWheel(bool up)
        {
            Up = up;
        }        

        public override void Update()
        {
            if (Up && Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                Event?.Invoke();
            }
            if (!Up && Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                Event?.Invoke();
            }
        }
    }
}
