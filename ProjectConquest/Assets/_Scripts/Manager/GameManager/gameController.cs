using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    private Vector3 mOffset;

    private GameObject currentMonster;
    public GameObject board;

    private Transform target;
    private Transform mirage;

    private int range;
    private int initialPosX;
    private int initialPosZ;

    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentMonster == null)
            {
                Vector3 mousePoint = Input.mousePosition;
                Ray rayPos = Camera.main.ScreenPointToRay(mousePoint);

                Physics.Raycast(rayPos, out RaycastHit hit, LayerMask.GetMask("Monster"));
                if (hit.collider)
                {
                    currentMonster = hit.transform.parent.gameObject;
                    SetCurrentMonster();
                    ShowPath(true);
                    StartCoroutine(MonsterRoutine());
                }     
            }
            else
            {
                ShowPath(false);
                currentMonster = null;
            }
        }
    }

    private void SetCurrentMonster() {
        
        range = currentMonster.GetComponent<monsterModel>().Range;
        target = currentMonster.transform.GetChild(0);
        mOffset = target.position - GetMouseWorldPos();
        initialPosX = (int)target.position.x;
        initialPosZ = (int)target.transform.position.z;   
        mirage = currentMonster.transform.GetChild(2);
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
            for (int j = initialPosZ - range; j <= initialPosZ + range; j++)
            {
                if (IsInRange(i, j))
                {
                    board.GetComponentInChildren<createPath>().m_highlightPos[i, j].gameObject.SetActive(show);
                }
            }
        }
    }

    private bool IsInRange(int x, int z)
    {
        int fieldSize = board.GetComponentInChildren<createPath>().fieldSize;
        if (x >= 0 && x < fieldSize && z >= 0 && z < fieldSize)
        {
            if (Mathf.Abs(initialPosX - x) + Mathf.Abs(initialPosZ - z) <= range)
            {
                return true;
            }
        }    
        return false;
    }
    IEnumerator MonsterRoutine()
    {
        if (!currentMonster)
        {
            yield break;
        }

        dragMonster drag = currentMonster.GetComponentInChildren<dragMonster>();

        while (currentMonster)
        {
            if (!currentMonster)
            {
                break;
            }
            if (GetMouseWorldPos() != Vector3.positiveInfinity)
            {
                Vector3 tPos = GetMouseWorldPos() + mOffset;
                if (IsInRange((int)Mathf.Floor(tPos.x), (int)Mathf.Floor(tPos.z)))
                {
                    target.position = GetMouseWorldPos() + mOffset;
                    mirage.position = new Vector3(Mathf.Floor(target.position.x / 1) * 1, 0, Mathf.Floor(target.position.z / 1) * 1);
                }

            }
            yield return null;
        }
        while(!drag.DragToPosition(1, 0.03f))
        {
            yield return null;
        }
    }
}
