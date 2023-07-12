using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{

    [HideInInspector] public TilemapRenderer tilemapRender;
    public int order { get { return tilemapRender.sortingOrder;}} // ordem do andar
    public int contentOrder; //ordem do conteudo
    //limites do tabuleiro
    public Vector3Int minXY;
    public Vector3Int maxXY;
    [HideInInspector] public Tilemap tilemap;

    public void Awake()
    {
       tilemapRender = this.transform.GetComponent<TilemapRenderer>();
        tilemap = GetComponent<Tilemap>();
    }


    public List<Vector3Int> LoadTiles()
    {
        List<Vector3Int> tiles = new List<Vector3Int>();
        for (int i = minXY.x; i <= maxXY.x; i++)
        {
            for (int j = minXY.y; j <= maxXY.y; j++)
            {
                Vector3Int currentPosition = new Vector3Int(i, j, 0);
                if (tilemap.HasTile(currentPosition))
                {
                    tiles.Add(currentPosition);
                }
            }
        }
        return tiles;
    }

}
