using UnityEngine;

namespace TestTask_GeomaxFinance
{
    public class Player : MonoBehaviour
    {
        private Transform _transform;
        private Move _move;
        

        public Move Init()
        {
            _transform = gameObject.transform;
            _move = gameObject.AddComponent<Move>();
            return _move;
        }

        private void Update()
        {
            _transform.position = _move.GetNewPosition();
        }
    }
}
