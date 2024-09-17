using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    
    protected override void Awake()
    { 
        
    }


    public override void CharacterSetup()
    {
        base.CharacterSetup();
        player = FindObjectOfType<Player>();
        timer = shootCooldown;
    }
    public ExplodingEnemy(float speedParam, int touchDamage, int healthPoints) : base(speedParam, touchDamage, healthPoints)
    {

    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            Vector2 directionToThePlayer = player.transform.position - transform.position;

            if (distance > attackDistance)
            {

                Move(directionToThePlayer.normalized, Mathf.Atan2(directionToThePlayer.y, directionToThePlayer.x) * Mathf.Rad2Deg);
            }
            else // enemy is close to the target
            {
                //damage the player
                {
                    if (canShoot)
                    {
                        //IF CLOSE TO THE PLAYER , 
                        Destroy(gameObject);// DESTROY OBJECT 
                        Shoot();//DEAL 5 Damage to PLAYER 
                    }
                    
                }
                

                
            }
        }
    }
     
    public override void Shoot()
    {
        
            player.GetDamage(5); //EXPLOSION DAMAGE OF THE PLAYER 
        
        
    }

    public override void Move(Vector2 direction, float angleToRotate)
    {
        base.Move(direction, angleToRotate);
    }

    protected override void Die()

    {
        base.Die();
                                                
    }

    public override void AllowShooting()
    {
        base.AllowShooting();
    }

    public override void DisallowShooting()
    {
        base.DisallowShooting();
    }
}
