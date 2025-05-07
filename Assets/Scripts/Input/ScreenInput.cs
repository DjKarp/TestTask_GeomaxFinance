using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestTask_GeomaxFinance
{
    public class ScreenInput : GameInput, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _tapArea;
        private Vector2 _startPosition;
        private Vector2 _endPosition;

        public override Vector2 GetMoveDirection()
        {
            return Direction;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_tapArea.rectTransform, eventData.position, null, out _startPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_tapArea.rectTransform, eventData.position, null, out _endPosition))
            {
                Direction = _endPosition - _startPosition;
                Direction = Direction.magnitude > 1.0f ? Direction.normalized : Direction;
            }
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            Direction = Vector2.zero;
        }

        public void SetTapArea(Image image)
        {
            _tapArea = image;
        }
    }
}
