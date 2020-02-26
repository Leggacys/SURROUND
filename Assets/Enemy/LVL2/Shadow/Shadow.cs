using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Inmic
{
    private Animator anim;
    public float distance;
    public Transform shotpoint;
    public GameObject proiectiles;
    private bool Facingright = true;
    private float time =0;
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
            if (Vector2.Distance(transform.position,player.position)> distance)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Runn", true);
                transform.position=Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
            }
            else
            {
                anim.SetBool("Runn", false);
                
                if (time < Time.time )
                { 
                    anim.SetTrigger("Atack");
                    time = Time.time + timebetwenatack;
                }
                else
                {
                    anim.SetBool("Idle", true);
                }

                
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

    private void scale()
    {
        Vector3 thescale = transform.localScale;
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x && !Facingright || player.transform.position.x < transform.position.x && Facingright)
            {
                Facingright = !Facingright;
                thescale.x *= -1;
                transform.localScale = thescale;

            }
        }
    }
}
