﻿using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Controllable))]
public class Spinner : MonoBehaviour
{
    public HingeJoint2D SpinnerHinge;
    private PlayerInput _playerInput;
    private Controllable _controllable;

    public float MotorSpeed;
    public float MotorTorque;
    public float OffTorque;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controllable = GetComponent<Controllable>();
    }

    private void Start()
    {
        _playerInput.Button
            .Where(_ => _controllable.IsControllable)
            .DistinctUntilChanged()
            .Subscribe(Spin)
            .AddTo(this);
    }

    private void Spin(bool on)
    {
        var spinnerHingeMotor = SpinnerHinge.motor;
        spinnerHingeMotor.motorSpeed = on ? MotorSpeed : 0f;
        spinnerHingeMotor.maxMotorTorque = on ? MotorTorque : OffTorque;
        SpinnerHinge.motor = spinnerHingeMotor;
    }
}