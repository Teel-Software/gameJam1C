using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap[] _blocksTilemap;
    public static BoundsInt CellBounds { get; private set; }
    public static bool[,] Blocks { get; private set; }

    private void Start()
    {
        CellBounds = _groundTilemap.cellBounds;

        InitBlocks(_blocksTilemap);
    }

    private void InitBlocks(Tilemap[] blocksTilemaps)
    {
        if (blocksTilemaps == null) return;

        Blocks = new bool[CellBounds.size.x, CellBounds.size.y];

        for (int i = 0; i < Blocks.GetLength(0); i++)
        for (int j = 0; j < Blocks.GetLength(1); j++)
        {
            foreach (var blocksTilemap in blocksTilemaps)
                if (blocksTilemap.GetTile(new Vector3Int(i + CellBounds.xMin, j + CellBounds.yMin)))
                {
                    Blocks[i, j] = true;
                }
        }
    }
}