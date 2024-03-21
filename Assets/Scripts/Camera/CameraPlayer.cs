using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
   /* [SerializeField]
    private float targetY;

    [SerializeField]
    public float targetZ;

    [SerializeField]
    public float smoothTime = 0.1f;*/

    private Transform _player;
   // private Vector3 vel;

    private void Awake()
    {
        PlayerMain player = (PlayerMain)FindAnyObjectByType(typeof(PlayerMain));
        _player = player.transform;
        _player.GetComponent<PlayerMovement>().Move += WhenPlayerMove; 
        LightManager.instance.playerTransform = _player;
    }

    private void WhenPlayerMove()
    {
       /* Vector3 target = transform.position;
        target.x = _player.transform.position.x;
        target.y = targetY;
        target.z = targetZ;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);*/
        transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }

}
