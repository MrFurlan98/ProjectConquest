using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMonster : MonoBehaviour
{
    private Vector3 mOffset;

    public Transform monPos;

    private void Update()
    {
        Debug.Log(GetMouseWorldPos());
        //transform.position = GetMouseWorldPos();
    }
    private void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        // mousePoint.z = mZCoord;

        Ray rayPos = Camera.main.ScreenPointToRay(mousePoint);

        Physics.Raycast(rayPos, out RaycastHit hit, LayerMask.GetMask("Floor"));
        if (hit.collider)
        {
            return hit.point;
        }

        return Vector3.positiveInfinity;
    }

    private void OnMouseDrag()
    {
        if(GetMouseWorldPos() != Vector3.positiveInfinity)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
        
    }

    private void OnMouseUp()
    {
        gameObject.transform.position = monPos.position;
    }
}
