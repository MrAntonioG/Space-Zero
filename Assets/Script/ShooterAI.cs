using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : AI {
    public GameObject weapon;
    private bool far = true;
    private Vector3 dir;
    private float cooldown;
    private Quaternion lookRot;

	// Use this for initialization
	void Start () {
        cont = enemy.GetComponent<EnemyController>();
        initStats(0.0005f, 1.2f, 0.06f, 1.3f, 0.1f);
        cont.Damage = 50;
        cont.Score = 150;
        EnemyStats st = new EnemyStats();
        st.InitStats(100, 50);
        cont.setStats(st);

    }
	
	// Update is called once per frame
	void Update () {
        
        weapon.transform.LookAt(cont.playerPosition());
        if (Vector3.Distance(transform.position, cont.playerPosition()) > 30f)
        {
            //transform.LookAt(cont.playerPosition());
            lookRot = Quaternion.LookRotation(cont.playerPosition() - transform.position);
            far = true;
        } else
        {
            if (far == true)
            {
                GenerateDirection();
            }
            //transform.LookAt(dir);
            lookRot = Quaternion.LookRotation(dir - transform.position);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * lookspeed);
        if (Time.timeScale != 0f)
        {
            Accelerate();
        }

        if (Time.time > cooldown)
        {
            weapon.GetComponent<EnemyWeapon>().PrimaryShoot();
            cooldown = Time.time + 6f;
        }
    }

    void GenerateDirection()
    {
        int r = Random.Range(1, 7);
        Vector3 pos = cont.playerPosition();
        switch (r)
        {
            case 1:
                dir = new Vector3(pos.x + 1000f, pos.y, pos.z);
                break;
            case 2:
                dir = new Vector3(pos.x, pos.y, pos.z + 1000f);
                break;
            case 3:
                dir = new Vector3(pos.x - 1000f, pos.y, pos.z);
                break;
            case 4:
                dir = new Vector3(pos.x, pos.y, pos.z - 1000f);
                break;
            case 5:
                dir = new Vector3(pos.x, pos.y + 1000f, pos.z);
                break;
            case 6:
                dir = new Vector3(pos.x, pos.y - 1000f, pos.z );
                break;
        }
        far = false;
    }
}
