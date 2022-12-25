using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biplane : Entity
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            if (transform.position.z >= 10) Move(0f, 1f);
            Attack();
        }
    }
}
