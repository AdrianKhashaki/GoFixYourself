using UniRx;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(CustomPlayerInput))]
public class Lamp : MonoBehaviour
{
    [SerializeField] private Light2D[] _light;
    private CustomPlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
    }

    private void Start()
    {
        _playerInput.Button.DistinctUntilChanged().Subscribe(SwitchLight).AddTo(this);
    }

    private void SwitchLight(bool on)
    {
        foreach (var light2D in _light)
        {
            light2D.intensity = on ? 1 : 0;
        }
    }
}