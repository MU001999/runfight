using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdGun : MonoBehaviour {

    public bool left;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3F);
	}
	
	// Update is called once per frame
	void Update () {
        if(left)
        {
            transform.position = new Vector3(transform.position.x - 10 * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + 10 * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            SceneManager.UnloadSceneAsync("1");
            SceneManager.LoadSceneAsync("Begin");
        }
    }
}
