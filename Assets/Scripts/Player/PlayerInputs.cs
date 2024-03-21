using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerMain _main;
    private bool _oldDirection;

    public void Init(PlayerMain main)
    {
        main.input = this;
        _main = main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMovement(InputValue _value)
    {
        _main.movement.direction = _value.Get<Vector2>();
        _main.movement.directionRotate = new Vector3(0, 0, FindDirection());
    }

    public void OnLightOn()
    {
        _main.lights.LightChanged();
    }

    public void OnThrow()
    {
        _main.lights.ThrowALight();
    }

    private float FindDirection()
    {
        float directionRotatationBody = 360;

        if (!_oldDirection)
        {
            switch (_main.movement.direction)
            {

                case Vector2 v when v.Equals(Vector2.up):
                    Debug.Log("up");
                    _oldDirection = true;
                    break;
                case Vector2 v when v.Equals(Vector2.zero):
                    Debug.Log("zero");
                    _oldDirection = false;
                    break;
                case Vector2 v when v.Equals(Vector2.down):
                    Debug.Log("down");
                    directionRotatationBody = 180;
                    _oldDirection = true;
                    break;
                case Vector2 v when v.Equals(Vector2.left):
                    Debug.Log("left");
                    directionRotatationBody = 90;
                    _oldDirection = true;
                    break;
                case Vector2 v when v.Equals(Vector2.right):
                    Debug.Log("right");
                    directionRotatationBody = 270;
                    _oldDirection = true;
                    break;
            }
        }
        else if(_main.movement.direction != Vector2.zero)
        {
            float x = 1;
            float y = 1;
            if (_main.movement.direction.x < 0)
            {
                x = -1;
            }

            if (_main.movement.direction.y < 0)
            {
                y = -1;
            }

            switch (new Vector2(x, y))
            {
                case Vector2 v when v.Equals(Vector2.one):
                    Debug.Log("one");
                    directionRotatationBody = 315;
                    _oldDirection = false;
                    break;
                case Vector2 v when v.Equals(-Vector2.one):
                    Debug.Log("-one");
                    directionRotatationBody = 135;
                    _oldDirection = false;
                    break;
                case Vector2 v when v.Equals(new Vector2(-1, 1)):
                    Debug.Log("-1, 1");
                    directionRotatationBody = 45;
                    _oldDirection = false;
                    break;
                case Vector2 v when v.Equals(new Vector2(1, -1)):
                    Debug.Log("1, -1");
                    directionRotatationBody = 225;
                    _oldDirection = false;
                    break;
            }
        }

        return directionRotatationBody;
    }
}
