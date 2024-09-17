using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{

    

    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(gameObject);
       // weapon = new Weapon(bulletPrefab, 1, 8.5f);
    }

    public override void CharacterSetup()
    {

        base.CharacterSetup();
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
    }

    protected override void Die()
    {
        base.Die();
        GameManager.singleton.StopGame();
        Debug.Log("RESETTING GAME");

    }

    public override void Move(Vector2 direction, float angleToRotate)
    {
        
        base.Move(direction, angleToRotate);
        //Debug.Log("moving Player with speed of" + speed.ToString());
    }

    public override void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
        currentWeapon.Shoot(transform.position, transform.rotation, "Enemy");
    }

  
    public  void RapidFireOn()
    {
        rapidFireManager.SetRapidFire(true);
        rapidFireManager.UseRapidFire();
    }


    
    public Player(float speedParameter, int amountOfHealth) : base(speedParameter, amountOfHealth)
    {

    }
}
