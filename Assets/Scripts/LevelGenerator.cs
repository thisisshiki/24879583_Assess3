using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Failed to generate tile map from array :(
public class LevelGenerator : MonoBehaviour
{
    public Camera gameCamera;

    int[,] levelMap =
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

    // void Start()
    // {
    //     GenerateLevel();
    //     AdjustCamera();
    // }

    // void GenerateLevel()
    // {
    //     for (int y = 0; y < levelMap.GetLength(0); y++)
    //     {
    //         for (int x = 0; x < levelMap.GetLength(1); x++)
    //         {
    //             int tileIndex = levelMap[y, x];
    //             if (tileIndex != 0)
    //             {
    //                 GameObject tile = TilePooler.Instance.GetTile(tileIndex);
    //                 tile.transform.position = new Vector3(x, -y, 0);
    //                 tile.SetActive(true);
    //             }
    //         }
    //     }
    // }

    // void AdjustCamera()
    // {
    //     float aspectRatio = (float)Screen.width / (float)Screen.height;
    //     float verticalSize = levelMap.GetLength(0) / 2f;
    //     float horizontalSize = levelMap.GetLength(1) / 2f;

    //     if (horizontalSize < verticalSize * aspectRatio)
    //     {
    //         horizontalSize = verticalSize * aspectRatio;
    //     }

    //     gameCamera.orthographicSize = horizontalSize;
    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         GenerateLevel();
    //     }
    // }

}