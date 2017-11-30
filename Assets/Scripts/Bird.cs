﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.name = "bird";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Pig")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "player")
        {
            var tmp = collision.gameObject.GetComponent<Controller>();
            if (!tmp.back)
            {
                var ani = collision.transform.GetComponent<Animator>();
                ani.SetBool("isOning", true);
                Destroy(this.gameObject);
            }
        }
    }
}
