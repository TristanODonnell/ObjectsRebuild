using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IDamageable
{
    protected Health healthPoints;
    [SerializeField] protected int initialHealthPoints;
    
    [SerializeField] protected float speed;
    [SerializeField] protected Weapon currentWeapon;
    [SerializeField] protected NukeManager nukeManager;
    [SerializeField] protected RapidFireManager rapidFireManager;
    protected Rigidbody2D rigidBody;

    [SerializeField] protected  AudioSource audioSource;
    [SerializeField] protected  AudioClip shootSound;


    public UnityEvent<Weapon> OnWeaponEquipped;
    public Weapon CurrentWeapon
    { get { return currentWeapon; } }

    protected virtual void Awake()
    {
        
    }

    public virtual void CharacterSetup()
    {
        Debug.Log("CharacterSetup called");
        rigidBody = GetComponent<Rigidbody2D>();
        healthPoints = new Health(initialHealthPoints);

        Debug.Log("Initial health points: " + initialHealthPoints);
        Debug.Log("Health points initialized: " + healthPoints.GetHealth());
        healthPoints.OnLifeChanged.AddListener(CheckLife);
    }


    public virtual void Move(Vector2 direction, float angleToRotate)
    {
        rigidBody.AddForce(direction * speed * Time.deltaTime * 1000);
        transform.rotation = Quaternion.Euler(0, 0, angleToRotate);
        // Debug.Log("Character Moving" + direction);
    }

    public virtual void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
        currentWeapon.Shoot(transform.position, transform.rotation, "Enemy");

    }
    

    void CheckLife(int lifeValue)
    { 
        if (lifeValue <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        
        Destroy(gameObject);
    }

    public virtual void GetDamage(int damage)
    {
        healthPoints.DecreaseHealth(damage);
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
        OnWeaponEquipped.Invoke(currentWeapon);
    }    
    public Character()
    {

    } 

    public Character(float speedParameter, int amountofHealth)
    {
        speed = speedParameter;
        initialHealthPoints = amountofHealth;
    }

    public Health GetHealthInformation()
    {
        return healthPoints;
    }

    public void CollectNuke()
    {
        nukeManager.NukeCounterIncrease(1);
        Debug.Log("Nuke is increasing");
    }

    
}
