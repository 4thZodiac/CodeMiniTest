using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Movement speed of Player
    public float speed;

    //For jump
    private Rigidbody rb;
    public bool onGround;

    
    bool planeB = false;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Grab players positions and in a variable.
        float CharZ = gameObject.transform.position.z;
        float CharX = gameObject.transform.position.x;

        //If player is on planeA
        if (planeB == false)
        {
            //ONLY ABLE TO MOVE planeA

            //Player can go forward and Position Z is less than or equals to 10
            if (Input.GetKey(KeyCode.W) && CharZ <= 10)
            {
                {
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
            }

            //Player can go backwards and Position Z is more than or equals to -10
            if (Input.GetKey(KeyCode.S) && CharZ >= -10)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }

            //Player can move left and Position X is more than or equals to -10
            if (Input.GetKey(KeyCode.A) && CharX >= -10)
            {
                transform.position -= transform.right * Time.deltaTime * speed;
            }

            //Player can move left and Position X is less than or equals to 10
            if (Input.GetKey(KeyCode.D) && CharX <= 10)
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }
        }

        //When player is
        else if (planeB == true)
        {
            //ONLY ABLE TO MOVE WITHIN planeB

            //Player can move forward and Position Z is more than or equals to -20
            if (Input.GetKey(KeyCode.W) && CharZ <= 20)
            {
                {
                    transform.position += transform.forward * Time.deltaTime * speed;
                }
            }

            //Player can go backwards and Position Z is more than or equals to -20
            if (Input.GetKey(KeyCode.S) && CharZ >= -20)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }

            //Player can move left and Position X is more than or equals to -5
            if (Input.GetKey(KeyCode.A) && CharX >= -5)
            {
                transform.position -= transform.right * Time.deltaTime * speed;
            }

            //Player can move left and Position X is less than or equals to 5
            if (Input.GetKey(KeyCode.D) && CharX <= 5)
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }
        }

        //When player is on planeB
        if(CharZ > 10 && (CharX>=-5 && CharX <= 5))
        {
            planeB = true;
        }

        //Back to planeA
        if (CharZ < 10)
        {
            planeB = false;
        }
       
        //If Space is pressed, player jumps.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0f, 5f, 0f);
            onGround = false;
        }


    }
        
}
