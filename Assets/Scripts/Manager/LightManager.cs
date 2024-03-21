using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager instance;
    public Transform playerTransform;
    public List<Transform> lights = new List<Transform>();

    void Awake()
    {
        instance = this;
    }
}
