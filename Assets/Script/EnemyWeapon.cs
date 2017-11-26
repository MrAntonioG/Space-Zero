using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWeapon : Weapon
{
    public GameObject bullet;//hold object to be used as a bullet
    private int bulletCount = 0;
    private bool shot = false;
    float cooldown = 0f;

    /// <summary>
    /// Initializing weapon stats
    /// </summary>
    void Start()
    {
        fireRate = 0.3f;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (shot)
        {
            if (bulletCount < 4)
            {
                if (Time.time > nextShot)
                {
                    PrimaryShoot();
                }
            }
            else
            {
                shot = false;
                bulletCount = 0;
            }

        }

    }
    /// <summary>
    /// Primary method of shooting is projectile based
    /// </summary>
    public override void PrimaryShoot()
    {
        shot = true;
        Instantiate(bullet, transform.position, transform.rotation);
        nextShot = Time.time + fireRate;
        bulletCount++;

    }
    /// <summary>
    /// Enemies do not have a secondary method of shooting
    /// </summary>
    public override void SecondaryShoot()
    {
        
    }

}
