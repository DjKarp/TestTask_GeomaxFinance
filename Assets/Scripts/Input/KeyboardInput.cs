using UnityEngine;

namespace TestTask_GeomaxFinance
{
    public class KeyboardInput : GameInput
    {
        private float _axisHorizontal = 0.0f;
        private float _axisVertical = 0.0f;

        public override Vector2 GetMoveDirection()
        {
            _axisHorizontal = Input.GetAxis("Horizontal");
            _axisVertical = Input.GetAxis("Vertical");

            Direction = new Vector2(_axisHorizontal, _axisVertical);

            return Direction;
        }
    }
}
