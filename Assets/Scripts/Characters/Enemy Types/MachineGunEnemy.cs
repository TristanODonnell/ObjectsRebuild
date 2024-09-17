using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{

    [SerializeField] private int bulletPerBurst;
    [SerializeField] private int burstCooldown;
    private bool isCoolingDown = false;
    
    private int bulletsShot;
    private float burstTimer;
    protected override void Awake()
    {
        
    }

    public override void CharacterSetup()
    {
        base.CharacterSetup();
        player = FindObjectOfType<Player>();
        timer = shootCooldown;
    }
    public MachineGunEnemy(float speedParam, int touchDamage, int healthPoints) : base(speedParam, touchDamage, healthPoints)
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
                isCoolingDown = false;
                burstTimer = 0;
                bulletsShot = 0;
                Move(directionToThePlayer.normalized, Mathf.Atan2(directionToThePlayer.y, directionToThePlayer.x) * Mathf.Rad2Deg);
            }
            else // enemy is close to the target
            {
                if(isCoolingDown) //THE BURST HAS SHOT, LONGER COOLDOWN
                {
                    burstTimer += Time.deltaTime;
                    if (burstTimer >= burstCooldown)
                    {
                        isCoolingDown =false;
                        burstTimer = 0;
                        bulletsShot = 0;
                    }
                }
                //damaging  the player here
                timer += Time.deltaTime;
                if (timer >= shootCooldown && bulletsShot < bulletPerBurst)
                {
                    if (canShoot)
                    {
                        audioSource.PlayOneShot(shootSound);
                        Shoot();
                    }
                    
                    bulletsShot++;
                    timer = 0f;

                    if (bulletsShot >= bulletPerBurst)
                    {
                        isCoolingDown = true;
                    }
                }

                

            

            }
        }
    }



    public override void Shoot()
    {
        
        currentWeapon.Shoot(transform.position, transform.rotation, "Player");
        
       
                                                
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
