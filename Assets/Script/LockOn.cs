using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LockOn : MonoBehaviour {
    private GameObject enemy;
    public GameObject Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 pos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0);
        Vector3 pos = Camera.main.WorldToScreenPoint(enemy.transform.position);
        transform.position = pos;        
    }
}
