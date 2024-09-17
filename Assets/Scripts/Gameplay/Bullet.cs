using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float speed;
    protected int damage;
    protected string tagFilter;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    public void SetupBullet(int damageParam, float speedParam, string tagFilter) //add string tagFilter
    {
        speed = speedParam;
        damage = damageParam;
        this.tagFilter = tagFilter;
    }
    //moves projectile forward
    public void MoveProjectile(float damage = 5)
    {
        
    }


    //moves projectile towards a target 
    public void MoveProjectile(Transform target)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag(tagFilter))
        {
            collision.attachedRigidbody.GetComponent<IDamageable>().GetDamage(damage);
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

 
}
