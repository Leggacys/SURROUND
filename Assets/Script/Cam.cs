using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform playertranfsorm;
    public float speed;
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playertranfsorm.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playertranfsorm !=null)
        {
            float clampedx = Mathf.Clamp(playertranfsorm.position.x, minx, maxx);
            float clampedy = Mathf.Clamp(playertranfsorm.position.y, miny, maxy);
             transform.position = Vector2.Lerp(transform.position, new Vector2(clampedx, clampedy), speed);
        }
    }

   
}
