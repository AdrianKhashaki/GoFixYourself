using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
public class Toaster : MonoBehaviour
{
    public GameObject Toast;
    public Transform Spawner;
    public float EjectionForce;
    
    private CustomPlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
    }

    private void Start()
    {
        _playerInput.ButtonDown
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