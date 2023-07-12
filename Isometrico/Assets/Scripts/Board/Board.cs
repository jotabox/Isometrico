using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public Dictionary<Vector3Int, TileLogic> tiles;// dicionario para facilitar a busca , sem percorrer tudo , tipo uma lista
    public List<Floor> floorList;
    public static Board instance;//singlenton
    [HideInInspector]public Grid grid;

    private void Start()
    {
        InitSequence();
    }

    void Awake()
    {
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }


    public void InitSequence()
    {
        LoadFloors();
        Debug.Log("foram criados " +  tiles.Count + "tiles");
    }


    public void LoadFloors()
    {
        for (int i = 0; i <floorList.Count; i++) 
        {
            List<Vector3Int> floorTiles = floorList[i].LoadTiles();// percorre todos os tiles 
            for (int j = 0; j< floorTiles.Count; j++)
            {
                if (!tiles.ContainsKey(floorTiles[j]))// verifica se ainda nao esta no dicionario , se nao tiver cria
                {
                    CreateTile(floorTiles[j], floorList[i]);
                }
            }
        
        }
    }


    public void CreateTile(Vector3Int position , Floor floor)
    {
        Vector3 worldPos = grid.CellToWorld(position); // recuperando o valor da possição
        worldPos.y += floor.tilemap.tileAnchor.y / 2; // compensando o offset dos andares
        TileLogic tileLogic = new TileLogic(position, worldPos, floor); 
        tiles.Add(position, tileLogic); 
    }
}
