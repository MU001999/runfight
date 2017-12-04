using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    private GameObject player;

    // Use this for initialization

    private void Awake()
    {
        player = GameObject.Find("player");
    }
    void Start () {
        this.name = "pig";
        Destroy(this.gameObject, 0.3F);
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.gameObject.name)
        {
            case "bird":
                Destroy(collider.gameObject);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + 100 * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnDestroy()
    {
        var ani = player.transform.GetComponent<Animator>();
        ani.SetBool("isFighting", false);
    }
}
