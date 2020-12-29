using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsPinObject : MonoBehaviour
{
    [Header("PIN SETTINGS")]
    [SerializeField] bool canPinObject;
    [SerializeField] GameObject target;

    // Update is called once per frame
    void Update()
    {
        if(canPinObject) transform.position = target.transform.position;
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
