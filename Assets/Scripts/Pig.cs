using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        this.name = "Pig";
        rb2d = GetComponent<Rigidbody2D>();
        OpenFire();
	}

    void OpenFire()
    {
        rb2d.AddForce(transform.right * 5000);
        Destroy(this.gameObject, 1);
    }
}
