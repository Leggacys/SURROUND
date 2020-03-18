using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_End : MonoBehaviour
{
    public int lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
