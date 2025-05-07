using UnityEngine;

namespace TestTask_GeomaxFinance
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private Player _player;
        private Move _move;
        [SerializeField] private SpeedSliderUI _speedSliderUI;

        private void Awake()
        {
            _player = FindFirstObjectByType<Player>();
            _move = _player.Init();
            _move.Init();
            _speedSliderUI.Init(_move);
        }
    }
}
