using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    [SerializeField] private float despawnTime;
    public static PickupEvent OnPickup = new PickupEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character picker = collision.attachedRigidbody.GetComponent<Character>();
        if (picker != null)
        {
            
            //OnPickup.Invoke(picker, this);
            PickMe(picker);
        }
        
    }

    

    public virtual void PickMe(Character character)
    {
        Destroy(gameObject);
    }



    public void StartDespawn()
    {
        StartCoroutine(DespawnAfterDelay());
    }

    private IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
 