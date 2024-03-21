using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerInputs input;
    public PlayerLight lights;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
