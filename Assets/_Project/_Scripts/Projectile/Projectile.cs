using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;

    protected IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    public abstract void Launch(Vector2 direction);
    public abstract Projectile GetProjectile(Transform source);
}