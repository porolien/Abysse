using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("stuck");
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            rb.useGravity = false;
            GetComponent<SphereCollider>().enabled = false;
        }
    }

}
