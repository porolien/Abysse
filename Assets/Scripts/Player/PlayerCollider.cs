using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{    
    private PlayerMain _main;

    public void Init(PlayerMain main)
    {
        _main = main;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FishMain>() != null)
        {
            Debug.Log("dead");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndLevel>() != null)
        {
            Debug.Log("End");
        }

        if (other.gameObject.tag == "Seaweed")
        {
            _main.movement.speed = _main.movement.slowSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Seaweed")
        {
            _main.movement.speed = _main.movement.normalSpeed;
        }
    }
}
