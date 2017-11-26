using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerRocket : BulletMovement
{
    private GameObject enemyObj;
    public GameObject EnemyObj //Set Method
    {
        set { enemyObj = value; }
    }
    /// <summary>
    /// Initialising the playerprojectile
    /// </summary>
    void Start()
    {
        InitStats("Enemy", "Player");
        lifeSpan = 2f;
        damage = 100;
        bulletSpeed = 1.5f;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public override void Update()
    {
        transform.LookAt(enemyObj.transform.position);
        base.Update();
    }
}
