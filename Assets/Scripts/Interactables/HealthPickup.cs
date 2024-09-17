using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] private int amountofHealth;
    public override void PickMe(Character character)
    {
        if (character is Player)
        {
            character.GetHealthInformation().IncreaseHealth(amountofHealth);
            base.PickMe(character);
        }
            
    }

    
}
