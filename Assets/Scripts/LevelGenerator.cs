using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    // Reference to the Tilemap where the level will be generated
    public Tilemap levelTilemap;

    // References to the tiles corresponding to the level pieces
    public Tile outsideCornerTile;   // Tile for value 1
    public Tile outsideWallTile;     // Tile for value 2
    public Tile insideCornerTile;    // Tile for value 3
    public Tile insideWallTile;      // Tile for value 4
    public Tile standardPelletTile;  // Tile for value 5
    public Tile powerPelletTile;     // Tile for value 6
    public Tile tJunctionTile;       // Tile for value 7

    // The level layout array
    private int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    void Start()
    {
        // Clear existing tiles in the Tilemap
        levelTilemap.ClearAllTiles();

        // Generate the top-left quadrant of the level
        GenerateLevel();

        // Mirror horizontally and vertically to complete the level
        MirrorHorizontally();
        MirrorVertically();
    }

    // Generate the top-left quadrant of the level
    private void GenerateLevel()
    {
        int width = levelMap.GetLength(1);
        int height = levelMap.GetLength(0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                PlaceTile(x, y, levelMap[y, x]);
            }
        }
    }

    // Place a tile in the Tilemap based on the level map value
    private void PlaceTile(int x, int y, int tileType)
    {
        Tile tile = GetTileForType(tileType);
        if (tile == null) return;

        // Set the tile at the correct position in the Tilemap
        levelTilemap.SetTile(new Vector3Int(x, -y, 0), tile);
    }

    // Get the corresponding Tile for each level map value
    private Tile GetTileForType(int type)
    {
        switch (type)
        {
            case 1: return outsideCornerTile;
            case 2: return outsideWallTile;
            case 3: return insideCornerTile;
            case 4: return insideWallTile;
            case 5: return standardPelletTile;
            case 6: return powerPelletTile;
            case 7: return tJunctionTile;
            default: return null;
        }
    }

    // Mirror the generated tiles horizontally
    private void MirrorHorizontally()
    {
        Vector3Int size = levelTilemap.size;
        BoundsInt bounds = levelTilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (!levelTilemap.HasTile(pos)) continue;

            // Get the tile at the current position
            TileBase tile = levelTilemap.GetTile(pos);
            Vector3Int mirrorPos = new Vector3Int(-pos.x - 1, pos.y, pos.z);
            
            // Place the mirrored tile
            levelTilemap.SetTile(mirrorPos, tile);
        }
    }

    // Mirror the generated tiles vertically
    private void MirrorVertically()
    {
        Vector3Int size = levelTilemap.size;
        BoundsInt bounds = levelTilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (!levelTilemap.HasTile(pos)) continue;

            // Get the tile at the current position
            TileBase tile = levelTilemap.GetTile(pos);
            Vector3Int mirrorPos = new Vector3Int(pos.x, -pos.y - 1, pos.z);
            
            // Place the mirrored tile
            levelTilemap.SetTile(mirrorPos, tile);
        }
    }
}
