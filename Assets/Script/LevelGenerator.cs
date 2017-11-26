using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject PointA, PointB, PointC, PointD, PointE, PointF;
    public GameObject debris;
    public GameObject health;
    public GameObject Front, Back, Left, Right, Top, Bottom;
    public GameObject PlanetA, PlanetB, PlanetC, PlanetD, PlanetE;
    // Use this for initialization
    void Start () {
	}

    /// <summary>
    /// Creates the level by placing planets within boundaries
    /// </summary>
    public void LevelGenerate()
    {
        int f = Random.Range(10, 25);
        for(int x = 0; x < f; x++)
        {
            Vector3 rpos = new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), Random.Range(Bottom.transform.position.y, Top.transform.position.y), Random.Range(Back.transform.position.z, Front.transform.position.z));
            int p = Random.Range(1, 6);
            GameObject planet = PlanetA;
            switch (p)
            {
                case 1:
                    planet = PlanetA;
                    break;
                case 2:
                    planet = PlanetB;
                    break;
                case 3:
                    planet = PlanetC;
                    break;
                case 4:
                    planet = PlanetD;
                    break;
                case 5:
                    planet = PlanetE;
                    break;
            }
            Instantiate(planet, rpos, this.transform.rotation);
        }

        
        int g = 40;
        for (int i = 0; i < g; i++)
        {
           generateDebris();
        }
    }
    
    /// <summary>
    /// Generate a healthdrop
    /// </summary>
    public void generateHealthDrop()
    {
        Vector3 rpos = new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), Random.Range(Bottom.transform.position.y, Top.transform.position.y), Random.Range(Back.transform.position.z, Front.transform.position.z));
        GameObject newHealth = Instantiate(health, rpos, this.transform.rotation);
    }
    /// <summary>
    /// Adds debris in a random spot
    /// </summary>
    private void generateDebris()
    {
        Vector3 rpos = new Vector3(Random.Range(Left.transform.position.x, Right.transform.position.x), Random.Range(Bottom.transform.position.y, Top.transform.position.y), Random.Range(Back.transform.position.z, Front.transform.position.z));
        GameObject newAst = Instantiate(debris, rpos, this.transform.rotation);
        


    }
    /// <summary>
    /// Randomly chooses a spawnpoint
    /// </summary>
    /// <returns>Returns the random spawnpoint's location</returns>
    public Vector3 randomSpawnPoint()
    {
        int p = Random.Range(1, 7);
        Vector3 pos = PointA.transform.position;
        switch (p)
        {
            case 1:
                pos = PointA.transform.position;
                break;
            case 2:
                pos = PointB.transform.position;
                break;
            case 3:
                pos = PointC.transform.position;
                break;
            case 4:
                pos = PointD.transform.position;
                break;
            case 5:
                pos = PointE.transform.position;
                break;
            case 6:
                pos = PointF.transform.position;
                break;
        }
        return pos;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
