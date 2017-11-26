using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Class used to control the game and its states, objects and etc.
/// </summary>
public class GameController : MonoBehaviour {

    public GameObject player; //Holding the player model to feed into enemy AI
    public GameObject Charger; //Holding the prefab for the charger enemy
    public GameObject Shooter; //Holding the prefab for the Shooter enemy
    public Text objective; //UI element to display amount of enemies
    public Text wavetxt; //UI element to display wave count
    public Image Arrow; //Arrow tracking enemy
    private List<Image> ArrowList; //list of arrows
    private PlayerController playerController;
    private PlayerWeapon playerWeapon;
    public CanvasGroup hud;
    public Canvas pause; //canvas holding the pause menu
    private PauseController pauseC; //script controlling hte pause menu
    private LevelGenerator lg; //Script controlling the level generation

    List<GameObject> Enemies;
    int waveCount = 0;
    float cooldown = 0f; //Float to distance enemy spawns
    bool spawning = false;
    int CharCount, ShotCount = 0;
    Vector3 wavespw;
    /// <summary>
    /// Initialization of GameController
    /// </summary>
    void Start()
    {
        Enemies = new List<GameObject>();
        ArrowList = new List<Image>();
        playerController = player.GetComponent<PlayerController>();
        playerWeapon = playerController.weapon.GetComponent<PlayerWeapon>();
        pauseC = pause.GetComponent<PauseController>();
        lg = this.GetComponentInParent<LevelGenerator>();
        lg.LevelGenerate();
        waveCount = 0;
    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    private void Update()
    {
        UpdateList();
        if (Enemies.Count == 0 && spawning != true)
        {
            InitiateWave();
        }

        objective.text = "Enemies Remaining: " + Enemies.Count;

        if (spawning)
        {
            if (CharCount > 0)
            {
                if (Time.time > cooldown)
                {
                    GenerateCharger(1, wavespw);
                    CharCount--;
                    cooldown = Time.time + 2f;
                }
            }
            else if (ShotCount > 0)
            {
                if (Time.time > cooldown)
                {
                    GenerateShooter(1, wavespw);
                    ShotCount--;
                    cooldown = Time.time + 2f;
                }
            }
            if (ShotCount == 0 && CharCount == 0)
            {
                spawning = false;
            }

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            if (!pauseC.Paused)
            {
                Time.timeScale = 0f;
                pauseC.Paused = true;
            }
        }

    }
    /// <summary>
    /// Method to Initiate a new Enemy Wave
    /// </summary>
    private void InitiateWave()
    {
        waveCount= waveCount + 1;
        wavespw = lg.randomSpawnPoint();
        spawning = true;
        CharCount = 3 * waveCount;
        ShotCount = 1 * waveCount;
        for (int x = 0; x < (waveCount-1); x++)
        {
            lg.generateHealthDrop();
        }
        wavetxt.text = "Wave " + waveCount;
    }

    /// <summary>
    /// Removes dead Enemies from the list
    /// </summary>
    private void UpdateList()
    {
        foreach (GameObject g in Enemies)
        {
            if (g == null)
            {
                Enemies.Remove(g);
            }
        }
    }
    /// <summary>
    /// Removes leftover arrows
    /// </summary>
    private void TrackEnemies()
    {
        foreach (Image i in ArrowList)
        {
            if (i == null)
            {
                ArrowList.Remove(i);
            }
        }
    }
    /// <summary>
    /// Method used to create a Charger Enemy
    /// </summary>
    private void GenerateCharger(int x, Vector3 spw)
    {
        for (int f = 0; f < x; f++)
        {
            GameObject newCharger = Instantiate(Charger, spw, player.transform.rotation);
            newCharger.GetComponent<EnemyController>().Player = player;
            newCharger.GetComponent<AI>().enemy = newCharger;
            Enemies.Add(newCharger);
            Image newArrow = Instantiate(Arrow, hud.transform);
            newArrow.GetComponent<ArrowTracking>().Enemy = newCharger;
            newArrow.GetComponent<ArrowTracking>().Arrow = newArrow;
            ArrowList.Add(newArrow);
        }
        
       
    }
    /// <summary>
    /// Method used to create a Shooter Enemy
    /// </summary>
    private void GenerateShooter (int x, Vector3 spw)
    {
        for (int f = 0; f < x; f++)
        {
            GameObject newShooter = Instantiate(Shooter, spw, player.transform.rotation);
            newShooter.GetComponent<EnemyController>().Player = player;
            newShooter.GetComponent<AI>().enemy = newShooter;
            Enemies.Add(newShooter);
            Image newArrow = Instantiate(Arrow, hud.transform);
            newArrow.GetComponent<ArrowTracking>().Enemy = newShooter;
            newArrow.GetComponent<ArrowTracking>().Arrow = newArrow;
            ArrowList.Add(newArrow);
        }


    }



}
