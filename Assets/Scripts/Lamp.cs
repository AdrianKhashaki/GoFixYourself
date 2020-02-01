using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Lamp : MonoBehaviour
{
    [SerializeField] private Light _light;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.Button.DistinctUntilChanged().Subscribe(SwitchLight).AddTo(this);
    }

    private void SwitchLight(bool on)
    {
        _light.intensity = on ? 1 : 0;
    }
}