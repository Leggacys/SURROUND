using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmic : MonoBehaviour
{
    private Animator cameraAnim;
    [HideInInspector]
    public Transform player;
    public float speed;
    public int health;
    public float timebetwenatack;
    public int damage;
    public GameObject[] pickups;
    public  virtual void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageamount)
    {
        health -= damageamount;
        if (health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if(randomNumber>10)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            cameraAnim.SetTrigger("Shake");
            Destroy(gameObject);
        }
    }


}
