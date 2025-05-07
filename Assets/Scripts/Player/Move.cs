using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace TestTask_GeomaxFinance
{
    public class Move : MonoBehaviour
    {
        private float _maxSpeed = 4.0f;
        private float _currentSpeed = 0.0f;
        private float _acceleration = 1.8f;

        private Transform _transform;
        private SpriteRenderer _spriteRenderer;

        private List<GameInput> _gameInputs = new List<GameInput>();
        private Vector2 _inputDirection;

        private Vector2 _leftDownCornerPosition;
        private Vector2 _rightUpperCornerposition;

        private Vector2 _currentPosition;
        private Vector2 _newPosition;
        

        public void Init()
        {
            _transform = gameObject.transform;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            _leftDownCornerPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            _rightUpperCornerposition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            var halfSizeX = _spriteRenderer.size.x / 2.0f;
            var halfSizeY = _spriteRenderer.size.y / 2.0f;
            _leftDownCornerPosition = new Vector2(_leftDownCornerPosition.x + halfSizeX, _leftDownCornerPosition.y + halfSizeY);
            _rightUpperCornerposition = new Vector2(_rightUpperCornerposition.x - halfSizeX, _rightUpperCornerposition.y - halfSizeY);

            _gameInputs.Add(gameObject.AddComponent<KeyboardInput>());
            var screenInput = FindFirstObjectByType<ScreenInput>();
            _gameInputs.Add(screenInput);
        }

        public Vector2 GetNewPosition()
        {
            _inputDirection = Vector2.zero;
            foreach (GameInput gameInput in _gameInputs)
            {
                _inputDirection = gameInput.GetMoveDirection();
                if (_inputDirection != Vector2.zero)
                    break;
            }

            _currentPosition = _transform.position;

            if (_inputDirection == Vector2.zero)
            {
                _currentSpeed = 0;
                return _currentPosition;
            }

            _currentSpeed = Mathf.Clamp(_currentSpeed + (_acceleration * Time.deltaTime), 0.0f, _maxSpeed);

            var newPosition = _currentPosition + (_inputDirection * _currentSpeed * Time.deltaTime);
            _newPosition = new Vector2(Mathf.Clamp(newPosition.x, _leftDownCornerPosition.x, _rightUpperCornerposition.x), Mathf.Clamp(newPosition.y, _leftDownCornerPosition.y, _rightUpperCornerposition.y));

            return _newPosition;
        }

        public float GetNormalizeSpeed()
        {
            return _currentSpeed / _maxSpeed;
        }
    }
}
