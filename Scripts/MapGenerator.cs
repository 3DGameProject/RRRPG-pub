using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float tileScale = 20f;
    public TilePool tilePool;
    public Transform player;
    public int renderDistance = 100;
    public float fixedYPosition = 0f; // ������ y ��ǥ ��
    public float fixedYScale = 1f; // ������ y ������ ��
    public int tileSpacing = 2; // Ÿ�� ������ �߰��� ����

    private HashSet<Vector3> activeTiles = new HashSet<Vector3>();

    private void Start()
    {
        GenerateInitialTiles();
    }

    private void Update()
    {
        GenerateTilesAhead();
    }

    private void GenerateInitialTiles()
    {
        for (int x = -renderDistance; x < renderDistance; x += tileSpacing) // ������ �߰��Ͽ� Ÿ�� ����
        {
            GenerateTileAt(new Vector3(x * tileScale, 0, 0));
        }
    }

    private void GenerateTilesAhead()
    {
        int playerX = Mathf.FloorToInt(player.position.x / tileScale);
        for (int x = playerX; x > playerX - renderDistance; x -= tileSpacing) // ������ �߰��Ͽ� Ÿ�� ����
        {
            GenerateTileAt(new Vector3(x * tileScale, 0, 0));
        }
    }

    private void GenerateTileAt(Vector3 position)
    {
        if (!activeTiles.Contains(position))
        {
            Vector3 tilePosition = new Vector3(position.x, fixedYPosition, position.z); // y ��ǥ�� ������ ������ ����
            GameObject tile = tilePool.GetTile(tilePosition);
            tile.transform.localScale = new Vector3(tileScale, fixedYScale, tileScale); // y �������� ������ ������ ����
            activeTiles.Add(position);
        }
    }
}
