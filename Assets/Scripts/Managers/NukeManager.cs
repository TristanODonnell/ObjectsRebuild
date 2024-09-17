using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class NukeManager : MonoBehaviour
{
    
    private int nukeCount = 0;

    public UnityEvent<int> NukeCountStatus; 

    public void NukeCounterIncrease(int amount)
    {
        nukeCount += amount;
        Debug.Log("Nuke count changed to: " + nukeCount);
        NukeCountStatus.Invoke(nukeCount);
    }

    public void NukeCounterDecrease(int amount)
    {
        nukeCount -= amount;
        Debug.Log("nuke counter decreased");
        NukeCountStatus.Invoke(nukeCount);
    }

    public int GetNukeCount()
    {
        return nukeCount;
       
    }
    public void UseNuke()
    {
        if (GetNukeCount() > 0)
        {
            Debug.Log("nuke used");
            NukeDetonate();
            NukeCounterDecrease(1);

        }
        else
        {
            Debug.Log("No nukes available!");
        }

    }

        public void NukeDetonate()
    {
        DestroyObjectsWithTag("Pickup");
        DestroyObjectsWithTag("Enemy");
    }

    public void DestroyObjectsWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToDestroy)
        {

            Destroy(obj);
        }
    }

    
}

