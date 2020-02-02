using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
public class Spinner : MonoBehaviour
{
    public HingeJoint2D SpinnerHinge;
    private CustomPlayerInput _playerInput;

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