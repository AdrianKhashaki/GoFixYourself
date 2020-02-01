using UniRx;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;

    public Transform Player;
    public float SmoothTime;

    private Vector2 _currentVelocity = Vector3.zero;
    
    private void Start()
    {
        Observable.EveryUpdate()
            .Subscribe(_ => SetCamera())
            .AddTo(this);
    }

    private void SetCamera()
    {
        var cameraPosition = Camera.transform.position;
        var newPos = Vector2.SmoothDamp(cameraPosition, Player.position, ref _currentVelocity, SmoothTime);
        Camera.transform.position = (Vector3) newPos + cameraPosition.z * Vector3.forward;
}
}