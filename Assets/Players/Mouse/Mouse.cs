using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("MouseHorizontal");
        float moveVertical = Input.GetAxis("MouseVertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
    }
}
