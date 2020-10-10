using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public Vector3 offset;
    public float pitch = 2f;
    private float cZoom = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * cZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
