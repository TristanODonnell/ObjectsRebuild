using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI nukeText;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI rapidFireTimer;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    


    private Player player;
    private NukeManager nukeManager;
    private RapidFireManager rapidFireManager;

    private void Start()
    {
        

        scoreText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        startButton.enabled = true;
        weaponText.gameObject.SetActive(false);
        nukeText.gameObject.SetActive(false) ;
        healthText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        

    } 

    void UpdateLifeText(int life)
    {
        healthText.text = "HEALTH: " + life;
    }
    public void UpdateWeaponText(Weapon weapon)
    {
        weaponText.text = $"WEAPON: {weapon.name}";
    }

    public void UpdateNukeText(int nukeNumber)
    {

        Debug.Log("Updating nuke text to: " + nukeNumber);
        nukeText.text = "NUKES: " + nukeNumber.ToString();
    }
    
    
    public void StartGame() 
    {
        player = FindObjectOfType<Player>();
        player.GetHealthInformation().OnLifeChanged.AddListener(UpdateLifeText);

        nukeManager = player.GetComponent<NukeManager>();
        if (nukeManager != null)
        {
            nukeManager.NukeCountStatus.AddListener(UpdateNukeText);
        }
        
        rapidFireManager = player.GetComponent<RapidFireManager>();
        rapidFireManager.RapidFireTimerStart.AddListener(TimerStart);
        rapidFireManager.RapidFireTimerEnd.AddListener(TimerEnd);
        rapidFireManager.RapidFireTimerUpdate.AddListener(UpdateTimerText);
        rapidFireTimer.gameObject.SetActive(false);

        weaponText.gameObject.SetActive(true);
        player.OnWeaponEquipped.AddListener(UpdateWeaponText);
        UpdateWeaponText(player.CurrentWeapon);

        UpdateLifeText(player.GetHealthInformation().GetHealth());
        healthText.enabled = true;
        healthText.gameObject.SetActive(true );
        nukeText.gameObject.SetActive (true);
        scoreText.gameObject.SetActive(true);


        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        healthText.gameObject.SetActive(false);
        nukeText.gameObject.SetActive(false);
        weaponText.gameObject.SetActive(false);
        scoreText.gameObject .SetActive(false);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButton.enabled = true;
    }
    

    public void UpdateTimerText(float time)
    {
        
        rapidFireTimer.text = "RAPID FIRE: " + time.ToString("F1") + "s";
    }

    public void TimerStart()
    {
        rapidFireTimer.gameObject.SetActive(true);
        
    }

    public void TimerEnd()
    {
        rapidFireTimer.gameObject.SetActive(false);
    }

}
