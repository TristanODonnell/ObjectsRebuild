using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperEnemy : Enemy
{

    [SerializeField] private float retreatDistance;
    private LineRenderer lineRenderer;



    protected override void Awake()
    {
        
    }

    public override void CharacterSetup()
    {
        base.CharacterSetup();
        player = FindObjectOfType<Player>();
        timer = shootCooldown;
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    public SniperEnemy(float speedParam, int touchDamage, int healthPoints) : base(speedParam, touchDamage, healthPoints)
    {

    }



    private void Update()
    {

        //ADD LOGIC HERE FOR LASER TRACKING, shooting, etc 
        if (player != null)
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            Vector2 directionToThePlayer = player.transform.position - transform.position;
            float angleToPlayer = Mathf.Atan2(directionToThePlayer.y, directionToThePlayer.x) * Mathf.Rad2Deg;

            if (canShoot)
            {
                EnemyLaserSystem(distance); //laser render method 
            }
            
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleToPlayer ));

            if (distance > attackDistance) //approach player
            {

                Move(directionToThePlayer.normalized, angleToPlayer);
            }
            else if (distance < retreatDistance) // retreating from player 
            {

                Move(-directionToThePlayer.normalized, angleToPlayer);
            }
            else // enemy is at attack distance 
            {

                //damaging  the player here
                timer += Time.deltaTime;
                if (timer >= shootCooldown)
                {

                    if (canShoot)
                    {
                        audioSource.PlayOneShot(shootSound);
                        Shoot();
                    }
                    
                    timer = 0;

                    
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleToPlayer ));
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

    public void EnemyLaserSystem(float distance)
    {
        
            if (lineRenderer != null)
            {
                lineRenderer.enabled = true;

                if (distance <= attackDistance && distance >= retreatDistance)
                {
                    //LINE RENDERING POINTS

                    Vector2 endPosition = player.transform.position;

                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, endPosition);
                }
                else
                {
                    lineRenderer.enabled = false;
                }
            }
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
