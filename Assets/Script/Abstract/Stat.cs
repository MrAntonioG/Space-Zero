using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class representing a statistic within the game
public class Stat {

    protected int max; // Maximum value for stat
    /// <summary>
    /// Read Only, property gives back the maximum value of the stat
    /// </summary>
    public int Max
    {
        get { return max; }
    }
    protected int value; // Current value for stat
    /// <summary>
    /// Read Only, property gives back the current value of the stat
    /// </summary>
    public int Value
    {
        get { return value; }
    }

    /// <summary>
    /// Read Only, returns true if value is empty, returns false if value isn't empty
    /// </summary>
    public bool IsEmpty()
    {
       if (value <= 0){
            return true;
        } else{
            return false;
        }
    }
    /// <summary>
    /// Method to initialize the stat by defining the current and maximum value
    /// </summary>
    /// <param name="val">maximum and current amount</param>
    public void InitStat(int val)
    {
        max = val;
        value = val;
    }
    /// <summary>
    /// Method to increase the current value
    /// </summary>
    /// <param name="val">amount to increase value by</param>
    virtual public void Increase (int val)
    {
        value += val;
        if (value >= max)
        {
            value = max;
        }
    }
    /// <summary>
    /// Method to decrease the current value
    /// </summary>
    /// <param name="val">amount to decrease value by</param>
    virtual public void Decrease(int val)
    {
        value -= val;
        if (value <= 0)
        {
            value = 0;
        }
    }
    /// <summary>
    /// Method to reset the current value to maximum value
    /// </summary>
    public void Reset()
    {
        value = max;
    }
}
