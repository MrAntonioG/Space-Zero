using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class acting as AI for the Charger enemy type
/// </summary>
public class ChargerAI : AI {
    Vector3 dir;
    bool dirchose = false;
	/// <summary>
    /// Initializing Charger AI
    /// </summary>
	void Start () {
        cont = enemy.GetComponent<EnemyController>();
        initStats(0.001f, 0.3f, 0.06f, 1.3f, 0.45f);
        cont.Score = 50;
        cont.Damage = 75;
        EnemyStats st = new EnemyStats();
        st.InitStats(50, 0);
        cont.setStats(st);
        GenerateDirection();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        if (Vector3.Distance(transform.position, cont.playerPosition()) < 70f)
        {
            transform.LookAt(cont.playerPosition());
        }
        else
        {
            if (Vector3.Distance(transform.position,dir) <= 30f){
                dirchose = false;
            }
            if (!dirchose)
            {
                GenerateDirection();
            }
            transform.LookAt(dir);
        }
            
        if (Time.timeScale != 0f)
        {
            Accelerate();
        }
    }

    void GenerateDirection()
    {
        int r = Random.Range(1, 7);
        Vector3 pos = transform.position;
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
                dir = new Vector3(pos.x, pos.y - 1000f, pos.z);
                break;
        }
        dirchose = true;
    }
}
