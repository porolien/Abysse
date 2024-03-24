using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    public static LimitManager instance;

    public float maxLimit;
    public float minLimit;

    void Awake()
    {
        instance = this;
    }
}
