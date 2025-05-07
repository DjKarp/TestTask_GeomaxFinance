using UnityEngine;
using UnityEngine.UI;

namespace TestTask_GeomaxFinance
{
    public class SpeedSliderUI : MonoBehaviour
    {
        private Image _image;
        private Move _move;

        public void Init(Move move)
        {
            _move = move;
            _image = gameObject.GetComponent<Image>();
            _image.fillAmount = 0.0f;
        }

        private void LateUpdate()
        {
            _image.fillAmount = _move.GetNormalizeSpeed();
        }
    }
}
