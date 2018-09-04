using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_PlatformController : MonoBehaviour
{

    public float speed = 10f;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.up * speed * Input.GetAxis("Vertical");

    }
}
