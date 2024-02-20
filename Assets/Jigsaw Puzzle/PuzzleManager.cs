using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PuzzleManager : SerializedMonoBehaviour
{
    [ShowInInspector]
    private bool anotherPieceIsMoving = false;

    [SerializeField] private Dictionary<PuzzlePiece, GridPiece> puzzlePieces = new();
    [SerializeField] private List<GridPiece> gridPieces = new();

    public void AddGridPiece(GridPiece gridPiece)
    {
        gridPieces.Add(gridPiece);
    }

    public void AddGridPieceToDictionary(PuzzlePiece puzzlePiece, GridPiece gridPiece)
    {
        if (puzzlePieces.ContainsKey(puzzlePiece))
            puzzlePieces[puzzlePiece] = gridPiece;
        else
            puzzlePieces.Add(puzzlePiece, gridPiece);
    }

    public GridPiece GetConnectedGridPiece(PuzzlePiece puzzlePiece)
    {
        if(!puzzlePieces.ContainsKey(puzzlePiece)) return null;

        return puzzlePieces[puzzlePiece];

    }

    public void ClearGridBeforeNewLink(PuzzlePiece puzzlePiece)
    {
        if (puzzlePieces.ContainsKey(puzzlePiece))
        {
            puzzlePieces[puzzlePiece] = null;
        }
    }

    public bool CheckGridForCompletion()
    {
        foreach(var piece in puzzlePieces)
        {
            var puzzle = piece.Key;
            var grid = piece.Value;

            if(grid == null || !grid.IsOccupied)
            {
                return false;
            }
            if(grid.GetId() != puzzle.GetId())
            {
                return false;
            }
        }
        Debug.Log("Puzzle Done");
#if !UNITY_EDITOR
        Application.OpenURL("https://www.youtube.com/watch?v=o-YBDTqX_ZU");
#endif
        return true;
    }

    public static PuzzleManager Instance { get; private set; }

    public bool AnotherPieceIsMoving { get { return anotherPieceIsMoving; } set { anotherPieceIsMoving = value; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        puzzlePieces = new Dictionary<PuzzlePiece, GridPiece>();
    }
}