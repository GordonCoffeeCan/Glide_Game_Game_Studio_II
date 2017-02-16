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

    public bool isGliding = false;

    public static playerControlScript instance;
    

    public Rigidbody2D rb;
    public Rigidbody2D rocket;

    private bool onGround = false;

    public GameObject wing1;
    public GameObject wing2;

    // Use this for initialization
    void Start()
    {

        wing1.active = false;
        wing2.active = false;

    }

    // Update is called once per frame
    void Update()
    {

        
        Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);
        Jump();
       
    }

    void Move(Vector3 dir, KeyCode key)
    {

        if (Input.GetKey(key))
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }

    }

    void Jump()
    {
        

        if (Input.GetKeyDown(jumpKey) && onGround == true)
        {
            rb.AddForce(Vector3.up*jumpAmount);
            onGround = false;

        }
        else if (Input.GetKeyDown(jumpKey))
        {
            rb.gravityScale = glideAmount;
            wing1.active = true;
            wing2.active = true;
            isGliding = true;
      
        }

        else if (Input.GetKeyUp(jumpKey))
        {
            rb.gravityScale = 1;
            wing1.active = false;
            wing2.active = false;
            isGliding = false;
        }




    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            onGround = true;
        }
        

        Debug.Log("Dragon");
    }

   


}
