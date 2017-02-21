using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlScript : MonoBehaviour
{


    public float speed = 5;
    public float jumpAmount;
    public float glideAmount;
    public float diveAmount;

    
    public KeyCode downKey = KeyCode.S;
    //public KeyCode leftKey = KeyCode.A;
    //public KeyCode rightKey = KeyCode.D;
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

    private float lastVelocityX;
    private bool isBoost = false;

    // Use this for initialization
    void Start()
    {

        ShowWings(wing1, wing2, false);

    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        if (isGliding == true) {
            playerGravityScale = glideAmount;
        } else {
            playerGravityScale = 1;
            windPush._windPushed = false;
        }
        rb.gravityScale = playerGravityScale;

        if (Input.GetKey(KeyCode.LeftAlt)) {
            isBoost = true;
        }else if (Input.GetKeyUp(KeyCode.LeftAlt)) {
            isBoost = false;
        }

        if (rb.velocity.x > 0) {
            lastVelocityX = 1;
        } else if (rb.velocity.x < 0) {
            lastVelocityX = -1;
        } else {
            lastVelocityX = 0;
        }
    }

    private void FixedUpdate() {
        //Move(Vector3.down, downKey);
        if (isBoost == false) {
            Move(Vector3.right, "Horizontal");
        } else {
            Boost();
        }
    }

    void Move(Vector3 _dir, string _axis)
    {
        rb.velocity = new Vector2(_dir.x * Input.GetAxis(_axis) * speed, rb.velocity.y);
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
            rb.gravityScale = diveAmount;
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
            rb.gravityScale = 5;
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

    private void Boost() {
        rb.velocity = new Vector2(lastVelocityX * speed * 3, rb.velocity.y);
    }
}
