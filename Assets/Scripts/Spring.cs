using System;
using UniRx;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Rigidbody2D Top;
    public Rigidbody2D Bottom;
    public float Force;

    private void Start()
    {
        GetComponent<PlayerInput>().Button
            .Where(down => down && IsControllable)
            .Subscribe(_ => CompressSpring())
            .AddTo(gameObject);
    }

    private bool IsControllable
    {
        get
        {
            var controllableComponent = GetComponent<Controllable>();
            return controllableComponent != null && controllableComponent.IsControllable;
        }
    }

    private void CompressSpring()
    {
        Top.AddForce((Bottom.position - Top.position).normalized * Force);
        Bottom.AddForce((Top.position - Bottom.position).normalized * Force);
    }
}
