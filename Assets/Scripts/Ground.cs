using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            var tmp = collision.transform.GetComponent<Controller>();
            var ani = collision.transform.GetComponent<Animator>();
            tmp.isGrounded = true;
            tmp.notGo = true;
            tmp.back = true;
            ani.SetBool("isJumping", false);
            ani.SetBool("isGoing", false);
            ani.SetBool("isOning", false);
            ani.SetBool("isAir", false);
        }
    }
}
