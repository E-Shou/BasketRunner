using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    private Rigidbody rbody;
    private Animator animator;
    private bool usingButtons = false;

    public float MOVE_SPEEDX;
    private float moveSpeed;
    private readonly bool Run = false;

    public enum MOVE_DIR
    {
        STOP,
        LEFT,
        RIGHT,
    };

    private MOVE_DIR moveDirection = MOVE_DIR.STOP;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        switch (moveDirection)
        {
            case MOVE_DIR.STOP:
                moveSpeed = 0;
                break;
            case MOVE_DIR.LEFT:
                animator.SetBool("Push", Run);
                moveSpeed = MOVE_SPEEDX * -1;
                transform.localRotation = Quaternion.Euler (0f, -90f, 0f);
                break;
            case MOVE_DIR.RIGHT:
                animator.SetBool("Push", Run);
                moveSpeed = MOVE_SPEEDX * 1;
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                break;
        }
        rbody.velocity = new Vector3(moveSpeed, rbody.velocity.y, 0);
    }

    void Update()
    {
        if (!usingButtons)
        {
            float x = Input.GetAxisRaw("Horizontal");

            if ((x == 0))
            {
                moveDirection = MOVE_DIR.STOP;
            }
            else if (x < 0)
            {
                moveDirection = MOVE_DIR.LEFT;
            }
            else if (x > 0)
            {
                moveDirection = MOVE_DIR.RIGHT;
            }
        }
    }

    public void PushLeftButton()
    {
        usingButtons = true;
        moveDirection = MOVE_DIR.LEFT;
    }

    public void PushRightButton()
    {
        usingButtons = true;
        moveDirection = MOVE_DIR.RIGHT;
    }

    public void ReleaseMoveButton()
    {
        moveDirection = MOVE_DIR.STOP;
        usingButtons = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "BallBlack" || other.gameObject.tag == "BallRed" || other.gameObject.tag == "BallBlue" )
        {
            if (other.gameObject.tag == "Ball")
            {
                FindObjectOfType<GameController>().AddPoint(1);
            }else if (other.gameObject.tag == "BallBlack")
            {
                FindObjectOfType<GameController>().AddPoint(-3);
            }else if (other.gameObject.tag == "BallRed")
            {
                FindObjectOfType<GameController>().AddPoint(10);
            }else if(other.gameObject.tag == "BallBlue")
            {
                FindObjectOfType<GameController>().AddPoint(5);
            }
            Destroy(other.gameObject);
        }
    }

}
