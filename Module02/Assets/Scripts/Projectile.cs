using System.Collections;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage = 1;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        StartCoroutine(Lifetime());
    }

    public void SetDamage(float damage)
    {
        this.damage *= damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
