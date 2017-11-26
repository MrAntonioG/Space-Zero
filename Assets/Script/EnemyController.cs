using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharController {
    private PlayerController pc;
    protected int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    private bool awarded = false;

    public GameObject Player; //CharController holding player
    protected int damage = 0; //Int holding amount of damage from phyiscally touching player
    /// <summary>
    /// Read and Write, set and/or get the amount of damage dealt
    /// </summary>
    public int Damage
    {
        set { damage = value; }
        get { return damage; }
    }
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
        controller = GetComponent<CharacterController>();
        pc = Player.GetComponent<PlayerController>();
    }
    /// <summary>
    /// Method used to set enemy's stats by AI
    /// </summary>
    /// <param name="st"></param>
    public void setStats(CharStats st) 
    {
        this.stats = st;
    }
    /// <summary>
    /// Get player's position
    /// </summary>
    /// <returns>Vector3 containing player's position</returns>
    public Vector3 playerPosition()
    {
        return Player.transform.position;
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        

    }
    /// <summary>
    /// Moves enemy forward by speed
    /// </summary>
    /// <param name="speed">speed to move enemy forward by</param>
    public void Move(float speed)
    {
        controller.Move(gameObject.transform.forward * speed);
    }
    /// <summary>
    /// Method used to take damage
    /// </summary>
    /// <param name="dmg"></param>
    public override void Hit (int dmg)
    {
        stats.Hit(dmg);
        if (stats.isDead())
        {
            if (awarded == false)
            {
                pc.IncreaseScore(score);
                awarded = true;
            }
            Destroy(gameObject);
            
        }
    }
    /// <summary>
    /// Method used to check for collission
    /// </summary>
    /// <param name="hit">Object which has been hit</param>
    protected void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player" )
        {
            hit.collider.gameObject.GetComponent<CharController>().Hit(damage);
            Hit(damage);
        } else if (hit.gameObject.tag == "Asteroid")
        {
            hit.collider.gameObject.GetComponent<Asteroid>().Hit(damage);
            Hit(hit.collider.gameObject.GetComponent<Asteroid>().Damage);
        } else if (hit.gameObject.tag == "Planet")
        {
            Hit(damage);
        }

            
    }
}
