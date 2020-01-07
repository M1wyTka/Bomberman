using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap mainTilemap;
    public GameObject entryCell;

    public GameObject[] topRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject deadEnd;

    void Start()
    {
        SpawnRoom(transform.position, entryCell);
    }

    public void SpawnRoom(Vector3 position, int direction)
    {
        int randInd = 0;
        switch (direction) {
            case 0:
                randInd = Random.Range(0, topRooms.Length);
                SpawnRoom(position, topRooms[randInd]);
                break;
            case 1:
                randInd = Random.Range(0, downRooms.Length);
                SpawnRoom(position, downRooms[randInd]);
                break;
            case 2:
                randInd = Random.Range(0, leftRooms.Length);
                SpawnRoom(position, leftRooms[randInd]);
                break;
            case 3:
                randInd = Random.Range(0, rightRooms.Length);
                SpawnRoom(position, rightRooms[randInd]);
                break;
            default: break;
        }
    }

    public void SpawnRoom(Vector3 position, GameObject cell)
    {
        GameObject go = Instantiate(cell, position, Quaternion.identity) as GameObject;
        go.transform.SetParent(GameObject.Find("Grid").transform);
        Tilemap sideTilemap = go.transform.GetComponent<Tilemap>();
        foreach (var pos in sideTilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = pos;
            if (sideTilemap.HasTile(localPlace))
            {
                Vector3 sideTilePlace = sideTilemap.CellToWorld(localPlace);

                mainTilemap.SetTile(mainTilemap.WorldToCell(sideTilePlace), sideTilemap.GetTile<Tile>(localPlace));
            }
        }
        sideTilemap.ClearAllTiles();
    }
}
