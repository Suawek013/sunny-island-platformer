using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private bool grounded = true;
    public float speed = 3;
    public float jumpSpeed = 3;
    private bool isHit;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.SetBool("isRunning", Input.GetAxis("Horizontal")!=0);
        anim.SetBool("isJumping", !grounded);

        float axisValue = Input.GetAxis("Horizontal");
        if( axisValue > 0.0f)
        {
            transform.localRotation = new Quaternion(0,0,0,0);
        } else if(axisValue < 0.0f)
        {
            transform.localRotation = new Quaternion(0,180,0,0);
        }
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);
        
      if(Input.GetKeyDown(KeyCode.Space)){
        if(grounded)
        {
            Jump();
        }
        }
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag=="Platform") {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy")
        {
            isHit = true;
            anim.SetBool("isHit", isHit);
            if(!grounded) grounded=true;
        }
        if(collision.tag =="Door") {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isHit=false;
        anim.SetBool("isHit", isHit);
    }
}
