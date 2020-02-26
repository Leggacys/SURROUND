using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2 : MonoBehaviour
{

    public int health;
    public GameObject[] enemy;
    public int speed;
    public float spawndistance;

    private GameObject[] movePoint;
    private Slider healthBar;
    private Animator anim;
    private transitionsPanel transitionsPanel;
    private float halfHealth;
    private GameObject player;
    private bool reachPoint = true;
    private GameObject random;



    void Start()
    {
        movePoint = GameObject.FindGameObjectsWithTag("BossMovePoint");
        healthBar = FindObjectOfType<Slider>();
        anim = GetComponent<Animator>();
        healthBar.gameObject.SetActive(true);
        halfHealth = health / 2;
        healthBar.maxValue = health;
        transitionsPanel = FindObjectOfType<transitionsPanel>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    
    void Update()
    {
        if(player!=null)
        {
            if (reachPoint == true)
            {
                reachPoint = !reachPoint;
                random = movePoint[Random.Range(0, movePoint.Length - 1)];
            }
            else
            if (Vector2.Distance(transform.position, random.transform.position) > 0.5f)
                transform.position = Vector2.MoveTowards(transform.position, random.transform.position, speed * Time.deltaTime);
            else
                reachPoint = !reachPoint;
        }
    }

    public void TakeDamage(int damageamount)
    {
        health -= damageamount;
        healthBar.value = health;
        if(health<=0)
        {
           transitionsPanel.loadScreen();
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
        }
        GameObject randomEnemy = enemy[Random.Range(0, enemy.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawndistance, spawndistance, 0),transform.rotation);
        if(health<=halfHealth)
        {
            anim.SetTrigger("Stage2");
        }
    }
}
