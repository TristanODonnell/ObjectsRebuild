using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private Weapon newWeapon;

    public override void PickMe(Character character)
    {
        if (character is  Player)
        {
            character.ChangeWeapon(newWeapon);
            base.PickMe(character);
        }
       
    }
}
