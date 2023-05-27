using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private float range = 15f;
    [SerializeField] private ParticleSystem projectileParticle;
    private Transform target;
    
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        // TODO refactor this later 
        var enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        Attack(targetDistance <= range);
        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        var projectileParticleEmission = projectileParticle.emission;
        projectileParticleEmission.enabled = isActive;
    }
}