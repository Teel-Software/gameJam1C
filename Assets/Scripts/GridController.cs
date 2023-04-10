using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private Tilemap[] _blocksTilemap;
    [SerializeField] private Grid _grid;

    private Camera _camera;

    public static BoundsInt CellBounds { get; private set; }
    public static bool[,] Blocks { get; private set; }
    public static GridController Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        CellBounds = _groundTilemap.cellBounds;
        InitBlocks(_blocksTilemap);
    }

    private void Start()
    {
        _camera = Camera.main;
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

    public Vector3 GetRandomGridPositionToWorldPosition()
    {
        for (int i = 0; i < Blocks.GetLength(0); i++)
        for (int j = 0; j < Blocks.GetLength(1); j++)
        {
            if (!Blocks[i, j])
                return _grid.CellToWorld(new Vector3Int(i, j));
        }

        Debug.Log("Foo, kakashka");
        return Vector2.zero;
    }

    public bool CheckEmptyBlock(Vector3 nextPosition)
    {
        if ((int)nextPosition.x > Blocks.GetLength(0) - 1 ||
            (int)nextPosition.y > Blocks.GetLength(1) - 1 ||
            (int)nextPosition.x < 0 ||
            (int)nextPosition.y < 0)
            return false;

        return Blocks[(int)nextPosition.x, (int)nextPosition.y];
    }
}