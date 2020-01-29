using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject proiectiles;
    public float TimebetwenShoots;
    public Transform Directions;
    private float Timeshoots;
    public VirtualJoystick Controller;
    private Transform playerGame;
    // Start is called before the first frame update
    void Start()
    {
        playerGame = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,playerGame.position)<0.5)
        {
            Vector3 amount = Controller.Directions;
            Vector2 direction = Vector2.zero;
            direction.x = amount.x;
            direction.y = amount.z;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;
            if (Controller.Directions != Vector3.zero)
                if (Time.time >= Timeshoots)
                {
                    Instantiate(proiectiles, Directions.position, transform.rotation);
                    Timeshoots = Time.time + TimebetwenShoots;
                }
        }

    }
}
