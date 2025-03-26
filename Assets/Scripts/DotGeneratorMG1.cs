using UnityEngine;

public class RandomDotGenerator : MonoBehaviour
{
    public GameObject redDotPrefab; // Prefab van het rode puntje
    public Vector2 minPosition = new Vector2(-5, -5); // Ondergrens voor de positie
    public Vector2 maxPosition = new Vector2(5, 5);   // Bovengrens voor de positie

    [HideInInspector]
    public GameObject currentDot; // Houd bij of er al een puntje bestaat

    // Methode om een rode dot te genereren
    public void GenerateRedDot()
    {
        // Controleer of er al een puntje bestaat
        if (currentDot == null)
        {
            // Genereer een willekeurige positie
            float randomX = Random.Range(minPosition.x, maxPosition.x);
            float randomY = Random.Range(minPosition.y, maxPosition.y);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            // Instantieer het rode puntje
            currentDot = Instantiate(redDotPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Methode om het rode punt te verwijderen
    public void RemoveRedDot()
    {
        if (currentDot != null)
        {
            Destroy(currentDot); // Verwijder het rode puntje
            currentDot = null;   // Reset de verwijzing
        }
    }
}

