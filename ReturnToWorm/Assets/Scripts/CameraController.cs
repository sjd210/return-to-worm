using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject worm;

    void Update()
    {
        cam.transform.position = worm.transform.position + Vector3.forward * -10f;
    }
}
