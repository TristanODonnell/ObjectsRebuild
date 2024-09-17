using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePickup : Pickup
{
    //When picked, for a limited time, make the player hold the click to shoot bullets at a high rate.
    //Create a UI element that follows the player showing the time left of the high shooting rate

    

    private Weapon previousWeapon;
   
 
    public override void PickMe(Character character)
    {
        if(character is Player player)
        {
            player.RapidFireOn(); // set boolean value to be true and launch player method with manager 
            
            //rapidFireUI.TimerStart();
           
            base.PickMe(character);
        }
            
        
    }

    
}
 