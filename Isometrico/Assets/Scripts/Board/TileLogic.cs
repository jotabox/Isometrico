using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{

    public Vector3Int Cellpo; //posição
    public Vector3 worldPos; // posição no mundo
    public GameObject content; //objeto player ou algo que esteja naquele espaço
    public Floor floor;
    public int contentOrder;
    //public TileType tiletype

    public TileLogic()
    {
         
    }

    public TileLogic(Vector3Int cellPosition, Vector3 worldPosition, Floor tempFloor)
    {
     
        Cellpo = cellPosition;
        worldPos = worldPosition;
        floor = tempFloor;
        contentOrder = tempFloor.contentOrder;
    }

    public static TileLogic Create(Vector3Int cellPosition, Vector3 worldPosition, Floor tempFloor)
    {
        TileLogic tileLogic = new TileLogic(cellPosition, worldPosition, tempFloor);
        return tileLogic;

    }
}
