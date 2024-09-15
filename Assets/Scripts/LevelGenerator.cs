using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Reference to your sprites as GameObjects (assign these in the Unity Inspector)
    public GameObject[] levelPieces; // 0 - Empty, 1 - Outside Corner, 2 - Outside Wall, etc.
    public Camera mainCamera;

    int[,] levelMap = {
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

    // Start is called before the first frame update
    void Start()
    {
        // Delete existing level (if needed)
        ClearExistingLevel();

        // Generate the level based on levelMap
        GenerateLevel();

        // Mirror level (horizontally, vertically, and both)
        MirrorLevel();

        // Adjust camera to fit the level
        AdjustCamera();
    }

    void ClearExistingLevel()
    {
        // Delete any existing game objects in the scene (for example, Level 01)
        GameObject[] existingLevelPieces = GameObject.FindGameObjectsWithTag("LevelPiece");
        foreach (GameObject piece in existingLevelPieces)
        {
            Destroy(piece);
        }
    }

    void GenerateLevel()
    {
        for (int y = 0; y < levelMap.GetLength(0); y++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                int pieceType = levelMap[y, x];
                if (pieceType != 0) // 0 is empty, so we skip it
                {
                    Vector3 position = new Vector3(x, -y, 0); // Negative y because Unity's y-axis increases upwards
                    GameObject piece = Instantiate(levelPieces[pieceType], position, Quaternion.identity);
                    piece.tag = "LevelPiece"; // Set tag to help with cleanup later

                    // Rotate the piece if necessary (you'll need to implement rotation logic based on surroundings)
                    RotatePiece(x, y, piece);
                }
            }
        }
    }

    void RotatePiece(int x, int y, GameObject piece)
    {
        // Rotation logic: Check the neighbors and decide how the piece should be rotated.
        // Example: You can analyze the surrounding levelMap values (up, down, left, right) to determine the angle.
        
        // Placeholder for rotation logic:
        // - If piece is a wall, rotate to align with neighbors
        // - If piece is a corner, rotate to match the direction

        // Example:
        if (levelMap[y, x] == 1) // Outside corner
        {
            // Rotate based on surrounding pieces (this is just an example)
            if (x > 0 && y > 0 && levelMap[y - 1, x] != 0 && levelMap[y, x - 1] != 0)
            {
                piece.transform.Rotate(0, 0, 90); // Rotate to align with walls
            }
        }
    }

    void MirrorLevel()
    {
        // Horizontal mirror (flip along y-axis)
        MirrorHorizontally();

        // Vertical mirror (flip along x-axis)
        MirrorVertically();

        // Horizontal and vertical mirror
        MirrorHorizontallyAndVertically();
    }

    void MirrorHorizontally()
    {
        // Loop through the 2D array and mirror the pieces horizontally
        for (int y = 0; y < levelMap.GetLength(0); y++)
        {
            for (int x = 0; x < levelMap.GetLength(1); x++)
            {
                // Skip the bottom row for vertical symmetry
                if (y < levelMap.GetLength(0) - 1)
                {
                    Vector3 position = new Vector3(x, -y, 0); 
                    Vector3 mirrorPos = new Vector3(x, -levelMap.GetLength(0) + y, 0);
                    Instantiate(levelPieces[levelMap[y, x]], mirrorPos, Quaternion.identity);
                }
            }
        }
    }

    void MirrorVertically()
    {
        // Loop through the 2D array and mirror the pieces vertically
        // Implement similar to horizontal mirroring
        
    }

    void MirrorHorizontallyAndVertically()
    {
        // Loop through the 2D array and mirror both horizontally and vertically
        // Implement combining the two mirror methods
    }

    void AdjustCamera()
    {
        // Adjust the camera size and position based on the level size
        float mapWidth = levelMap.GetLength(1);
        float mapHeight = levelMap.GetLength(0);

        // Set camera size to fit the entire level
        mainCamera.orthographicSize = Mathf.Max(mapWidth, mapHeight) / 2f;

        // Center the camera on the level
        mainCamera.transform.position = new Vector3(mapWidth / 2f, -mapHeight / 2f, -10f);
    }
}
