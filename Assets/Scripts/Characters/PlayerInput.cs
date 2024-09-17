using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    [SerializeField] private Vector2 directionToFace;
    [SerializeField] private float angleToTurn;
    private Player myPlayer;
    
    private NukeManager nukeManager;
    private RapidFireManager rapidFireManager;
    
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<Player>();
        nukeManager = myPlayer.GetComponentInChildren<NukeManager>();
        rapidFireManager = myPlayer.GetComponentInChildren<RapidFireManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");
        Vector2 finalDirection = new Vector2 (HorizontalDirection, verticalDirection);

        directionToFace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angleToTurn = Mathf.Atan2(directionToFace.y - transform.position.y, directionToFace.x - transform.position.x) * Mathf.Rad2Deg;

        myPlayer.Move(finalDirection, angleToTurn);

        NukeInput();

        if (rapidFireManager.IsRapidFire)  
        {
            if (Input.GetMouseButton(0)) //holding down to shoot
            {
                Debug.Log("Rapid Fire: Shooting");
                myPlayer.Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //default click to shoot
            {
                myPlayer.Shoot();
            }
        }
        


    }

    
    
    public void NukeInput()
    {
        if (Input.GetMouseButtonDown(1) )
        {
            Debug.Log("button pressed");
            nukeManager.UseNuke();
            
        }
    } 
    
}
