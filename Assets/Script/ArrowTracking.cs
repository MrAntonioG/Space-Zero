using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowTracking : MonoBehaviour {
    private GameObject enemy;
    public GameObject Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }
    private Image arrow;
    public Image Arrow
    {
        get { return arrow; }
        set { arrow = value; }
    }
    public Sprite offscreen;
    public Sprite onscreen;
    Camera cam;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        arrow.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        checkEnemy();
        float xdif, ydif = 0;
        float size;
        Vector3 pos = cam.WorldToScreenPoint(enemy.transform.position);
        Debug.Log(pos);
        float camx = Screen.width;
        Debug.Log(camx);
        float camy = Screen.height;
        if (pos.z > 0 && pos.x >= 0 && pos.x <= camx && pos.y >= 0 && pos.y <= camy)
        {
            size = 70;
            transform.position = pos;
            arrow.sprite = onscreen;
            arrow.rectTransform.sizeDelta = new Vector2(size, size);
        }

        else
        {

            //Inverts the Z position to avoid opposite direction
            if (pos.z < 0)
            {
                pos.z = pos.z * -1;
            }
            //Find center of the screen and subtract it from pos
            Vector3 center = new Vector3(Screen.width, Screen.height, 0) / 2;
            pos = pos - center;

            //Find the angle from the center of the screen to the object's position
            float angle = Mathf.Atan2(pos.y, pos.x);
            angle -= 90 * Mathf.Deg2Rad;

            float cos = Mathf.Cos(angle);
            float sin = -Mathf.Sin(angle);

            pos = center + new Vector3(sin * 150, cos * 150, 0);

            //find the screen bounds
            float m = cos / sin;
            Vector3 bounds = center * 0.9f;

            //check if out of top and bottom bounds
            if (cos > 0)
            {
                pos = new Vector3(bounds.y / m, bounds.y, 0);
            }
            else
            {
                pos = new Vector3(-bounds.y / m, -bounds.y, 0);
            }
            //checks which side to point to if out of bounds
            if (pos.x > bounds.x)
            {
                pos = new Vector3(bounds.x, bounds.x * m, 0);
            }
            else if (pos.x < -bounds.x)
            {
                pos = new Vector3(-bounds.x, -bounds.x * m, 0);
            }

            //Add screen center back to find the correct coordinate
            pos = pos + center;

            size = 40;
            transform.position = pos;
            transform.rotation = Quaternion.Euler(0, 0, (angle * Mathf.Rad2Deg));
            arrow.sprite = offscreen;
            arrow.rectTransform.sizeDelta = new Vector2(size, size);

        }


        }
    /// <summary>
    /// Checking if enemy is alive
    /// </summary>
    private void checkEnemy()
    {
        if (enemy == null )
        {
            Destroy(arrow);
            Destroy(this);
        }
    }
}
