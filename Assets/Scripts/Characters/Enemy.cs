using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : Character
{
   // public EnemyType state;

    [SerializeField] protected float attackDistance;
    private int touchDamage;
    private protected Player player;
    private protected float timer;
    [SerializeField] protected float shootCooldown;
    protected bool canShoot = false;
    protected override void Awake()
    {
        //base.Awake();
        //player = FindObjectOfType<Player>();
        //timer = shootCooldown; // enemy attacks at the start then initiates timed attacks
    }

    public override void CharacterSetup()
    {
        base.CharacterSetup();
        player = FindObjectOfType<Player>();
        timer = shootCooldown;
    }
    public void SetUpEnemy(int health, float speed, int damage)
    {
        /*
       switch (state)
        {
            case EnemyType.Idle:
                //STARTS THE CODE
                Debug.Log("IDLE");
                break; //ENDS HERE 
            case EnemyType.Patrolling:
                Debug.Log("patrolling");
                break;
            case EnemyType.Investigating:
                Debug.Log("investigating");
                break;
            case EnemyType.Chasing:
                Debug.Log("chasing");
                break;
        }

        int num;
        */


    }
    private void Update()
    {   if(player != null)
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
                timer += Time.deltaTime;
                if (timer >= shootCooldown) //every 2 seconds 
                {
                    if (canShoot) 
                    {
                        Debug.Log("Shooting allowed!");
                        Shoot();
                    }
                    else
                    {
                        Debug.Log("Shooting not allowed!");
                    }
                    timer = 0;
                } 

                // rigidBody.velocity = Vector2.zero;
            }
        }
       
    }
    
    
    public override void Shoot()
    {
        
            player.GetDamage(1);
        
        
        //weapon.Shoot(transform.position, transform.rotation, "Player"); //logic for tag, enemy shooting at player 
    }

    

    public override void Move(Vector2 direction, float angleToRotate)
    {
        base.Move(direction, angleToRotate);
       // Debug.Log("Moving Enemy with Speed of " + speed.ToString());
    }

    protected override void Die()
    {
        base.Die();
      //  GameManager.singleton.AddScore();
    }

    

    public Enemy(float speedParam, int touchDamage, int healthPoints) : base(speedParam, healthPoints)
    {
        this.touchDamage = touchDamage;
    }

    public virtual void AllowShooting()
    {
        canShoot = true;
    }

    public virtual void DisallowShooting()
    {
        canShoot = false;
    }
}
