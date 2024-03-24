using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDetection : MonoBehaviour
{
    public float lightDetectionRange = 10f;

    public float playerDetectionRange = 2f;

    public event Action<Transform> seeALight;

    private bool _hasDetect;
    private FishMain _main;

    // Start is called before the first frame update
    public void Init(FishMain main)
    {
        _main = main;
        main.detection = this;
    }

    void Update()
    {
        // Parcourir toutes les lumi�res enregistr�es dans le gestionnaire
        Transform target = null;
        float closestDistance = Mathf.Infinity;
        float distanceToTarget = Vector3.Distance(transform.position, LightManager.instance.playerTransform.position);

        // Si le joueur est � port�e on ne va pas chercher une light
        if (distanceToTarget < playerDetectionRange)
        {
            closestDistance = distanceToTarget;
            target = LightManager.instance.playerTransform;
        }
        else
        {
            foreach (Transform lightTransform in LightManager.instance.lights)
            {
                if (lightTransform.position.y < LimitManager.instance.maxLimit || lightTransform.position.y > LimitManager.instance.minLimit)
                {
                    distanceToTarget = Vector3.Distance(transform.position, lightTransform.position);
                    // V�rifier si la lumi�re est � port�e et plus proche que la lumi�re actuelle la plus proche
                    if (distanceToTarget < lightDetectionRange && distanceToTarget < closestDistance)
                    {
                        closestDistance = distanceToTarget;
                        target = lightTransform;
                    }
                }
                
            }
        }

        if (target != null)
        {
            if(seeALight != null)
            {
                seeALight(target);
            }

            // D�placer l'ennemi vers la lumi�re la plus proche ou le joueur
            Vector3 oppositeDirection = Vector3.zero;

            if (_main.afraidByLight)
            {
                oppositeDirection = transform.position - target.position;
            }

            transform.LookAt(target.position + oppositeDirection);
        }
    }
}
