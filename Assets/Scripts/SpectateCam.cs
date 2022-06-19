using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectateCam : MonoBehaviour
{
    public Transform pivotPoint;
    public float offsetBack = 3f;

    void LateUpdate()
    {
        transform.rotation = (pivotPoint.transform.rotation);
        transform.position = pivotPoint.transform.position + offsetBack * -transform.forward;
    }
}
