using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum MoveState
{
    left, right, follow
};

public class Bird : MonoBehaviour {

    public Transform gun;

    private GameObject player;
    private float left, right;
    private MoveState state;
    private Rigidbody2D rb2dtmp;
    private float lastTime, curTime;

	// Use this for initialization
	void Start () {
        this.name = "bird";
        player = GameObject.Find("player");
        left = transform.position.x - 10F;
        right = transform.position.x + 10F;
        state = MoveState.left;
        rb2dtmp = transform.GetComponent<Rigidbody2D>();
        rb2dtmp.velocity = new Vector2(-5, rb2dtmp.velocity.y);
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        curTime = Time.time;
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 10F || state == MoveState.follow)
        {
            state = MoveState.follow;
            if (transform.position.x > player.transform.position.x)
            {
                rb2dtmp.velocity = new Vector2(-5, rb2dtmp.velocity.y);
            }
            else
            {
                rb2dtmp.velocity = new Vector2(5, rb2dtmp.velocity.y);
            }
        }
        else
        {
            rb2dtmp.velocity = state == MoveState.left ? new Vector2(-5, rb2dtmp.velocity.y): new Vector2(5, rb2dtmp.velocity.y);
            if (transform.position.x <= left)
            {
                state = MoveState.right;
            }
            else if(transform.position.x >= right)
            {
                state = MoveState.left;
            }
        }
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= 20F && curTime-lastTime>=1F)
        {
            lastTime = curTime;
            if(transform.position.x > player.transform.position.x)
            {
                Transform ins = Instantiate(gun, new Vector3(transform.position.x - 1F, transform.position.y, transform.position.z), Quaternion.identity);
                var tmp = ins.GetComponent<BirdGun>();
                tmp.left = true;
            }
            else
            {
                Transform ins = Instantiate(gun, new Vector3(transform.position.x + 1F, transform.position.y, transform.position.z), Quaternion.identity);
                var tmp = ins.GetComponent<BirdGun>();
                tmp.left = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            var tmp = collision.transform.GetComponent<Controller>();
            if (!tmp.back)
            {
                var ani = collision.transform.GetComponent<Animator>();
                ani.SetBool("isOning", true);
                Destroy(this.gameObject);
            }
            else
            {
                SceneManager.UnloadSceneAsync("1");
                SceneManager.LoadSceneAsync("Begin");
            }
        }
    }
}
