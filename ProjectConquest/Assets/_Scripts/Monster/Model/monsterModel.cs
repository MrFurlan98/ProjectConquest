using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterModel : MonoBehaviour
{
    protected int range =3;

    public int Range
    {
        get
        {
            return range;
        }

        set
        {
            range = value;
        }
    }
}
