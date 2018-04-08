using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public bool player1;
    public float speed;
    public float turnspeed;
    private Rigidbody rb;
    private float inputHorizontal;
    private float inputVertical;



    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (player1)
        {
            inputHorizontal = Input.GetAxis("CatHorizontal");
            inputVertical = Input.GetAxis("CatVertical");
        }
        else
        {
            inputHorizontal = Input.GetAxis("MouseHorizontal");
            inputVertical = Input.GetAxis("MouseVertical");
        }

        Vector3 targetDir;

        move(inputHorizontal, inputVertical);

        if ((inputHorizontal == 0) && (inputVertical == 0))
        {

            targetDir = rb.rotation * Vector3.forward;
        }
        else
        {
            targetDir = new Vector3(inputHorizontal, 0f, inputVertical);
        }

        //Debug.Log("Target Dir: (" + Input.GetAxis("CatHorizontal") + ",0," + Input.GetAxis("CatVertical") + ")");

        float step = turnspeed * Time.deltaTime;
        Quaternion forwardDir = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0);
        Quaternion targetQuar = Quaternion.LookRotation(targetDir.normalized);
        transform.rotation = Quaternion.Slerp(forwardDir, targetQuar, Time.deltaTime * turnspeed);


    }

    public  void move(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = (movement * speed) + (new Vector3(0.0f, rb.velocity.y, 0.0f));

    }

}
