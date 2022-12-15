using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float zoomChangeSpeed = 10f;


    new Transform transform;
    Camera cam;


    Vector3 recentMousePos = new Vector3();
    Vector3 recentPos = new Vector3();

    private void Start() {
        transform = GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            recentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            recentPos = cam.ScreenToWorldPoint(transform.position);
        }
        if(Input.GetMouseButton(1)) {
            moveByMouse();
        }

        cam.orthographicSize -= zoomChangeSpeed*cam.orthographicSize*Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime;
    }

    private void moveByMouse() {
        Vector3 moveVec = recentMousePos - cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position += moveVec;

        recentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        recentPos = cam.ScreenToWorldPoint(transform.position);
    }

}
