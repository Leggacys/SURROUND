using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gripa :MonoBehaviour
{
    // Start is called before the first frame update
    public int  speed;
    public int health;
    private Transform player;
    private Animator anim;
    private GameObject worldLight;
   


    private float times;
      void  Start()
    {
        worldLight = GameObject.FindGameObjectWithTag("worldLight");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        worldLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            
            if (Vector2.Distance(transform.position, player.position) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
          
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            worldLight.SetActive(true);
            Destroy(gameObject);
        }
    }
}
