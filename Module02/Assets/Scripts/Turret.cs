using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float reloadSpeed = 1;
    [SerializeField] private float damageMultiplier = 1;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private Transform projectileGroup;

    private Transform currentTarget;
    private float distance;
    private float nearestDistance;
    private float elapsedTime = 0;

    private List<Transform> targets = new List<Transform>();

    void Update()
    {
        ClosestTarget();

        if (currentTarget != null)
        {
            head.transform.up = Vector3.MoveTowards(head.transform.position, currentTarget.position, rotationSpeed * Time.deltaTime) - transform.position;
            nearestDistance = Vector3.Distance(transform.position, currentTarget.position);
        }
        else
        {
            nearestDistance = 1000f;
            elapsedTime = 0f;
        }
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= reloadSpeed)
        {
            elapsedTime -= reloadSpeed;
            if (currentTarget)
            {
                Instantiate(projectilePrefab, muzzle.transform.position, muzzle.rotation, projectileGroup).SetDamage(damageMultiplier);
            }
        }
    }

    void ClosestTarget()
    {
        foreach (Transform target in targets)
        {
            distance = Vector3.Distance(transform.position, target.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                currentTarget = target;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            targets.Add(collider.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            targets.Remove(collider.transform);
        }
    }
}
