using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMonster : MonoBehaviour
{
    public Transform monPos;
    public Transform miragePos;
    public Transform cameraRef;

    Vector3 finalPos;


    private void OnMouseDown()
    {
        cameraRef.SetParent(miragePos);
    }

    public bool DragToPosition(float cellSize, float offset)
    {
        finalPos.x = Mathf.Floor(miragePos.transform.position.x / cellSize) * cellSize;
        finalPos.y = 0;
        finalPos.z = Mathf.Floor(miragePos.transform.position.z / cellSize) * cellSize;

        transform.position = finalPos;
        monPos.position = Vector3.Lerp(monPos.position, finalPos, offset);
        monPos.rotation = Quaternion.Lerp(monPos.rotation, miragePos.rotation, offset);

        cameraRef.SetParent(null);

        if (Vector3.Distance(monPos.position, finalPos) < 0.05)
        {
            monPos.position = finalPos;
            return true;
        }
        return false;
    }
}
