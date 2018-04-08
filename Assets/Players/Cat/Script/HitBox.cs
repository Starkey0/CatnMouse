using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

    private bool hit;

    // Use this for initialization
    void Start() {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay(Collider other) {
        hit = true;
    }
    void OnTriggerEnter(Collider other)
    {
        hit = true;
    }

    public bool getHit() {
        return hit;
    }
    public void setHit(bool hit) {
        this.hit = hit;
    }
}
