using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script Representing a Health Drop
/// </summary>
public class HealthDrop : Collectable {

	// Use this for initialization
	void Start () {
        value = 30;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,50* Time.deltaTime, 0));
	}
}
