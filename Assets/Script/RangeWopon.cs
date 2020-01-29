using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWopon :MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
 



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {  
            float angle = Mathf.Atan2(player.position.y, player.position.x) * Mathf.Rad2Deg;
            Quaternion rotations = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotations;

           
        }
        

    }
}
