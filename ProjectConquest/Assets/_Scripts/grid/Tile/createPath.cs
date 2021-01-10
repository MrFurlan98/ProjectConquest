using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPath : MonoBehaviour
{
    public int fieldSize;

    public highlight[,] m_highlightPos;

    [SerializeField]
    public GameObject Hlight;
    // Start is called before the first frame update
    void Start()
    {
        m_highlightPos = new highlight[fieldSize, fieldSize];
        Vector3 tPos = new Vector3(0, -.49f, 0);
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                tPos.x = i;
                tPos.z = j;
                Instantiate(Hlight, tPos, Hlight.transform.rotation,transform);
            }
        }
        Transform thighlight;
        for (int i = 0; i < fieldSize*fieldSize; i++)
        {
            thighlight = gameObject.transform.GetChild(i);
            thighlight.GetComponent<highlight>().SetPosition();
            m_highlightPos[thighlight.GetComponent<highlight>().row, thighlight.GetComponent<highlight>().colunm] = thighlight.GetComponent<highlight>();
            thighlight.gameObject.SetActive(false);
        }
    }
}
