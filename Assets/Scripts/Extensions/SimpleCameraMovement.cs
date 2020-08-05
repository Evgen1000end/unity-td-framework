﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public float zoomSpeed;
 
    public float minZoomDist;
    public float maxZoomDist;
 
    private Camera cam;
    
    void Awake ()
    {
        cam = Camera.main;
    }

    void Update ()
    {
        Move();
        Zoom();
    }
 
    void Move ()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        Vector3 dir = transform.forward * zInput + transform.right * xInput;
 
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
 
    void Zoom ()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);

        // if (scrollInput != 0)
        // {
        //     Debug.Log("dist:" + dist + " scrollInput " + scrollInput) ;
        //
        // }
        
        
        if(dist < minZoomDist && scrollInput > 0.0f)
            return;
        if(dist > maxZoomDist && scrollInput < 0.0f)
            return;

        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
    }
    
    public void FocusOnPosition (Vector3 pos)
    {
        transform.position = pos;
    }
}
