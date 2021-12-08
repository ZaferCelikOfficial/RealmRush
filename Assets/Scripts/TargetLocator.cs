using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform weapon;
    Transform target;
    [SerializeField] float RangeofTower = 15;
    [SerializeField] ParticleSystem ProjectileParticles;
    void Start()
    {
        target = FindObjectOfType<Enemy>().transform;
        weapon = this.transform;
    }

   
    void Update()
    {
        SearchClosestTarget();
        AimWeapon();
    }

    private void AimWeapon()
    {
        float targetdistance = Vector3.Distance(transform.position, target.position);
        if (targetdistance < RangeofTower) 
        {
            Attack(true);
        }
        else { Attack(false); }
        weapon.LookAt(target);
    }

    void SearchClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform ClosestTarget = null;
        float MaxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetdistance= Vector3.Distance(transform.position, enemy.transform.position);
            if (targetdistance < MaxDistance) { ClosestTarget = enemy.transform;MaxDistance = targetdistance; }
        }
        target = ClosestTarget;    
    }
    void Attack(bool isActive)
    {
        var emissionmodule = ProjectileParticles.emission;
        emissionmodule.enabled= isActive;
    }
}
