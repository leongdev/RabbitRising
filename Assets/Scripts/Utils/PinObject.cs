using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObject : MonoBehaviour
{
    [Header("[Pin Settings]")]
    [SerializeField] bool canPinObject;
    [SerializeField] GameObject target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
    }

    public void SetPinObjectState(bool state) 
    {
        canPinObject = state;
    }

    public void SetTargetObject(GameObject other) 
    {
        target = other;
    }
}
