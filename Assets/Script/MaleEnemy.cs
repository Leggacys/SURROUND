using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleEnemy : Inmic
{

    public int Distance;
     float timeatack;
    public float atackspeed;
   


    // Update is called once per frame
    void Update()
    {
        
      
             if(player !=null)
            if (Vector2.Distance(transform.position, player.position) > Distance)
            {
                transform.position=Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        else
        if(Time.time>=timeatack)
        { 
                StartCoroutine(Attack());
                timeatack = Time.time + timebetwenatack;
        }
       
    }

   IEnumerator Attack()
    {
        player.GetComponent<Move>().TakeDamage(damage);
        Vector2 origin = transform.position;
        Vector2 target = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * atackspeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(origin, target, formula);
            yield return null;
        }
    }
}
