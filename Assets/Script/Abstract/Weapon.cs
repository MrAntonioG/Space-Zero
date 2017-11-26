using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    protected float fireRate; //Represents the firerate of a weapon as a float
    /// <summary>
    /// Read only, get fire rate
    /// </summary>
    public float FireRate
    {
        get { return fireRate; }
    }

    protected float nextShot = 0.0f; //Represent when the next shot is available
    /// <summary>
    /// Read and Write, get and set when the next shot is available
    /// </summary>
    public float NextShot
    {
        get { return nextShot; }
        set { nextShot = value; }
    }

    /// <summary>
    /// Method dedicated to weapon's primary method of fire
    /// </summary>
    public virtual void PrimaryShoot() { }
    /// <summary>
    /// Method dedicated to weapon's secondary method of fire
    /// </summary>
    public virtual void SecondaryShoot() { }
}