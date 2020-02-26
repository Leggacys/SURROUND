using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Inmic
{
    private Animator anim;
    public int distance;
    private bool Facingright = true;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            scale();
            if(Vector2.Distance(transform.position,player.position)>distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetTrigger("Atack");
                player.GetComponent<Move>().TakeDamage(damage);
            }
            

        }
    }
    private void scale()
    {
        Vector3 thescale = transform.localScale;
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x && Facingright == false || player.transform.position.x < transform.position.x && Facingright == true)
            {
                Facingright = !Facingright;
                thescale.x *= -1;
                transform.localScale = thescale;

            }
        }
    }
}
