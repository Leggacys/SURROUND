using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProiectilesEnemy : MonoBehaviour
{
    public GameObject explosions;
    public float lifetime;
    public float speed;
    public int damage;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Distructions", lifetime);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Distructions()
    {
       Instantiate(explosions, transform.position, Quaternion.identity);
        Destroy(gameObject, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Move>().TakeDamage(damage);
            Distructions();
        }
    }
}
