using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject currentMosnter;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Vector3 mousePoint = Input.mousePosition;

        Ray rayPos = Camera.main.ScreenPointToRay(mousePoint);
        Debug.Log("aqui");

        Physics.Raycast(rayPos, out RaycastHit hit, LayerMask.GetMask("Monster"));
        if (hit.collider)
        {
            Debug.Log("aqui");
            currentMosnter = hit.transform.gameObject;
        }
    }
}
