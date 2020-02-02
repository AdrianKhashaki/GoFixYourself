using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerColor))]
public class CustomPlayerInput : MonoBehaviour
{
    private PlayerColor _playerColor;

    public Subject<bool> ButtonDown = new Subject<bool>();
    public Subject<bool> ButtonUp = new Subject<bool>();
    public Subject<bool> Button = new Subject<bool>();
    public Subject<Vector2> Movement = new Subject<Vector2>();

    public void inputActive(PartColor color, bool active)
    {
        if (color == _playerColor.Color)
        {
            Button.OnNext(active);
        }
    }

    public void inputDown(PartColor color)
    {
        if (color == _playerColor.Color)
        {
            ButtonDown.OnNext(true);
        }
    }

    public void inputUp(PartColor color)
    {
        if (color == _playerColor.Color)
        {
            ButtonUp.OnNext(true);
        }
    }

    public void inputMovement(Vector2 movement)
    {
        Movement.OnNext(movement);
    }

    private void Awake()
    {
        var controls = new Controls();
        _playerColor = GetComponent<PlayerColor>();

        //ButtonDown = Observable.EveryUpdate().Select(_ => Input.GetButtonDown(_playerColor.Color.ToString()));
        //ButtonUp = Observable.EveryUpdate().Select(_ => Input.GetButtonUp(_playerColor.Color.ToString()));
        //Button = Observable.EveryUpdate().Select(_ => Input.GetButton(_playerColor.Color.ToString()));
    }
}