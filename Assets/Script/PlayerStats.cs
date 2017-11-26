using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class PlayerStats : CharStats {

    /// <summary>
    /// Initializes Player Stats Class
    /// </summary>
    void Start () {     
        fuel = 100f;
    }
    /// <summary>
    /// decrease fuel by an amount
    /// </summary>
    /// <param name="dec">amount to decrease fuel by</param>
	public override void DecreaseFuel(float dec)
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
    public override void IncreaseFuel(float add)
    {
        fuel += add;
        if (fuel >= 100)
        {
            fuel = 100;
        }
    }
}
