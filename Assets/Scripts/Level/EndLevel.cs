using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMain>() != null)
        {
            Debug.Log("End");
        }
    }
}
