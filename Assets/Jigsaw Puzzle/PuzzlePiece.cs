using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 10;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private TMP_Text text;
    [SerializeField] private int id;
    public Collider2D puzzleCollider;
    public SpriteRenderer pieceImage;

    private bool    isDragged = false;
    private float   zAxis = 0;
    private float   objectWidth;
    private float   objectHeight;
    private Camera  MainCamera;
    private Vector2 screenBounds;
    private Vector3 currentVelocity;
    private Vector3 originalPosition;
    private GameObject collideObject;

    public Vector3 OriginalPosition => originalPosition;
    public TMP_Text Text { get { return text; } set { text = value; } }

    public void UpdateId(int id)
    {
        this.id = id;
        text.text = id.ToString();
    }

    public int GetId() => id;

    private void ChangeOccuppancy(GridPiece gridPiece)
    {
        if(gridPiece.IsOccupied)
        {
            gridPiece.SendCurrentPieceBack();
            if (gridPiece.connectedPiece != this)
            {
                gridPiece.UpdateOccupancy(true, this);
            }
        }
        
        UpdatePosition(gridPiece);
        gridPiece.UpdateOccupancy(true, this);
        PuzzleManager.Instance.CheckGridForCompletion();
    }

    private void UpdatePosition(GridPiece gridPiece)
    {
        transform.position = new Vector3(gridPiece.transform.position.x, gridPiece.transform.position.y, -1);
    }
     
    private bool ReplaceCurrentGridPlace()
    {
        var puzzlePiece = collideObject.GetComponent<PuzzlePiece>();
        if(puzzlePiece != null)
        {
            puzzlePiece.transform.position = puzzlePiece.originalPosition;
            var connectedGridPiece = PuzzleManager.Instance.GetConnectedGridPiece(puzzlePiece);
            if(connectedGridPiece != null)
            {
                transform.position = connectedGridPiece.transform.position;
                ChangeOccuppancy(connectedGridPiece);
            }
            PuzzleManager.Instance.ClearGridBeforeNewLink(puzzlePiece);
            return true;
        }
        return false;
    }

    #region Unity Event Functions

    private void OnMouseDown()
    {
        PuzzleManager.Instance.AnotherPieceIsMoving = true;
        isDragged = true;

        StartCoroutine(CheckCollider());
    }

    private IEnumerator CheckCollider()
    {
        yield return StartCoroutine(WaitFor.Frames(10));
        if (collideObject != null)
        {
            var gridPiece = collideObject.GetComponent<GridPiece>();

            if (gridPiece != null)
            {
                gridPiece.UpdateOccupancy(false, this);
                Debug.Log(gridPiece.connectedPiece);
                yield return null;
            }
        }
    }

    private void OnMouseUp()
    {
        PuzzleManager.Instance.AnotherPieceIsMoving = false;
        isDragged = false;

        if (collideObject == null) { return; }

        var gridPiece = collideObject.GetComponent<GridPiece>();

        if (gridPiece == null)
        {
            ReplaceCurrentGridPlace();
            return;
        }

        ChangeOccuppancy(gridPiece);
    }

    private void Start()
    {
        originalPosition = transform.position;
        MainCamera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        zAxis = Mathf.Abs(MainCamera.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collideObject = collision.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collideObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collideObject = null;
    }

    private void Update()
    {
        if (!isDragged) { return; }

        Vector3 mousePosition = MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxis));
        transform.position = Vector3.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }

    private void LateUpdate()
    {
        if (!isDragged) { return; }

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

    #endregion
}