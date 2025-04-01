using UnityEngine;

public class PuzzleChecker2 : MonoBehaviour
{
    public static PuzzleChecker2 Instance;

    public Transform piece1, piece2, piece3, piece4, piece5;

    private Vector2 correctPos1 = new Vector2(0.65f, 3.47f);
    private Vector2 correctPos2 = new Vector2(-0.04f, 2.1f);
    private Vector2 correctPos3 = new Vector2(-1.2f, 0.22f);
    private Vector2 correctPos4 = new Vector2(-2.85f, -1.6f);
    private Vector2 correctPos5 = new Vector2(-4f, -3.5f);

    public float threshold = 0.5f; // Toegestane speling

    public GameObject winMessage; // UI bericht bij voltooien
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
        if (IsValidConfiguration(piece1, piece2, piece3, piece4, piece5) ||
            IsValidConfiguration(piece2, piece1, piece3, piece4, piece5) ||
            IsValidConfiguration(piece3, piece1, piece2, piece4, piece5) ||
            IsValidConfiguration(piece4, piece1, piece2, piece3, piece5) ||
            IsValidConfiguration(piece5, piece1, piece2, piece3, piece4))
        {
            ShowWinMessage();
        }
    }

    private bool IsValidConfiguration(Transform refPiece, Transform p2, Transform p3, Transform p4, Transform p5)
    {
        Vector2 refPos = refPiece.position;

        Vector2 targetPos2, targetPos3, targetPos4, targetPos5;

        if (refPiece == piece1)
        {
            targetPos2 = refPos + (correctPos2 - correctPos1);
            targetPos3 = refPos + (correctPos3 - correctPos1);
            targetPos4 = refPos + (correctPos4 - correctPos1);
            targetPos5 = refPos + (correctPos5 - correctPos1);
        }
        else if (refPiece == piece2)
        {
            targetPos2 = refPos + (correctPos1 - correctPos2);
            targetPos3 = refPos + (correctPos3 - correctPos2);
            targetPos4 = refPos + (correctPos4 - correctPos2);
            targetPos5 = refPos + (correctPos5 - correctPos2);
        }
        else if (refPiece == piece3)
        {
            targetPos2 = refPos + (correctPos1 - correctPos3);
            targetPos3 = refPos + (correctPos2 - correctPos3);
            targetPos4 = refPos + (correctPos4 - correctPos3);
            targetPos5 = refPos + (correctPos5 - correctPos3);
        }
        else if (refPiece == piece4)
        {
            targetPos2 = refPos + (correctPos1 - correctPos4);
            targetPos3 = refPos + (correctPos2 - correctPos4);
            targetPos4 = refPos + (correctPos3 - correctPos4);
            targetPos5 = refPos + (correctPos5 - correctPos4);
        }
        else
        {
            targetPos2 = refPos + (correctPos1 - correctPos5);
            targetPos3 = refPos + (correctPos2 - correctPos5);
            targetPos4 = refPos + (correctPos3 - correctPos5);
            targetPos5 = refPos + (correctPos4 - correctPos5);
        }

        return IsWithinThreshold(p2.position, targetPos2) &&
               IsWithinThreshold(p3.position, targetPos3) &&
               IsWithinThreshold(p4.position, targetPos4) &&
               IsWithinThreshold(p5.position, targetPos5);
    }

    private bool IsWithinThreshold(Vector2 piecePos, Vector2 targetPos)
    {
        return Vector2.Distance(piecePos, targetPos) < threshold;
    }

    private void ShowWinMessage()
    {
        winMessage.SetActive(true);
        puzzle.SetActive(false);
        Debug.Log("Puzzel voltooid!");
    }
}
