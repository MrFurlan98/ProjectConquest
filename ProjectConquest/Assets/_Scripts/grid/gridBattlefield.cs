using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridBattlefield : MonoBehaviour
{

    public GameObject target;
    public GameObject monster;
    Vector3 finalPos;
    public float cellSize;
    public float offset;

    void LateUpdate()
    {
        finalPos.x = Mathf.Floor( target.transform.position.x / cellSize ) * cellSize + offset;
        finalPos.y = this.transform.position.y + offset;
        finalPos.z = Mathf.Floor( target.transform.position.z / cellSize ) * cellSize + offset;

        monster.transform.position = finalPos;
    }
}
