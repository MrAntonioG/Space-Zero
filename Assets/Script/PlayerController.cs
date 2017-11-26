using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharController {
    //Movement stats
    float movespeed = 0.005f;
    float mousespeed = 0.3f;
    float rotrate = 0.05f;
    float rotcap = 1.3f;
    float speedcap = 1.5f;
    float shipspeed = 0.0f;
    float rotspeed = 0.0f;
    float x_rotation = 0.0f;
    float y_rotation = 0.0f;
    float dec = 3f;
    float nextregen = 0f;
    float boostspeed = 1.75f;
    float invulnerability = 0f;
    int score = 0;

    //Weapon being used by player
    public GameObject weapon;
    public GameObject trail;


    //UI Elements
    public Slider shieldSlider;
    public Slider healthSlider;
    public Slider fuelSlider;
    public Image damageImage;
    public Image crosshair;
    public Image normMode, boostMode;
    public Text scoreTxt;
    public float flashSpeed = 6f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private bool secShot = false;
    protected int damage = 50; //Int holding amount of damage dealt from phyiscally touching enemy
    protected bool damaged = false; //Boolean saying if we got damaged or not
    /// <summary>
    /// Read only, set and/or get the amount of damage dealt
    /// </summary>
    public int Damage
    {
        get { return damage; }
    }
    /// <summary>
    /// Initialization for PlayerController
    /// </summary>
    void Start() {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Confined; //lock mouse movement within the window
        Cursor.visible = false; //Hide cursor;
        //float size = Screen.width / 50;
        //crosshair.rectTransform.sizeDelta = new Vector2(size,size);
        normMode.gameObject.SetActive(true);
        boostMode.gameObject.SetActive(false);

        stats = new PlayerStats();
        stats.InitStats(150, 150);
        //setting up UI
        healthSlider.maxValue = 150;
        healthSlider.value = 150;
        shieldSlider.maxValue = 150;
        shieldSlider.value = 150;
        fuelSlider.maxValue = 100;
        fuelSlider.value = 100;
        stats.IncreaseFuel(100f);
        scoreTxt.text = score.ToString();
    }

    /// <summary>
    /// FixedUpdate called every physics Step
    /// </summary>
    void FixedUpdate()
    {

        //Increasing or Decreasing velocity depending on 
        #region Movement Detection
        if (Input.GetKey("w"))
        {
            if (shipspeed < speedcap)
            {
                shipspeed += movespeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (stats.Fuel > 0)
                {
                    shipspeed = boostspeed;
                    stats.DecreaseFuel(0.6f);
                    normMode.gameObject.SetActive(false);
                    boostMode.gameObject.SetActive(true);
                }                 

            } else if (shipspeed > speedcap)
            {
                shipspeed  = speedcap;
            }
            trail.GetComponent<Renderer>().enabled = true;

        }
        else if (Input.GetKey("s"))
        {
            if (shipspeed > 0.0f)
            {
                shipspeed -= movespeed;
            }
            trail.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            //decelerating ship
            if (shipspeed > 0)
            {
                shipspeed -= (movespeed / dec);
            }
            else if (shipspeed < 0)
            {
                shipspeed = 0.0f;
            }
            trail.GetComponent<Renderer>().enabled = false;
        }
        //Rotation input
        if (Input.GetKey("a"))
        {
            if (rotspeed < rotcap)
            {
                rotspeed += rotrate;
            }

        }
        else if (Input.GetKey("d"))
        {
            if (rotspeed > (-rotcap))
            {
                rotspeed -= rotrate;
            }

        }
        else
        {
            //decelerating rotation
            if (rotspeed > 0)
            {

                rotspeed -= (rotrate / dec);
                if (rotspeed < 0.0f)
                {
                    rotspeed = 0.0f;
                }
            }
            else if (rotspeed < 0)
            {
                rotspeed += (rotrate / dec);
                if (rotspeed > 0.0f)
                {
                    rotspeed = 0.0f;
                }
            }
        } 

        #endregion


        if (Input.GetMouseButton(0))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                weapon.GetComponent<Weapon>().PrimaryShoot();
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (!secShot)
                {
                    weapon.GetComponent<Weapon>().SecondaryShoot();
                    secShot = true;
                }
            }
        } else
        {
            if (secShot)
            {
                weapon.GetComponent<Weapon>().SecondaryShoot();
                secShot = false;
            }
        }
        //Move the ship forward by the shipspeed
        controller.Move(this.gameObject.transform.forward * shipspeed);
        //rotate the ship depending on the rotspeed
        transform.Rotate(0, 0, rotspeed);

        //Camera movement depending on the mouse movement
        x_rotation += Input.GetAxis("Mouse X") * mousespeed;
        y_rotation -= Input.GetAxis("Mouse Y") * mousespeed;

        //rotate the object by the mouse movement
        transform.Rotate(y_rotation * Time.deltaTime, x_rotation * Time.deltaTime, 0);
        //transform.localEulerAngles = new Vector3(y_rotation, x_rotation, 0);
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            stats.IncreaseFuel(0.1f);
            normMode.gameObject.SetActive(true);
            boostMode.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        
        Vector3 aim = Input.mousePosition; //retrieve mouseposition
        aim.z = 50; //Adds distance to mouse position (50 units from the camera)
        crosshair.transform.position = aim;
        weapon.transform.LookAt(Camera.main.ScreenToWorldPoint(aim)); //make weapon aim at the mouseposition through normalization
       
        //Shield Regen
        if (Time.time > nextregen && stats.Shield.Value < stats.Shield.Max)
        {
            stats.Shield.Increase(1);
        }

        //Updating UI elements
        if (damaged)
        {
            damageImage.color = flashColour;
        } else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        shieldSlider.value = stats.Shield.Value;
        healthSlider.value = stats.Health.Value;
        fuelSlider.value = stats.Fuel;
        scoreTxt.text = score.ToString();
    }
    /// <summary>
    /// Method to increase player score
    /// </summary>
    /// <param name="sc">int to increase score by</param>
    public void IncreaseScore(int sc)
    {
        score += sc;
    }

    /// <summary>
    /// Method used to check for collission
    /// </summary>
    /// <param name="hit">Object which has been hit</param>
    protected void OnControllerColliderHit(ControllerColliderHit hit) {

        if (hit.gameObject.tag == "Asteroid")
        {
            hit.collider.gameObject.GetComponent<Asteroid>().Hit(damage);
            Hit(hit.collider.gameObject.GetComponent<Asteroid>().Damage);
        }
        else if (hit.gameObject.tag == "Planet")
        {
            Hit(damage);
        }


    }
    /// <summary>
    /// method used to check for trigger collission
    /// </summary>
    /// <param name="hit">Trigger which has been hit</param>
    protected void OnTriggerEnter(Collider hit)
    { 
        //Increase health by value of health drop
        if (hit.gameObject.tag == "HealthDrop")
        {
            if (stats.Health.Value < stats.Health.Max)
            {
                stats.Health.Increase(hit.gameObject.GetComponent<HealthDrop>().Value);
                Destroy(hit.gameObject);
            }
        }

    }
    /// <summary>
    /// Method initiated when hit by other objects
    /// </summary>
    /// <param name="dmg">amount of damage inflicted</param>
    public override void Hit(int dmg)
    {
        if (Time.time > invulnerability)
        {
            stats.Hit(dmg);
            damaged = true;
            nextregen = Time.time + 3f;
            invulnerability = Time.time + 1.5f;
        }
        if (stats.isDead())
        {
            Destroy(gameObject);
        }
    }  
    
}




