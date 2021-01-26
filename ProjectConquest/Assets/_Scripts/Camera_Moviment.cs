using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Moviment : MonoBehaviour
{
    public GameObject cameraRef;
    public float offset;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraRef.transform.position, offset);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRef.transform.rotation, offset);
    }
}
