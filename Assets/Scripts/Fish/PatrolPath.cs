using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public List<Transform> patrolPoints = new List<Transform>();

    [HideInInspector]
    public Transform actualPoint;

    [HideInInspector]
    public int actualPointIndexer;

    private FishMain _main;

    public void Init(FishMain main)
    {
        _main = main;
        main.patrol = this;
    }
}
