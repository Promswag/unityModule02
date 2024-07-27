using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float healthPoints = 1;
    [SerializeField] private float speed = 1;
    [SerializeField] private int damage = 1;
    private Base target;

    public void SetTarget(Base target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Base"))
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(healthPoints);
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
