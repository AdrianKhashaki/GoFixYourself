using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
[RequireComponent(typeof(Controllable))]
public class Toaster : MonoBehaviour
{
    public GameObject Toast;
    public Transform Spawner;
    public float EjectionForce;
    
    private CustomPlayerInput _playerInput;
    private Controllable _controllable;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
        _controllable = GetComponent<Controllable>();
    }

    private void Start()
    {
        _playerInput.ButtonDown
            .Where(down => down && _controllable.IsControllable)
            .Subscribe(_ => Shoot())
            .AddTo(this);
    }

    private void Shoot()
    {
        Instantiate(Toast, Spawner.position, Spawner.rotation)
            .GetComponent<Rigidbody2D>()
            .AddForce(Spawner.up * EjectionForce, ForceMode2D.Impulse);
    }
}