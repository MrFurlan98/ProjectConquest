using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour
{
    public int colunm;
    public int row;

    public void SetPosition()
    {
        colunm = (int)transform.position.z;
        row = (int)transform.position.x;
    }

}
