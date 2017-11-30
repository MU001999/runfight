using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public GameObject player;
    public float dir;

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
            transform.position = new Vector3(player.transform.position.x - dir, transform.position.y, transform.position.z);
        }
	}
}
