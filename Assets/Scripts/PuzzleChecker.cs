using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public static PuzzleChecker Instance;

    public Transform piece1;
    public Transform piece2;
    public Transform piece3;

    // Correcte posities van de puzzelstukken
    private Vector2 correctPos1 = new Vector2(0, 0);
    private Vector2 correctPos2 = new Vector2(2, 0.6f);
    private Vector2 correctPos3 = new Vector2(4, 1.15f);

    public float threshold = 0.5f; // Hoeveel speling er is toegestaan

    public GameObject winMessage; // UI-tekst die wordt getoond bij succes
    public GameObject puzzle; // UI-tekst die wordt getoond bij succes

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckPuzzle()
    {
        Debug.Log("CheckPuzzle");
        if (IsCorrectlyPlaced(piece1, piece2, piece3) ||
            IsCorrectlyPlaced(piece2, piece1, piece3) ||
            IsCorrectlyPlaced(piece3, piece1, piece2))
        {
            ShowWinMessage();
        }
    }

    private bool IsCorrectlyPlaced(Transform refPiece, Transform other1, Transform other2)
    {
        Debug.Log("IsCorrectlyPlaced");
        // Bereken de offsets vanaf het referentiestuk
        Vector2 refPos;
        Vector2 targetPos1, targetPos2;

        if (refPiece == piece1)
        {
            refPos = refPiece.position;
            targetPos1 = refPos + (correctPos2 - correctPos1);
            targetPos2 = refPos + (correctPos3 - correctPos1);
        }
        else if (refPiece == piece2)
        {
            refPos = refPiece.position;
            targetPos1 = refPos + (correctPos1 - correctPos2);
            targetPos2 = refPos + (correctPos3 - correctPos2);
        }
        else
        {
            refPos = refPiece.position;
            targetPos1 = refPos + (correctPos1 - correctPos3);
            targetPos2 = refPos + (correctPos2 - correctPos3);
        }

        // Controle met een speling/marge (threshold)
        return IsWithinThreshold(other1.position, targetPos1) &&
               IsWithinThreshold(other2.position, targetPos2);
    }

    private bool IsWithinThreshold(Vector2 piecePos, Vector2 targetPos)
    {
        Debug.Log("IsWithinThreshold");
        return Vector2.Distance(piecePos, targetPos) < threshold;
    }

    private void ShowWinMessage()
    {
        winMessage.SetActive(true);
        puzzle.SetActive(false);
        Debug.Log("Puzzel voltooid!");
    }
}
