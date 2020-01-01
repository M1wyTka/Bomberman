using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap mainTilemap;
    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionCenter;
    public GameObject explosionLine;

    public GameObject[] upgrades;

    [SerializeField]
    private int droprate = 50;

    public void Explode(Vector3 center, int distance)
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.Explosion);
        Vector3Int bombPosition = mainTilemap.WorldToCell(center);
        Instantiate(explosionCenter, center, Quaternion.identity);
        DestroyInDirection(bombPosition, Vector3Int.right, distance);
        DestroyInDirection(bombPosition, Vector3Int.up, distance);
        DestroyInDirection(bombPosition, Vector3Int.left, distance);
        DestroyInDirection(bombPosition, Vector3Int.down, distance);
    }

    private void DestroyInDirection(Vector3Int center, Vector3Int direction, int distance)
    {
        for (int i = 1; i <= distance; i++)
        {
            Vector3Int lineCell = center + direction * i;
            Tile tile = mainTilemap.GetTile<Tile>(lineCell);
            Vector3 pos = mainTilemap.GetCellCenterWorld(lineCell);
            if (tile == wallTile)
                return;
            if (tile == destructibleTile)
            {
                mainTilemap.SetTile(lineCell, null);
                SpawnUpgrade(pos);
                return;
            }
            Instantiate(explosionLine, pos, Quaternion.AngleAxis(Vector2.Angle(Vector3.right, (Vector3)direction), Vector3.forward));
        }
    }

    private void SpawnUpgrade(Vector3 position)
    {
        if (Random.Range(0, 101) > droprate)
        {
            Instantiate(upgrades[Random.Range(0, upgrades.Length)], position, Quaternion.identity);
            droprate += 30;
        }
        else droprate -= 10;
    }

}
