using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wopon : MonoBehaviour
{
   

    public GameObject proiectiles;
    public float TimebetwenShoots;
    public Transform Directions;
    private  float Timeshoots;
    
    

    // Update is called once per frame
    void Update()
    { 
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.Log(direction);
       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
       transform.rotation = rotation;
      if(Input.GetMouseButton(0))
            if(Time.time>=Timeshoots)
           {
                Instantiate(proiectiles, Directions.position,transform.rotation);
                Timeshoots = Time.time + TimebetwenShoots;
            }
    }
}