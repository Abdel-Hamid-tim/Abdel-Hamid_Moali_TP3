using UnityEngine;
using UnityEngine.SceneManagement;

public class DrapeauFin : MonoBehaviour
{
    public GestionnaireCouleurs gestionnaire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur atteint le drapeau et que la condition de victoire est remplie
        if (collision.CompareTag("Fini") || collision.gameObject.name == "Papillon")
        {
            if (gestionnaire != null && gestionnaire.peutFinirNiveau)
            {
                // Charge la scène suivante dans l'ordre des Build Settings
                int indexSceneActuelle = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(indexSceneActuelle + 1);
            }
            else
            {
                Debug.Log("Fleurs incomplètes.");
            }
        }
    }
}
