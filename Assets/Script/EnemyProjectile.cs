using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyProjectile : BulletMovement {

    /// <summary>
    /// Initialising the playerprojectile
    /// </summary>
    void Start()
    {
        InitStats("Player", "Enemy");
        lifeSpan = 0.60f;
        damage = 50;
        bulletSpeed = 4f;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
}
