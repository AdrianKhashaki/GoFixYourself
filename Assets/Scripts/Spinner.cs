using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
public class Spinner : MonoBehaviour
{
    public HingeJoint2D SpinnerHinge;
    private CustomPlayerInput _playerInput;

    private bool reverse;
    public float MotorSpeed;
    public float MotorTorque;
    public float OffTorque;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
    }

    private void Start()
    {
        _playerInput.Button
            .Subscribe(Spin)
            .AddTo(this);
        _playerInput.Movement
            .DistinctUntilChanged()
            .Subscribe(Reverse)
            .AddTo(this);
    }

    private void Spin(bool on)
    {
        var spinnerHingeMotor = SpinnerHinge.motor;
        spinnerHingeMotor.motorSpeed = on ? MotorSpeed : 0f;
        if(reverse)
        {
            spinnerHingeMotor.motorSpeed = spinnerHingeMotor.motorSpeed * -1.00f;
        }
        spinnerHingeMotor.maxMotorTorque = on ? MotorTorque : OffTorque;
        SpinnerHinge.motor = spinnerHingeMotor;
    }

    private void Reverse(Vector2 movement)
    {
        var spinnerHingeMotor = SpinnerHinge.motor;
        if (movement.x < 0)
        {
            reverse = true;
        }
        else
        {
            reverse = false;
        }
    }
}