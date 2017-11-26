using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuController : MonoBehaviour {
    //MainMenu
    public Canvas MainMenu;
    public Button newB;
    public Button scoreB;
    public Button settingsB;
    public Button exitB;
    
    //Settings
    public Canvas Settings;
    public Button exitsetsB;
    public Dropdown qualityD;
    public Dropdown resolutionD;
    Resolution[] resolutions;
    string[] qualities;
    public Toggle fullscreen;

    //Sound
    public Slider sound;
    public Text per;

    private AssetBundle loaded;
    // Use this for initialization
    void Start () {
        MainMenu.enabled = true;
        Settings.enabled = false;
        newB.onClick.AddListener(NewPress);
        scoreB.onClick.AddListener(ScorePress);
        settingsB.onClick.AddListener(SettingsPress);
        exitsetsB.onClick.AddListener(ExitSettingsPress);
        exitB.onClick.AddListener(ExitPress);
        resolutions = Screen.resolutions;
        qualities = QualitySettings.names;
        qualityD.options.Clear();
        resolutionD.options.Clear();
        Resolution res = Screen.currentResolution;
        int r = 0;
        int qu = 0;
        for (int x = 0; x < resolutions.Length; x++)
        {
            Dropdown.OptionData d = new Dropdown.OptionData();
            d.text = resolutions[x].width + " x " + resolutions[x].height;
            resolutionD.options.Add(d);
            resolutionD.value = x;
            if (resolutions[x].width == res.width || resolutions[x].height == res.height)
            {
                r = x;
            }
        }
        for (int x = 0; x < qualities.Length; x++)
        {
            Dropdown.OptionData d = new Dropdown.OptionData();
            d.text = qualities[x];
            qualityD.options.Add(d);
            qualityD.value = x;
            
        }
        
        resolutionD.value = r;
        switch (QualitySettings.currentLevel)
        {
            case QualityLevel.Fastest:
                qualityD.value =  0;
                break;
            case QualityLevel.Fast:
                qualityD.value = 1;
                break;
            case QualityLevel.Simple:
                qualityD.value = 2;
                break;
            case QualityLevel.Good:
                qualityD.value = 3;
                break;
            case QualityLevel.Beautiful:
                qualityD.value = 4 ;
                break;
            case QualityLevel.Fantastic:
                qualityD.value = 5;
                break;
        }
        
        qualityD.onValueChanged.AddListener(ChangeQuality);
        resolutionD.onValueChanged.AddListener(ChangeRes);
        fullscreen.onValueChanged.AddListener(FullScreenToggle);
        sound.onValueChanged.AddListener(ChangeSound);
    }

   

    // Update is called once per frame
    void Update () {
		
	}
    /// <summary>
    /// Method to start a new game
    /// </summary>
    void NewPress()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    /// <summary>
    /// Method to check the scoreboard
    /// </summary>
    void ScorePress()
    {
        //TO ADD: add a scoreboard
    }
    /// <summary>
    /// Method to go to settings menu
    /// </summary>
    void SettingsPress()
    {
        Settings.enabled = true;
        MainMenu.enabled = false;
    }

    /// <summary>
    /// Method to go back to main menu
    /// </summary>
    void ExitSettingsPress()
    {
        Settings.enabled = false;
        MainMenu.enabled = true;
    }
    /// <summary>
    /// Method to change resolution
    /// </summary>
    void ChangeRes(int val)
    {
        Screen.SetResolution(resolutions[resolutionD.value].width, resolutions[resolutionD.value].height, fullscreen.IsActive());
    }
    /// <summary>
    /// Method to go change quality
    /// </summary>
    void ChangeQuality(int val)
    {
        QualitySettings.SetQualityLevel(val);
    }
    /// <summary>
    /// Method to toggle fullscreen
    /// </summary>
    /// <param name="full">bool to toggle fullscreen by</param>
    private void FullScreenToggle(bool full)
    {
        Screen.fullScreen = full;
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
    /// Method to exit the application
    /// </summary>
    void ExitPress()
    {
        Application.Quit();
    }

}
