using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : MonoBehaviour {
    protected float movespeed, lookspeed, rotrate, rotcap, speedcap;
    protected float shipspeed = 0.0f;
    protected float rotspeed = 0.0f;
    protected float x_rotation = 0.0f;
    protected float y_rotation = 0.0f;
    protected float dec = 3f;

    public GameObject enemy; //holds gameObject of the enemy

    protected EnemyController cont;
    /// <summary>
    /// Write Only, get the enemy controller
    /// </summary>
    public EnemyController Cont
    {
        get { return cont; }
    }

    /// <summary>
    /// Initialise movement stats
    /// </summary>
    protected virtual void initStats(float movespeed, float lookspeed, float rotrate, float rotcap, float speedcap)
    {
        this.movespeed = movespeed;
        this.lookspeed = lookspeed;
        this.rotrate = rotrate;
        this.rotcap = rotcap;
        this.speedcap = speedcap;
    }
	/// <summary>
    /// Accelerates the enemy forward
    /// </summary>
    protected virtual void Accelerate()
    {
        if (shipspeed < speedcap)
        {
            shipspeed += movespeed;
        }
        cont.Move(shipspeed);
    }

    /// <summary>
    /// Decelerates the enemy
    /// </summary>
    protected virtual void Decelerate()
    {
        if (shipspeed > 0)
        {
            shipspeed -= (movespeed / dec);
        }
        cont.Move(shipspeed);
    }

}
