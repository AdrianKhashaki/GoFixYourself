using System;
using UniRx;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _hammerJoint;
    [SerializeField] private float _hingeDeadzone;
    [SerializeField] private float _swingSpeed;
    [SerializeField] private float _swingTorque;
    [SerializeField] private float _retractSpeed;
    [SerializeField] private float _retractTorque;
    [SerializeField] private float _deadzoneTorque;
    [SerializeField] private float _swingTime;
    private Controllable _controllable;


    private void Awake()
    {
        _controllable = GetComponent<Controllable>();
    }
    
    private void Start()
    {
        Observable
            .Interval(TimeSpan.FromSeconds(_swingTime))
            .Select(interval =>
            {
                var value = interval % 2 == 0;
                Debug.Log($"hammer value: {value}");
                return value;
            })
            .CombineLatest(Observable.EveryUpdate(), (value, _) => value)
            .Where(_ => _controllable.IsControllable)
            .Subscribe(SwingHammer)
            .AddTo(this);
    }

    private void SwingHammer(bool on)
    {
        KickMotor(on, _hammerJoint, true);
    }

    private void KickMotor(bool on, HingeJoint2D joint, bool hammer)
    {
        var motor = joint.motor;
        var distanceToMax = Mathf.Abs(joint.jointAngle - joint.limits.max);
        var distanceToMin = Mathf.Abs(joint.jointAngle - joint.limits.min);

        var factor = hammer ? -1 : 1;

        if (on && distanceToMin > _hingeDeadzone)
        {
            motor.maxMotorTorque = _swingTorque;
            motor.motorSpeed = factor * _swingSpeed;
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