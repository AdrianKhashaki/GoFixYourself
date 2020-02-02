using UniRx;
using UnityEngine;

[RequireComponent(typeof(CustomPlayerInput))]
public class Leg : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _kneeJoint;
    [SerializeField] private HingeJoint2D _footJoint;
    [SerializeField] private float _footHingeDeadzone;
    [SerializeField] private float _footKickSpeed;
    [SerializeField] private float _footKickTorque;
    [SerializeField] private float _footRetractSpeed;
    [SerializeField] private float _footRetractTorque;
    [SerializeField] private float _footDeadzoneTorque;

    [SerializeField] private float _kneeHingeDeadzone;
    [SerializeField] private float _kneeKickSpeed;
    [SerializeField] private float _kneeKickTorque;
    [SerializeField] private float _kneeRetractSpeed;
    [SerializeField] private float _kneeRetractTorque;
    [SerializeField] private float _kneeDeadzoneTorque;

    private CustomPlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<CustomPlayerInput>();
    }

    private void Start()
    {
        _playerInput.Button
            .Subscribe(KickLeg)
            .AddTo(this);
    }

    private void KickLeg(bool on)
    {
        if (on) {
            Debug.Log("Kikcing");
        }
        KickMotor(on, _kneeJoint, true, _kneeHingeDeadzone, _kneeKickTorque, _kneeKickSpeed, _kneeRetractTorque, _kneeRetractSpeed, _kneeDeadzoneTorque);
        KickMotor(on, _footJoint, false, _footHingeDeadzone, _footKickTorque, _footKickSpeed, _footRetractTorque, _footRetractSpeed, _footDeadzoneTorque);
    }
    
    private void KickMotor(bool on, HingeJoint2D joint, bool leg, float hingeDeadzone, float kickTorque, float kickSpeed, float retractTorque, float retractSpeed, float deadzoneTorque)
    {
        var motor = joint.motor;
        var distanceToMax = Mathf.Abs(joint.jointAngle - joint.limits.max);
        var distanceToMin = Mathf.Abs(joint.jointAngle - joint.limits.min);

        var factor = leg ? 1 : -1;
        
        if (on && distanceToMin > hingeDeadzone)
        {
            motor.maxMotorTorque = kickTorque;
            motor.motorSpeed = factor *kickSpeed;
        }
        else if (!on && distanceToMax > hingeDeadzone)
        {
            motor.maxMotorTorque = retractTorque;
            motor.motorSpeed = factor * retractSpeed;
        }
        else
        {
            motor.maxMotorTorque = deadzoneTorque;
            motor.motorSpeed = 0f;
        }

        joint.motor = motor;
    }
}