using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slingshot : MonoBehaviour
{
    private const float AnimtionDuration = 1f;
    private const float AnimationForce = 2f;

    [Header("Projectiles")]
    [SerializeField] private Projectile _pepe = null;
    [SerializeField] private Projectile _smiley = null;
    [SerializeField] private Projectile _woman = null;
    private List<Projectile> _projectileStore = null; 
    [Space, Header("Components")]
    [SerializeField] private Launcher _launcher = null;
    [SerializeField] private Transform _source = null;
    [Space, Header("Parameters")]
    [SerializeField, Range(1, 15)] private int _amount = 10;
    [SerializeField, Range(1f, 30f)] private float _slingPower = 10f;

    void Awake()
    {
        _projectileStore = new()
        {
            _pepe,
            _smiley,
            _woman
        };
    }

    IEnumerator Start()
    {      
        for(int i = 0; i < _amount; ++i)
        {
            int index = Random.Range(0, _projectileStore.Count);
            Projectile projectile = _projectileStore[index].GetProjectile(_source);

            yield return LoadProjectile(projectile);
            yield return WaitForShot(projectile);
        }
    }

    private IEnumerator LoadProjectile(Projectile projectile)
    {   
        _launcher.enabled = false;

        yield return projectile.transform.DOJump(_launcher.transform.position,
            AnimationForce, 1, AnimtionDuration).WaitForCompletion(); 

        _launcher.enabled = true; 
    }

    private IEnumerator WaitForShot(Projectile projectile)
    {
        bool isDone = false;
        
        void Shot(Vector2 direction)
        {
            isDone = true;
            projectile.Launch(direction * -_slingPower);
        }

        _launcher.OnRelease += Shot;

        while (!isDone)
        {
            projectile.transform.position = _launcher.transform.position;    
            yield return null;  
        }

        _launcher.OnRelease -= Shot;  
    }
}