using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller1 : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float updatedPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.back * updatedPosition;     
    }
}
