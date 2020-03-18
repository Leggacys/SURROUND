using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_3 : MonoBehaviour
{

    public GameObject proiectiles;
    public float TimebetwenShoots;
    public Transform Directions;
    public Transform Directions2;
    public Transform Directions3;
    private float Timeshoots;
    public VirtualJoystick Controller;

    void Update()
    {
        
        
            Quaternion direction2;
            Quaternion direction3;
            Vector3 amount = Controller.Directions;
            Vector2 direction = Vector2.zero;
            direction.x = amount.x;
            direction.y = amount.z;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            direction2 = Quaternion.AngleAxis(angle - 70, Vector3.forward);
            direction3 = Quaternion.AngleAxis(angle - 110, Vector3.forward);
            transform.rotation = rotation;
            if (Controller.Directions != Vector3.zero)
                if (Time.time >= Timeshoots)
                {
                    Instantiate(proiectiles, Directions.position, transform.rotation);
                    transform.rotation = direction2;
                    Instantiate(proiectiles, Directions2.position, transform.rotation);
                    transform.rotation = direction3;
                    Instantiate(proiectiles, Directions3.position, transform.rotation);
                    Timeshoots = Time.time + TimebetwenShoots;
                }
        

    }
}
