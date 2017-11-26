using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerProjectile : BulletMovement {
   
	/// <summary>
    /// Initialising the playerprojectile
    /// </summary>
	void Start () {
        InitStats("Enemy", "Player");
        lifeSpan = 0.60f;
        damage = 35;
        bulletSpeed = 4f;
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public override void Update () {
        base.Update();
	}
}
