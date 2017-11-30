using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 vel;
    public Vector2 pre;
    public Transform pig;
    public Animator ani;
    public bool isGrounded;
    public bool notGo;
    public bool back;
    public GameObject tmp;

    // Use this for initialization
    void Start()
    {
        isGrounded = true;
        notGo = true;
        back = true;
        tmp = GameObject.Find("birds");
        vel = new Vector2();
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        this.name = "player";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            ani.SetBool("isFighting", false);
            isGrounded = false;
            rb2d.AddForce(transform.up * 500);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, new Vector2(rb2d.position.x - 10, rb2d.position.y), ref vel, Time.fixedDeltaTime, 10, Time.fixedDeltaTime);
            //rb2d.AddForce(transform.right * -10);
            //rb2d.MovePosition(new Vector2(rb2d.position.x - 10 * Time.deltaTime, rb2d.position.y));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(transform.up * -100);
            //rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - 10 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, new Vector2(rb2d.position.x + 10, rb2d.position.y), ref vel, Time.fixedDeltaTime, 10, Time.fixedDeltaTime);
            //rb2d.AddForce(transform.right * 10);
            //rb2d.MovePosition(new Vector2(rb2d.position.x + 10 * Time.deltaTime, rb2d.position.y));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("isFighting", true);
            Instantiate(pig, new Vector3(transform.position.x+10F, transform.position.y), transform.rotation);
        }
        if (Input.GetMouseButtonDown(0) && notGo && !isGrounded)
        {
            notGo = false;
            back = false;
            pre = rb2d.position;
        }
        if (!notGo && !isGrounded && new Vector2(tmp.transform.position.x, tmp.transform.position.x) !=rb2d.position)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, tmp.transform.position, ref vel, 0.1F, 1000, Time.fixedDeltaTime);
        }
        if (notGo && !back)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, pre, ref vel, 0.1F, 1000, Time.fixedDeltaTime);
        }
        if (!back && rb2d.position.x <= pre.x)
        {
            back = true;
        }
    }
}
