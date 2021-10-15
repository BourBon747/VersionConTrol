using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Playermovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    private Vector2 moveDiraction;
    private Animator anim;
    bool facingRight = true;
    float moveInput;
    private float directionX;

    

    //private Inventory Inventory;
    //[SerializeField] private UI_Inventory uiInventory;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = Input.GetAxisRaw("Horizontal");
        anim = GetComponent<Animator>();
    }



    void Update()
    {
        float moveX = SimpleInput.GetAxis("Horizontal");
        float moveY = SimpleInput.GetAxis("Vertical");
        moveDiraction = new Vector2(moveX, moveY);


        if (Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))

        {
            anim.SetBool("iswalk", true);
        }
        else
        {
            anim.SetBool("iswalk", false);
        }

        if (moveX < 0 && facingRight)
        {
            flip();
        }
        else if (moveX > 0 && !facingRight)
        {
            flip();
        }

        //Move();
        //Animation();
        //Inventory = new Inventory();
        //uiInventory.SetInventory(Inventory);

        //directionX = CrossPlatformInputManager.GetAxis("Horizontal") * movespeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDiraction * movespeed * Time.deltaTime);
        directionX = CrossPlatformInputManager.GetAxis("Horizontal") * movespeed;
        rb.velocity = new Vector2(directionX * movespeed, 0);
        Move();
        Animation();
    }

    //void Processinputs()
    //{
    //    float moveX = Input.GetAxisRaw("Horizontal");
    //    float moveY = Input.GetAxisRaw("Vertical");

    //    //if (moveX != 0 && moveY != 0)
    //    //{ anim.SetBool("iswalk", true); }
    //    moveDiraction = new Vector2(moveX, moveY);

    //}



    void Move()
    {
        rb.velocity = new Vector2(moveDiraction.x * movespeed, moveDiraction.y * movespeed);
    }

    //float moveInput = Input.GetAxisRaw("Horizontal");
    //float moveInput2 = Input.GetAxisRaw("Vertical");

    void Animation()
    {
        if (moveInput == 0)
        {
            anim.SetBool("iswalk", false);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
     

//Vector3 characterScale = Transform.localScale;



}
