using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isVertical;
    public bool isMoving = true;

    public float movementDistance;
    public float speed;
    private bool movingLeft=true;
    private float leftEdge;
    private float rightEdge;

    
    private bool movingTop=true;
    private float topEdge;
    private float bottomEdge;
    // Start is called before the first frame update
    void Start()
    {
        topEdge = transform.position.y - movementDistance;
        bottomEdge = transform.position.y + movementDistance;

        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            if(!isVertical) MoveHorizontal();
            else MoveVertical();
        }
    }

    private void MoveHorizontal() {
        if(movingLeft)
        {
            if(transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed*Time.deltaTime, transform.position.y, transform.position.z);
            } else {
                transform.localRotation = new Quaternion(0,180,0,0);
                movingLeft = false;
            }
        } else {
            if(transform.position.x < rightEdge) {
                transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);
            } else {
                transform.localRotation = new Quaternion(0,0,0,0);
                movingLeft = true;
            }
        }
    }

    private void MoveVertical() {
        if(movingTop) {
            if(transform.position.y > topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed*Time.deltaTime, transform.position.z);
            } else {
                movingTop = false;
            }
        } else {
            if(transform.position.y < bottomEdge) {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed*Time.deltaTime, transform.position.z);
            } else {
                movingTop = true;
            }
        }
    }
}
