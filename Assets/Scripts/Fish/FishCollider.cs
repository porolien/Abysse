using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMain>() != null)
        {
            Destroy(collision.gameObject);
            Debug.Log("dead");
        }
    }
}
