using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMonster : MonoBehaviour
{

    public GameObject target;
    Vector3 finalPos;
    public float cellSize;
    public float offset;

    private void OnMouseDown()
    {
        Vector3 mousePoint = Input.mousePosition;

        Ray rayPos = Camera.main.ScreenPointToRay(mousePoint);
        Debug.Log("aqui");


        Physics.Raycast(rayPos, out RaycastHit hit, LayerMask.GetMask("Monster"));
        if (hit.collider)
        {
            Debug.Log("aqui");  
            target = hit.transform.gameObject;
        }

    }
    private void OnMouseUp()
    {
        finalPos.x = Mathf.Floor(target.transform.position.x / cellSize) * cellSize;
        finalPos.y = this.transform.position.y + offset;
        finalPos.z = Mathf.Floor(target.transform.position.z / cellSize) * cellSize;

        transform.position = finalPos;
    }
}
