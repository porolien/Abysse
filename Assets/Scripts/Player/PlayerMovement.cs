using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 direction;
    public Vector3 directionRotate;

    public event Action Move;

    public float speed;

    public float slowSpeed;

    public float normalSpeed;

    [SerializeField]
    private float _angularSpeed;

    [SerializeField]
    private Transform _body;

    private PlayerMain _main;

    public void Init(PlayerMain main)
    {
        main.movement = this;
        _main = main;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = normalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (direction !=  Vector2.zero)
        {
            Move();
        }
        
        Rotate();
        /*if (Vector3.Distance(_body.transform.eulerAngles, directionRotate) > 0.01f)
        {
            _body.transform.eulerAngles = Vector3.Lerp(_body.rotation.eulerAngles, directionRotate, Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = directionRotate;
        }*/


    }

    void Rotate()
    {
        if (_body.eulerAngles.z > directionRotate.z)
        {
            if (_body.eulerAngles.z - directionRotate.z <  360 - _body.eulerAngles.z + directionRotate.z)
            {
                _angularSpeed = -Mathf.Abs(_angularSpeed);
            }
            else
            {
                _angularSpeed = Mathf.Abs(_angularSpeed);
            }

        }
        else
        {
            if (directionRotate.z - _body.eulerAngles.z < 360 - directionRotate.z + _body.eulerAngles.z)
            {
                _angularSpeed = Mathf.Abs(_angularSpeed);
            }
            else
            {
                _angularSpeed = -Mathf.Abs(_angularSpeed);
            }

        }

        float angle = Mathf.Abs(directionRotate.z - _body.eulerAngles.z);
        //Debug.Log(angle);

        if (angle > 2)
        {
            _body.rotation *= Quaternion.AngleAxis(_angularSpeed, Vector3.forward);
        }
        else
        {
            _body.rotation *= Quaternion.AngleAxis(0, Vector3.forward);
        }
    }
}
