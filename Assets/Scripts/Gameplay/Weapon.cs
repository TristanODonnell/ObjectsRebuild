using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu]

public class Weapon : ScriptableObject
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] protected int damage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;

    
    public virtual void Shoot()
    {
         
    }
    public virtual void Shoot(Vector2 spawnPos, Quaternion aim, string tag)
    {
        //needs a position (probably from player)
        //direction that player is looking
        Bullet b = GameObject.Instantiate(bulletPrefab, spawnPos, aim);
        b.SetupBullet(damage, bulletSpeed, tag);
        //instantiate new bullet 
    }

    public virtual void StopShooting()
    {
       // Debug.Log("Weapon stopped shooting");
    }
    

    public Weapon()
    {

    }
    public Weapon(Bullet bulletParam, int damageParam, float speedParam) 
    {
        bulletPrefab = bulletParam;
        damage = damageParam;
        bulletSpeed = speedParam;
    }

    
}
