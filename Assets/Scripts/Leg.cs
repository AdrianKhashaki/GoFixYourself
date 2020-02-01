using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
public class Leg : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _kneeJoint;
    [SerializeField] private HingeJoint2D _footJoint;
    [SerializeField] private float _hingeDeadzone;
    [SerializeField] private float _kickSpeed;
    [SerializeField] private float _kickTorque;
    [SerializeField] private float _retractSpeed;
    [SerializeField] private float _retractTorque;
    [SerializeField] private float _deadzoneTorque;
    
    private CustomPlayerInput _playerInput;
    private Controllable _controllable;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
        _controllable = GetComponent<Controllable>();
    }

    private void Start()
    {
        _playerInput.Button
            .Where(_ => _controllable.IsControllable)
            .Subscribe(KickLeg)
            .AddTo(this);
    }

    private void KickLeg(bool on)
    {
        KickMotor(on, _kneeJoint, true);
        KickMotor(on, _footJoint, false);
    }
    
    private void KickMotor(bool on, HingeJoint2D joint, bool leg)
    {
        var motor = joint.motor;
        var distanceToMax = Mathf.Abs(joint.jointAngle - joint.limits.max);
        var distanceToMin = Mathf.Abs(joint.jointAngle - joint.limits.min);

        var factor = leg ? 1 : -1;
        
        if (on && distanceToMin > _hingeDeadzone)
        {
            motor.maxMotorTorque = _kickTorque;
            motor.motorSpeed = factor *_kickSpeed;
        }
        else if (!on && distanceToMax > _hingeDeadzone)
        {
            motor.maxMotorTorque = _retractTorque;
            motor.motorSpeed = factor * _retractSpeed;
        }
        else
        {
            motor.maxMotorTorque = _deadzoneTorque;
            motor.motorSpeed = 0f;
        }

        joint.motor = motor;
    }
}