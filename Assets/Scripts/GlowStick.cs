using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowStick : MonoBehaviour
{
    [SerializeField]
    private float _delay;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Roc")
        {
            _rb.velocity = Vector3.zero;
            _rb.freezeRotation = true;
            _rb.useGravity = false;
            GetComponent<SphereCollider>().enabled = false;
            StartCoroutine(DelayBeforeDisparition());
            //Lancer une anim pour baisser la lumière de 100% à 0%
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Roc")
        {
            _rb.freezeRotation = false;
            _rb.useGravity = true;
            StopAllCoroutines();
        }
    }

    private IEnumerator DelayBeforeDisparition()
    {
        yield return new WaitForSeconds(_delay);
        LightManager.instance.lights.Remove(transform);
        Destroy(gameObject);
    }

}
