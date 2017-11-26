using System;
using UnityEngine;

public abstract class CharStats {

    
    protected Stat health; //represent character's health stat
    //Read only, get health stat
    public Stat Health
    {
        get { return health; }
    }
    protected Stat shield; //represent character's shield stat
    //Read only, get shield stat
    public Stat Shield
    {
        get { return shield; }
    }
    protected float fuel; //represent player's fuel used for boosting
    /// <summary>
    /// Read Only, get the amount of fuel
    /// </summary>
    public float Fuel
    {
        get { return fuel; }
    }
    /// <su
    /// <summary>
    /// Creates new Stat objects
    /// </summary>
    /// <param name="health">amount of health</param>
    /// <param name="shield">amount of shield</param>
    virtual public void InitStats(int health, int shield)
    {
        this.health = new Stat();
        this.shield = new Stat();
        this.health.InitStat(health);
        this.shield.InitStat(shield);
    }
    /// <summary>
    /// Decreases Shield/Health depending on damage
    /// </summary>
    /// <param name="dmg"></param>
    virtual public void Hit(int dmg)
    {
        if (shield.IsEmpty() == false) {
            shield.Decrease(dmg);
        }
        else if (health.IsEmpty() == false) {
            health.Decrease(dmg);
        }
    }
    /// <summary>
    /// Checks health stat if dead
    /// </summary>
    virtual public bool isDead()
    {
        return Health.IsEmpty();
    }
    #region Fuel methods for Player
    /// <summary>
    /// decrease fuel by an amount
    /// </summary>
    /// <param name="dec">amount to decrease fuel by</param>
    public virtual void DecreaseFuel(float dec)
    {
        fuel -= dec;
        if (fuel <= 0)
        {
            fuel = 0;
        }
    }

    /// <summary>
    /// Increase fuel by an amount
    /// </summary>
    /// <param name="add">amount to increase fuel by</param>
    public virtual void IncreaseFuel(float add)
    {
        fuel += add;
        if (fuel >= 100)
        {
            fuel = 100;
        }
    }
} 
#endregion
