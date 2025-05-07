using UnityEngine;

namespace TestTask_GeomaxFinance
{
    public abstract class GameInput : MonoBehaviour
    {
        protected Vector2 Direction;

        public abstract Vector2 GetMoveDirection();
    }
}
