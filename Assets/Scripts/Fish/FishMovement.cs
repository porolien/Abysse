using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public Transform body;

    private FishMain _main;

    public void Init(FishMain main)
    {
        _main = main;
        main.movement = this;
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
