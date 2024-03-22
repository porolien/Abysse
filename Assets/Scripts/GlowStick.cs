using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    [SerializeField]
    private float _delay;

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
            StartCoroutine(DelayBeforeDisparition());
            //Lancer une anim pour baisser la lumière de 100% à 0%
        }
    }

    private IEnumerator DelayBeforeDisparition()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }

}
