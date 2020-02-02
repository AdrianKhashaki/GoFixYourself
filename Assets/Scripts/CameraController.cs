using System;
using UniRx;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;

    public Transform Player1;
    public Transform Player2;
    public float SmoothTime;
    public float ExtraZoom;
    public float minOrthSize = 0.5f;

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
        Vector3 centerPos = (Player1.position + Player2.position) / 2;
        var newPos = Vector2.SmoothDamp(cameraPosition, centerPos, ref _currentVelocity, SmoothTime);
        Camera.transform.position = (Vector3) newPos + cameraPosition.z * Vector3.forward;

        float xDistance = Mathf.Abs(Player1.position.x - Player2.position.x);
        float yDistance = Mathf.Abs(Player1.position.y - Player2.position.y);
        float currentHeight = Camera.orthographicSize;
        float screenRatio = Screen.width / Screen.height;
        float currentWidth = currentHeight * screenRatio;
        float yMinSize = yDistance * ExtraZoom * screenRatio;
        float xMinSize = xDistance * ExtraZoom;
        float minSize = 0;
        if(yMinSize > xMinSize)
        {
            minSize = yMinSize;
        }
        else
        {
            minSize = xMinSize;
        }

        float newSize = Mathf.Lerp(Camera.orthographicSize, minSize, 0.5f);
        if(newSize < minOrthSize)
        {
            newSize = minOrthSize;
        }
        Camera.orthographicSize = newSize;
    }
}