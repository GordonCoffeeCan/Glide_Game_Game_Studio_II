using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlScript : MonoBehaviour
{


    public float speed;
    public float jumpAmount;
    public float glideAmount;

    
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode diveKey = KeyCode.LeftShift;

    public static bool isGliding = false;

    public static float playerGravityScale = 1;

    public static playerControlScript instance;
    

    public Rigidbody2D rb;
    public Rigidbody2D rocket;

    private bool onGround = false;

    public GameObject wing1;
    public GameObject wing2;

    // Use this for initialization
    void Start()
    {

        ShowWings(wing1, wing2, false);

    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        if(isGliding == true) {
            playerGravityScale = 0.2f;
        } else {
            playerGravityScale = 1;
        }

        rb.gravityScale = playerGravityScale;
    }

    private void FixedUpdate() {
        //Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);
    }

    void Move(Vector3 dir, KeyCode key)
    {

        if (Input.GetKey(key))
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }

    }

    void Jump()
    {
        

        if (Input.GetKeyDown(jumpKey) && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpAmount);
            onGround = false;

        }
        else if (Input.GetKeyDown(jumpKey))
        {
            rb.gravityScale = glideAmount;
            ShowWings(wing1, wing2, true);
            isGliding = true;
      
        }

        else if (Input.GetKeyDown(diveKey))
        {
            rb.gravityScale = 10;
            ShowWings(wing1, wing2, false);
            isGliding = false;
        }

        else if (Input.GetKeyUp(jumpKey))
        {
            rb.gravityScale = 1;
            ShowWings(wing1, wing2, false);
            isGliding = false;
        }


        else if (Input.GetKeyUp(diveKey))
        {
            rb.gravityScale = 1;
            ShowWings(wing1, wing2, false);
            isGliding = false;
        }




    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        //Debug.Log("Dragon");
    }

    private void ShowWings(GameObject _wing1, GameObject _wing2, bool _isShow = false) {
        _wing1.SetActive(_isShow);
        _wing2.SetActive(_isShow);
    }
}
