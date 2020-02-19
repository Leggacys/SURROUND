using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : Inmic
{
    private bool Facingright = true;
    public float distance;
    public Transform shotpoint;
    public GameObject proiectiles;
    private Animator anim;

    
  
    // Start is called before the first frame update
    public override void  Start()
    {
        base.Start();
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    { 
        if (player != null)
        {
           
            if (Vector2.Distance(transform.position, player.position) > distance)
            {
                anim.SetBool("Run", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Run", false);
                anim.SetTrigger("Atac");
            }
            scale();
        }
    }

    private void scale()
    {
        Vector3 thescale = transform.localScale;    
        if(player!=null)
        {
            if(player.transform.position.x > transform.position.x && Facingright==false|| player.transform.position.x < transform.position.x && Facingright==true)
            {
                Facingright =! Facingright;
                thescale.x *= -1;
                transform.localScale = thescale;

            }
        }
    }

    public void RangeAtack()
    {
        if (player != null)
        {
            Vector2 direction = player.position - shotpoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotpoint.rotation = rotation;
            Instantiate(proiectiles, shotpoint.position, shotpoint.rotation);
        }
    }
}
