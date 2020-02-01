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

    public void inputActive(PartColor color, bool active)
    {
        if (active)
        {
            Debug.Log("Active: " + color);
        }
        if (color == _playerColor.Color)
        {
            Button.OnNext(active);
        }
    }

    public void inputDown(PartColor color)
    {
        Debug.Log("Down: " + color);
        if (color == _playerColor.Color)
        {
            ButtonDown.OnNext(true);
        }
    }

    public void inputUp(PartColor color)
    {
        Debug.Log("Up: " + color);
        if (color == _playerColor.Color)
        {
            ButtonUp.OnNext(true);
        }
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