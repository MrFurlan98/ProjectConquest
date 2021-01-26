using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMonster : MonoBehaviour
{
    private Vector3 mOffset;

    public Transform monPos;
    public Transform miragePos;
    public Transform cameraRef;

    public GameObject m_grid;

    private highlight[,] m_gridhighlights;

    public int range;
    public int initialPosX;
    public int initialPosZ;

    private void OnMouseDown()
    {
        m_gridhighlights = m_grid.GetComponent<createPath>().m_highlightPos;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        initialPosX = (int)monPos.position.x;
        initialPosZ = (int)monPos.position.z;
        cameraRef.SetParent(miragePos);
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
                if(IsInRange(i,j))
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
            Vector3 tPos = GetMouseWorldPos() + mOffset;
            if(IsInRange((int)tPos.x,(int)tPos.z)){
                transform.position = GetMouseWorldPos() + mOffset;
                miragePos.position = new Vector3(Mathf.Floor(transform.position.x / 1) * 1, 0, Mathf.Floor(transform.position.z / 1) * 1);
            }
            
        }
        
    }

    private bool IsInRange(int x, int z)
    {
        if (Mathf.Abs(initialPosX - x) + Mathf.Abs(initialPosZ - z) <= range)
        {
            return true;
        }
        return false;
    }

    private void OnMouseUp()
    {    
        gameObject.transform.position = monPos.position;
        cameraRef.SetParent(null);
        ShowPath(false);
    }
}
