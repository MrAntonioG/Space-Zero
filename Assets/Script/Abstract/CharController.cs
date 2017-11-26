using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abstract Class holding the framework to controll in-game characters
/// </summary>
public abstract class CharController : MonoBehaviour {
    protected CharStats stats; //Class representing stats of the character
    /// <summary>
    /// Read only, get character stats
    /// </summary>
    public CharStats Stats
    {
        get { return stats; }
    }

    protected CharacterController controller; //CharacterController used to control in-game character
    /// <summary>
    /// Read only, get character controller
    /// </summary>
    public CharacterController Controller
    {
        get { return controller; }
    }
    
    /// <summary>
    /// Method called upon being hit
    /// </summary>
    /// <param name="dmg">amount of damage inflicted</param>
    virtual public void Hit(int dmg) {    }
}
