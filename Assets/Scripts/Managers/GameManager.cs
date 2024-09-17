using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public Camera mainCamera;
    [SerializeField] private NukeManager nukeManager;

    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PickupSpawner pickupSpawner;

    [SerializeField] private float initialSpawnRate = 3f;
    [SerializeField] private float spawnRateDecreaseInterval;
    [SerializeField] private float minimumSpawnRate = 0.5f;
    //private int nukeCount = 0;

    //public NukeManager NukeManager { get; private set; }
    private void Awake()
    {
        singleton = this;
        DontDestroyOnLoad(gameObject);

        
        //if (nukeManager != null)
        // {
        //    NukeManager = nukeManager;
        // }
        //Player p = FindObjectOfType<Player>();
        //   p.GetHealthInformation().OnDie.AddListener(StopGame);
    } 

   
    public void StartGame()
    {
        
        GameObject myPlayer = Instantiate(playerPrefab);
        Player player = myPlayer.GetComponent<Player>();
        if (player != null )
        {
            player.CharacterSetup();
        }
        else
        {
            Debug.LogError("Player component not found on the instantiated player prefab.");
        }
        
       
        uiManager.StartGame(); 
        StartCoroutine(SpawnEnemiesCoroutine()); 
        pickupSpawner.StartSpawner();
    }


    public void StopGame()
    {
        StopAllCoroutines();
        scoreManager.RegisterHighScore();
        uiManager.GameOver();
        
        nukeManager.NukeDetonate();
    }

    public void AddScore()
    {
       // scoreManager.IncreaseScore();
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        //SPAWN RATE DECREASES OVER TIME , ADJUST PARAMETERS IN INSPECTOR 
        float currentSpawnRate = initialSpawnRate;
        float timeSinceLastDecrease = 0f;

        yield return new WaitForSeconds(currentSpawnRate);

        while (true)
        {

            timeSinceLastDecrease += currentSpawnRate;

            if (timeSinceLastDecrease >= spawnRateDecreaseInterval)
            {
                currentSpawnRate = Mathf.Max(minimumSpawnRate, currentSpawnRate - 0.5f); //Decreasing spawn rate
                timeSinceLastDecrease = 0f;

                Debug.Log($"Spawn rate decreased to: {currentSpawnRate}");
            }

            yield return new WaitForSeconds(currentSpawnRate);

            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // random transform from predetermined list 

            //or

            // Vector2 randomPosition = Random.insideUnitCircle * 10f; random inside unit circle 

            Enemy selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Enemy tempEnemy = Instantiate(selectedEnemyPrefab, randomPoint.position, Quaternion.identity);
            if (tempEnemy != null)
            {
                tempEnemy.CharacterSetup();
                tempEnemy.GetHealthInformation().OnDie.AddListener(scoreManager.IncreaseScore);

                

            }
            else
            {
                Debug.LogError("ENEMY COMPONENT ISSUE");
            }
            //tempEnemy.SetUpEnemy(2, 4, 1);
        }

    }
    




}
