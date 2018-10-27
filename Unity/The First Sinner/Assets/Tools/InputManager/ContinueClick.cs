


namespace InputManager
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ContinueClick : AbstractContinueInput
    {
        
        public MouseClickType Type { get; private set; }
        public override bool Happens => Input.GetKey(Key[Type]);
        private Dictionary<MouseClickType, KeyCode> Key => new Dictionary<MouseClickType, KeyCode>
        {
            [MouseClickType.Left] = KeyCode.Mouse0,
            [MouseClickType.Right] = KeyCode.Mouse1,
            [MouseClickType.Middle] = KeyCode.Mouse2
        };
        /// <summary>
        /// Default : Left Click
        /// </summary>
        public ContinueClick(MouseClickType typeClick) { Type = typeClick; }//monoline        
        public ContinueClick() : this(MouseClickType.Left) { }
    }
}