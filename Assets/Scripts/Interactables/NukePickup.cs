using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NukePickup : Pickup
{

    //The player can pick up nukes, display how many the player has using UI (top left in the example image below).
    //When the player right-clicks, the nuke destroys all the entities in the scene (include any pickups and spare the player, obviously).
    // Start is called before the first frame update
    
   

    private void Start()
    {
        
    }

    

    public override void PickMe(Character character)
    {
        
        
        if (character is  Player)
        {
            character.CollectNuke();
            Debug.Log("nuke collected");
            base.PickMe(character);
        }
        
    }  
     
}
