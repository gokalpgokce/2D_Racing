﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.tag == "Enemy Car"){
            Destroy(col.gameObject);
        }
    }
}
