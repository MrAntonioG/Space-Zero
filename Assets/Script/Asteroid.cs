using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    protected int damage = 30; //amount of damage the asteroid inflicts
    /// <summary>
    /// Read only, get asteroid's damage amount
    /// </summary>
    public int Damage
    {
        get { return damage; }
    }

    protected int health = 50;
    public int Health
    {
        get { return health; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 30 * Time.deltaTime));
    }

    public void Hit (int dmg)
    {
        health = health - dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}
