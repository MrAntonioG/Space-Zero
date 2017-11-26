using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : Weapon {
    public GameObject bullet;//hold object to be used as a bullet
    public GameObject rocket;
    public Image secondary;
    public Text cooldownTxt;
    public Camera cam;
    public CanvasGroup hud;
    private bool aiming = false;
    public Image lockImg;
    private List<Image> lockons; //visible enemies at the moment;
    private List<GameObject> visibleEnemies; //visible enemies at the moment;
    public List<GameObject> VisibleEnemies //Get/Set method
    {
        set { visibleEnemies = value; }
        get { return visibleEnemies; }
    }

    float cooldown = 0f;

    /// <summary>
    /// Initializing weapon stats
    /// </summary>
    void Start () {
        fireRate = 0.3f;
        visibleEnemies = new List<GameObject>();
        lockons = new List<Image>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
		if (Time.time < cooldown)
        {
            secondary.fillAmount -= cooldown - Time.time;
            float cd = cooldown - Time.time;
            cooldownTxt.text = cd.ToString();
        } else
        {
            cooldownTxt.text = "";
        }

        if (aiming)
        {
            // Contain whatever is hit by the raycast
            RaycastHit hit;
            Vector3 aim = Input.mousePosition; //retrieve mouseposition
            aim.z = 20; //Adds distance to mouse position (15 units from the camera)

            if (Physics.SphereCast(transform.position, 5f, cam.ScreenToWorldPoint(aim), out hit, 600f))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if (!visibleEnemies.Contains(hit.collider.gameObject))
                    {
                        visibleEnemies.Add(hit.collider.gameObject);
                        Image i = Instantiate(lockImg, hud.transform);
                        i.GetComponent<LockOn>().Enemy = hit.collider.gameObject;
                        lockons.Add(i);

                    }
                }
            }

        }


    }
    /// <summary>
    /// Primary method of shooting is projectile bases
    /// </summary>
    public override void PrimaryShoot()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + fireRate;
            //Quaternion direction = new Quaternion(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), weapon.transform.rotation.z, weapon.transform.rotation.w);
            Instantiate(bullet, transform.position + this.GetComponentInParent<PlayerController>().gameObject.transform.forward, transform.rotation);
        }

    }
    /// <summary>
    /// Secondary method of shooting is lock on
    /// </summary>
    public override void SecondaryShoot()
    {

        if (Time.time > cooldown)
        {
            if (!aiming && visibleEnemies.Count == 0)
            {
                aiming = true;
            }
            else if (aiming && visibleEnemies.Count == 0)
            {
                aiming = false;
            }
            else if (aiming && visibleEnemies.Count > 0)
            {
                foreach (GameObject g in visibleEnemies)
                {
                    if (g != null)
                    {
                        GameObject r = Instantiate(rocket, transform.position, transform.rotation);
                        r.GetComponent<PlayerRocket>().EnemyObj = g;
                    }
                }
                foreach (Image i in lockons)
                {
                    Destroy(i);
                }

                cooldown = Time.time + 10f;
                aiming = false;
                visibleEnemies = new List<GameObject>();
                lockons = new List<Image>();
            }
        }
    }
    
}
