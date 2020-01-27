using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumonner :Inmic
{
    public float maxx;
    public float minx;
    public float maxy;
    public float miny;
    private Animator anim;
    private Vector2 targetpozitions;
    public float timebetweensumoon;
    private float summontime=0;
    public GameObject MINION;
    public float atackspeed;
    public int distance;
    private float timeatack;
    // Start is called before the first frame update
    public override void Start()
    {
  
        base.Start();
        float randomx = (int)Random.Range(minx, maxx);
        float randomy = (int)Random.Range(miny, maxy);
        targetpozitions = new Vector2(randomx, randomy);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if(player!=null)
        {
            if(Vector2.Distance(transform.position,targetpozitions) >0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetpozitions, speed * Time.deltaTime);
                anim.SetBool("iSRUNNING", true);
            }else
            {
                anim.SetBool("iSRUNNING", false);
                anim.SetBool("Idle", false);
                if (Time.time>=summontime)
                {
                    summontime = Time.time + timebetweensumoon;
                    anim.SetTrigger("Sumooning");
                    
                }
                else
                {
                    anim.SetBool("Idle", true);
                }
            }
        }
        if(Vector2.Distance(player.position,transform.position)<distance&& player != null)
        {
            if(Time.time>timeatack)
            {
                StartCoroutine(Attack());
                timeatack = timebetwenatack + Time.time;
            }
        }



    }

    public void summon()
    {
        if(player!=null)
        {
            Instantiate(MINION, transform.position, transform.rotation);
            
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
