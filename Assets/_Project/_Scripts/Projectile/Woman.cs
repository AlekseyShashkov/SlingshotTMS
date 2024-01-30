using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : Projectile
{
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
    }

    public override void Launch(Vector2 direction)
    {
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
        
        StartCoroutine(DestroyAfterTime(1f));
    }

    public override Projectile GetProjectile(Transform source)
    {
        return Instantiate(this, source.position, Quaternion.identity);
    }
}