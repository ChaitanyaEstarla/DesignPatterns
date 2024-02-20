using System;
using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public class GridGenerator : MonoBehaviour 
{
    [Range(2,3)]
    [SerializeField] int gridSize = 2;
    [SerializeField] float spacing = 1.5f;
    [SerializeField] Transform puzzleParent;
    [SerializeField] Transform gridParent;
    [SerializeField] GridPiece gridPiece;
    [SerializeField] PuzzlePiece puzzlePiece;

    private void Start() 
    {
        InitGrid();
        SpawnPuzzlePieces();
    }

    private void InitGrid()
    {
        float gridScale = gridSize * spacing;
        float limit = gridSize;
        int count = 0;
        for(float i =0, j = 0; i < gridScale; i = (j >= limit ? (i+spacing) : i), j = (j >= limit ? 0 : (j+spacing)))
        {
            var newPosition = new Vector3(j, i, 0);
            var instance = Instantiate(gridPiece, newPosition, quaternion.identity, gridParent);
            instance.name = "Grid-" + count;
            instance.SetId(count++);
            PuzzleManager.Instance.AddGridPiece(instance);
        }
    }

    private void SpawnPuzzlePieces()
    {
        var startX = -gridSize;
        for(int i=0; i < gridSize*gridSize; i++)
        {
            //Instantiate and assign piece number
            var instance = Instantiate(puzzlePiece, new Vector3(startX, -2f, -1f), quaternion.identity, puzzleParent);
            instance.UpdateId(i);
            instance.name = "Puzzle-" +  i;
            PuzzleManager.Instance.AddGridPieceToDictionary(instance, null);
            startX++;
        }
    }
}
