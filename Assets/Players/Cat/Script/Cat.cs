using UnityEngine;
using System.Collections;
using System;

public class Cat : MonoBehaviour {

    public float speed;
    public float slowDiv;
    public float pounceSpeed;
    public GameObject hitbox;
    public float turnspeed;

    private float initSpeed;
    private Rigidbody rb;
    private HitBox hitboxScript;
    private bool boolPounce;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        hitboxScript = hitbox.GetComponent<HitBox>();
        initSpeed = speed;
        boolPounce = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir;

        move(Input.GetAxis("CatHorizontal"), Input.GetAxis("CatVertical"));

        if ((Input.GetAxis("CatHorizontal") == 0) && (Input.GetAxis("CatVertical") == 0))
        {
            
            targetDir = rb.rotation * Vector3.forward;
        }
        else
        {
            targetDir = new Vector3(Input.GetAxis("CatHorizontal"), 0f, Input.GetAxis("CatVertical"));
        }
        
        //Debug.Log("Target Dir: (" + Input.GetAxis("CatHorizontal") + ",0," + Input.GetAxis("CatVertical") + ")");

        float step = turnspeed * Time.deltaTime;
        Quaternion forwardDir = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0);
        Quaternion targetQuar = Quaternion.LookRotation(targetDir.normalized);
        transform.rotation = Quaternion.Slerp(forwardDir, targetQuar, Time.deltaTime * turnspeed);
  
        


        if (Input.GetButton("CatPounce")) speed = initSpeed/slowDiv;
        else speed = initSpeed;

        if ((Input.GetButtonUp("CatPounce")) || boolPounce)
        {
            Pounce();
            if (!boolPounce) StartCoroutine(activateHitBox());
        }
    }

    private void move(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = (movement * speed) + (new Vector3(0.0f, rb.velocity.y, 0.0f));
        
    }

    void Pounce()
    {
        //rb.velocity = movement * pounceSpeed;
        //rb.velocity = transform.forward * 100;
        rb.AddForce(transform.forward*pounceSpeed, ForceMode.Acceleration);
        Debug.Log("Load");
    }

    IEnumerator activateHitBox()
    {
        yield return new WaitForSeconds(0.5f);

 
        hitbox.SetActive(true);
        boolPounce = true;

        if (hitboxScript.getHit())
        {
            Debug.Log("Caught the mouse! " + hitbox.active);
        }

        yield return new WaitForSeconds(1f);

        hitbox.SetActive(false);
        boolPounce = false;
    }
}
