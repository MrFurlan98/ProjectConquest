using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMonster : MonoBehaviour
{
    private Vector3 mOffset;

    public Transform monPos;

    public GameObject highlight;
    public GameObject m_grid;

    private highlight[,] m_gridhighlights;

    public int range;
    public int initialPosX;
    public int initialPosZ;

    private void Start()
    {
        m_gridhighlights = m_grid.GetComponent<createPath>().m_highlightPos;
    }
    private void Update()
    {

        //limiting monster movement to the range
        //if (Input.GetMouseButton(0))
        //{
        //    if (Mathf.Abs(initialPosX - transform.position.x) + Mathf.Abs(initialPosZ - transform.position.z) >= range)
        //    {
        //        transform.position = new Vector3(monPos.position.x, -.49f, monPos.position.z);
        //    }
        //}
    }
    private void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        initialPosX = (int)monPos.position.x;
        initialPosZ = (int)monPos.position.z;
        ShowPath(true);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        Ray rayPos = Camera.main.ScreenPointToRay(mousePoint);

        Physics.Raycast(rayPos, out RaycastHit hit, LayerMask.GetMask("Floor"));
        if (hit.collider)
        {
            return hit.point;
        }

        return Vector3.positiveInfinity;
    }

    public void ShowPath(bool show)
    {
        for (int i = initialPosX - range; i <= initialPosX + range; i++)
        {
            for(int j = initialPosZ - range; j <= initialPosZ + range; j++)
            {
                if(Mathf.Abs(initialPosX-i) + Mathf.Abs(initialPosZ-j) <= range)
                {
                    m_gridhighlights[i, j].gameObject.SetActive(show);
                }   
            }
        }
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
        ShowPath(false);
    }
}
