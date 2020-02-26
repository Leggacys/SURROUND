using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMinion : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        changeAlpha();
    }

    public void changeAlpha()
    {
        if(player!=null)
        if (Mathf.Abs(player.position.x - transform.position.x) < 0.8f && Mathf.Abs(player.position.y - transform.position.y) < 0.8f)
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
