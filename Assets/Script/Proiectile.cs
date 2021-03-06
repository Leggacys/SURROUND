﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject explosions;
    public int damage;
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("Distructions", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }

    void Distructions()
    {
        Instantiate(sound, transform.position, transform.rotation);
        Instantiate(explosions,transform.position, Quaternion.identity);
        Destroy(gameObject,0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag=="Enemy")
        {
            Distructions();
            collision.GetComponent<Inmic>().TakeDamage(damage);
            
        }
        if (collision.tag == "Boss")
        {
            Distructions();
            collision.GetComponent<Boss>().TakeDamage(damage);

        }
        else
            if(collision.tag=="Boss2")
        {
            Distructions();
            collision.GetComponent<Boss2>().TakeDamage(damage);
        }
         else
            if(collision.tag=="Gripa")
        {
            Distructions();
            collision.GetComponent<Gripa>().takeDamage(damage);
        }
    }
   
}
