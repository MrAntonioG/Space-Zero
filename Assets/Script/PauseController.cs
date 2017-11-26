using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
    
    public Canvas pauseMenu;
    public Button contB;
    public Button quitB;
    public Button exitB;
    //FOV
    public Slider fov;
    public Text fovVal;
    public Camera main;

    //Sound
    public Slider sound;
    public Text per;

    private bool paused = false; //Boolean checking if game is paused;
    public bool Paused
    {
        get { return paused; }
        set { paused = value; }
    }
	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
        contB.onClick.AddListener(ContinuePress);
        quitB.onClick.AddListener(QuitPress);
        exitB.onClick.AddListener(ExitPress);
        sound.onValueChanged.AddListener(ChangeSound);
        fov.onValueChanged.AddListener(ChangeFOV);
    }
	
	// Update is called once per frame
	void Update () {
		if (paused)
        {
            pauseMenu.enabled = true;
            if (Input.GetKey(KeyCode.Space))
            {
                ContinuePress();
            }
        }
	}
    /// <summary>
    /// Method to continue game if continue button is pressed
    /// </summary>
    void ContinuePress()
    {
        pauseMenu.enabled = false;
        paused = false;
        Time.timeScale = 1f;
    }
    /// <summary>
    /// Method to continue game if quit button is pressed
    /// </summary>
    void QuitPress()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    /// <summary>
    /// Method to continue game if exit button is pressed
    /// </summary>
    void ExitPress()
    {
        Application.Quit();
    }
    /// <summary>
    /// Method to change sound volume
    /// </summary>
    /// <param name="val">value to change volume by</param>
    private void ChangeSound(float val)
    {
        per.text = val.ToString() + "%";
    }
    /// <summary>
    /// Method to change FOV 
    /// </summary>
    /// <param name="val">value to change FOV by</param>
    private void ChangeFOV(float val)
    {
        fovVal.text = val.ToString();
        main.fieldOfView = val;
    }

}
