using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Move playerScript;
    public int healAmount;


    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            playerScript.Heal(healAmount);
           
            Destroy(gameObject);
        }
    }
}
