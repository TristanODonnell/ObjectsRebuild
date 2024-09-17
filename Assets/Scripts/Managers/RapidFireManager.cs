using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RapidFireManager : MonoBehaviour
{
    [SerializeField] private bool isRapidFire;
    [SerializeField] private Weapon rapidFire;
    [SerializeField] private float rapidFireTime;
    [SerializeField] private Player player;
    
    private Weapon previousWeapon;

    public float rapidFireTimer;
    public UnityEvent RapidFireTimerStart;
    public UnityEvent RapidFireTimerEnd;
    public UnityEvent<float> RapidFireTimerUpdate;
    public float RapidFireTime
    { get { return rapidFireTime; } } 
      

    public bool IsRapidFire
    {
        get { return isRapidFire; }
    }
    public void SetRapidFire(bool value)
    {
        isRapidFire = value;
        Debug.Log("RapidFire status set to " + isRapidFire);
    }


    public void UseRapidFire()
    {
        previousWeapon = player.CurrentWeapon;
        player.ChangeWeapon(rapidFire);
        StartCoroutine(rapidFireCountDown());
    }

    

    public IEnumerator rapidFireCountDown()
    {
        RapidFireTimerStart.Invoke();
        float remainingTime = rapidFireTime;
        while (remainingTime > 0)
        {
            RapidFireTimerUpdate.Invoke(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        player.ChangeWeapon(previousWeapon);
        SetRapidFire(false);
        RapidFireTimerEnd.Invoke();

    }

    
}
