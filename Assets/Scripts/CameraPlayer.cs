using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector3 dir;
    public Vector3 vel;

	// Use this for initialization
	void Start ()
    {
        dir = player.transform.position - transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (player.GetComponent<Controller>().back)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position - dir, ref vel, Time.deltaTime, 16, Time.deltaTime);
            //transform.position = new Vector3(player.transform.position.x - dir, transform.position.y, transform.position.z);
        }
	}
}
