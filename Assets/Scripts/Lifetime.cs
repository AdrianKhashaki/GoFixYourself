using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float LifeTimeInSeconds;
    public float ExplosionForce;
    public float ExplosionRadius;

    private void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(LifeTimeInSeconds)).Subscribe(_ => Explode()).AddTo(this);
    }

    private void Explode()
    {
        var colliderList = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, ExplosionRadius, new ContactFilter2D().NoFilter() , colliderList);
        foreach (var collider2D1 in colliderList)
        {
            var rb = collider2D1.GetComponentInParent<Rigidbody2D>();
            if (rb == null || rb.gameObject == gameObject)
                continue;
            rb.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
        }
        Destroy(gameObject, .1f);
    }
}