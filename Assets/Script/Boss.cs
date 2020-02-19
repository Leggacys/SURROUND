using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public int health;
    public Inmic[] enemies;
    public float spawnDistance;

    private int halfHealth;
    private Animator anim;
    private transitionsPanel transitions;
    private Slider healtBar;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        halfHealth = health / 2;
        transitions = FindObjectOfType<transitionsPanel>();
        healtBar = FindObjectOfType<Slider>();
        healtBar.maxValue = health;
    }


    public void TakeDamage(int damageamount)
    {
        health -= damageamount;
        healtBar.value = health;
        if (health <= 0)
        {
            transitions.loadScreen();
            Destroy(gameObject);
            healtBar.gameObject.SetActive(false);
            
        }
        Inmic randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnDistance, spawnDistance, 0), transform.rotation);

        if(health<=halfHealth)
        {
            anim.SetTrigger("stage2");
        }
    }
}
