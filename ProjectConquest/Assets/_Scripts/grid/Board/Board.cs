using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Board : MonoBehaviour
{
    [SerializeField]
    private int xSize;
    [SerializeField]
    private int ySize;
    private GameObject tile;
    private GameObject[,] m_Tiles;

    public GameObject[,] Tiles { get => m_Tiles; set => m_Tiles = value; }

    void Start()
    {
        m_Tiles = new GameObject[xSize, ySize];
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        tile = (GameObject)Resources.Load("Tile");
        GameObject tempField = null;
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                tempField = GameObject.Instantiate(tile, new Vector3(i, -0.05f, j), Quaternion.identity);
                tempField.transform.parent = this.transform;
                Tiles[i, j] = tempField;
            }
        }
    }
}
