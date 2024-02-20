using UnityEngine;

public class GridPiece : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private Collider2D selfCollider;

    public PuzzlePiece connectedPiece;
    public bool IsOccupied => isOccupied;
    public int GetId() => id;

    public void SetId(int nunmber)
    {
        id = nunmber;
    }

    public void SendCurrentPieceBack()
    {
        connectedPiece.transform.position = connectedPiece.OriginalPosition;
    }


    public void UpdateOccupancy(bool occupancy, PuzzlePiece puzzlePiece)
    {
        isOccupied = occupancy;
        if(isOccupied)
        {
            if(connectedPiece != null)
            { 
                PuzzleManager.Instance.ClearGridBeforeNewLink(connectedPiece);
            }
            connectedPiece = puzzlePiece;
            PuzzleManager.Instance.AddGridPieceToDictionary(puzzlePiece, this);
            if(id == connectedPiece.GetId())
            {
                selfCollider.enabled = false;
                puzzlePiece.puzzleCollider.enabled = false;
                var currentPieceColor = puzzlePiece.pieceImage.color;
                puzzlePiece.pieceImage.color = new Color(currentPieceColor.r, currentPieceColor.g, currentPieceColor.b, 0.5f);
            }
        }
        else
        {
            PuzzleManager.Instance.AddGridPieceToDictionary(puzzlePiece, null);
            Debug.Log(puzzlePiece.name);
            connectedPiece = null;
        }
    }
}
 