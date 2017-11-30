using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public GameObject player;
    public float dir;
    public Vector3 vel;

	// Use this for initialization
	void Start ()
    {
        dir = player.transform.position.x - transform.position.x;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (player.GetComponent<Controller>().back)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x - dir, transform.position.y, transform.position.z), ref vel, Time.deltaTime, 10, Time.deltaTime);
            //transform.position = new Vector3(player.transform.position.x - dir, transform.position.y, transform.position.z);
        }
	}
}
