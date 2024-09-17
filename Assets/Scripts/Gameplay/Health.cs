using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health 
{
    public int healthPoints;
    public UnityEvent<int> OnLifeChanged;
    public UnityEvent OnDie;
    public int DecreaseHealth()
    {
       return DecreaseHealth(1);
    }
    
    public int GetHealth()
    { return healthPoints; }

    public int DecreaseHealth(int damage)
    {
        Debug.Log("Decreasing Health");
        healthPoints = Mathf.Max(0, healthPoints - damage);
        if (healthPoints <= 0)
        {
            OnDie.Invoke();
            
        }
        OnLifeChanged.Invoke(healthPoints);
        return healthPoints;
    }
    public int IncreaseHealth()
    {
        return IncreaseHealth(1);
    }
     
    public int IncreaseHealth(int toAdd)
    {
        Debug.Log("Increasing Health");
        healthPoints += toAdd;
        OnLifeChanged.Invoke(healthPoints);
        return healthPoints;
    } 
    public Health(int maxHealth)
    {
        healthPoints = maxHealth;
        OnLifeChanged = new UnityEvent<int>();
        OnDie = new UnityEvent();

        OnLifeChanged.Invoke(healthPoints);
    }

}
