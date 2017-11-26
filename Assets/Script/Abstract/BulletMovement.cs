using System.Collections;
using UnityEngine;

public abstract class BulletMovement : MonoBehaviour {
    protected float bulletSpeed; //speed at which the bullet travels
    /// <summary>
    /// Read only, get Bullet Movement Speed
    /// </summary>
    public float BulletSpeed
    {
        get { return bulletSpeed; }
    }

    protected float lifeSpan; //maximum time the bullet can stay within game
    /// <summary>
    /// Read only, get bullet's life span
    /// </summary>
    public float LifeSpan
    {
        get { return lifeSpan; }        
    }

    protected int damage; //amount of damage the bullet inflic
    /// <summary>
    /// Read only, get bullet's damage amount
    /// </summary>
    public int Damage
    {
        get { return damage; }
    }
    protected string enemy; //holds the tag of enemies
    protected string friendly; //Holds the tag of friendly characters

    protected float livetime; //Holds the amount of time the bullet is in the game
    CharacterController controller; //Controls the bullet's movement and collission
    /// <summary>
    /// Initialize the bullet stats
    /// </summary>
    /// <param name="en"> tag of the enemies</param>
    /// <param name="fr"> tag of the friends</param>
    virtual protected void InitStats (string en, string fr) {
        controller = GetComponent<CharacterController>(); //initiates the character controller component
        livetime = 0.0f;
        enemy = en;
        friendly = fr;
	}
	
	/// <summary>
    /// Update is called each frame
    /// </summary>
	virtual public void Update () {
        controller.Move(gameObject.transform.forward * BulletSpeed); //moves bullet forward
        livetime += Time.deltaTime;
        if (livetime > lifeSpan)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Uses the character controllers' collission detection method
    /// </summary>
    /// <param name="hit"> Object which has been hit</param>
    virtual protected void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != friendly)
        {
            Destroy(gameObject); //destroys bullet on hit
        }
    
        // if the bullet hits an enemy, calls method "Hit"
        if (hit.gameObject.tag == enemy)
        {
            hit.collider.gameObject.GetComponent<CharController>().Hit(damage);
        }
        if (hit.gameObject.tag == "Asteroid")
        {
            hit.collider.gameObject.GetComponent<Asteroid>().Hit(damage);
        }
    }

}
