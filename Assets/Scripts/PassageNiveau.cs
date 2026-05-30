using UnityEngine;
using UnityEngine.SceneManagement;

public class PassageNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Diagnostic : Cela t'aidera à voir dans la console quel objet touche le drapeau
        Debug.Log("Le drapeau a été touché par : " + collision.gameObject.name + " avec le tag : " + collision.tag);

        // 2. Vérification : On cherche soit le tag "Player", soit le nom spécifique "Papillon"
        if (collision.CompareTag("Player") || collision.gameObject.name == "Papillon")
        {
            Debug.Log("Tag ou Nom détecté ! Passage au niveau suivant.");
            
            int indexActuel = SceneManager.GetActiveScene().buildIndex;
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            // 3. Logique de transition
            if (indexActuel + 1 >= totalScenes)
            {
                Debug.Log("Fin du jeu ! Retour au menu (index 0).");
                SceneManager.LoadScene(0); 
            }
            else
            {
                Debug.Log("Chargement du niveau suivant (index : " + (indexActuel + 1) + ")");
                SceneManager.LoadScene(indexActuel + 1);
            }
        }
    }
}