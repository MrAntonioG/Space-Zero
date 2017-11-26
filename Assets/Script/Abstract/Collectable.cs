using System.Collections;
using UnityEngine;

abstract public class Collectable : MonoBehaviour {
    protected int value; // Current value held within the collectable
    /// <summary>
    /// Read Only, property gives back the current value of the collectable
    /// </summary>
    public int Value
    {
        get { return value; }
    }




}

