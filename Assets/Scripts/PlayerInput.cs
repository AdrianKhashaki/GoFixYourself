﻿using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlayerColor))]
public class PlayerInput : MonoBehaviour
{
    private PlayerColor _playerColor;

    public IObservable<bool> ButtonDown;
    public IObservable<bool> ButtonUp;
    public IObservable<bool> Button;
    
    private void Awake()
    {
        _playerColor = GetComponent<PlayerColor>();
        ButtonDown = Observable.EveryUpdate().Select(_ => Input.GetButtonDown(_playerColor.Color.ToString()));
        ButtonUp = Observable.EveryUpdate().Select(_ => Input.GetButtonUp(_playerColor.Color.ToString()));
        Button = Observable.EveryUpdate().Select(_ => Input.GetButton(_playerColor.Color.ToString()));
    }
}