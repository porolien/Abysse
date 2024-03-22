using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLight : MonoBehaviour
{
    public bool lightIsOn;

    [SerializeField]
    private GameObject _objectThrownPrefab;

    [SerializeField]
    private Transform _posObjectThrown;

    [SerializeField] 
    private float _objectThrownSpeed;

    [SerializeField]
    private float _maxGlowStick;

    [SerializeField]
    private GameObject lightPrefab;

    private PlayerMain _main;


    public void Init(PlayerMain main)
    {
        main.lights = this;
        _main = main;
    }

    public void LightChanged()
    {
        if (_main.lights.lightIsOn)
        {
            _main.lights.lightIsOn = false;
            lightPrefab.SetActive(false);
            LightManager.instance.lights.Remove(lightPrefab.transform);
        }
        else
        {
            _main.lights.lightIsOn = true;
            lightPrefab.SetActive(true);
            LightManager.instance.lights.Add(lightPrefab.transform);
        }
    }

    public void ThrowALight()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Debug.Log(hit.point);
            GameObject newObjectThrown = Instantiate(_objectThrownPrefab, _posObjectThrown);
            newObjectThrown.transform.parent = null;
            LightManager.instance.lights.Add(newObjectThrown.transform);
            Vector2 direction = hit.point - newObjectThrown.transform.position;
            newObjectThrown.GetComponent<Rigidbody>().velocity = new Vector2(direction.x, direction.y).normalized * _objectThrownSpeed;
        }
    }   
}
