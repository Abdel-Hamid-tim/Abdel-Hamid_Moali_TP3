using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireDeJeu : MonoBehaviour
{
    public int score = 0;
    public int scorePourGagner = 5;

    public void AjouterPoint()
    {
        score++;
        Debug.Log("Score actuel : " + score);

        if (score >= scorePourGagner)
        {
            TerminerNiveau();
        }
    }

    void TerminerNiveau()
    {
        int indexActuel = SceneManager.GetActiveScene().buildIndex;
        
        // Logique de transition forcée
        // Si on est au Niveau 2 (index 2), on force le chargement du Niveau 3 (index 3)
        if (indexActuel == 2) 
        {
            SceneManager.LoadScene(3);
        }
        else 
        {
            // Comportement normal pour les autres niveaux
            SceneManager.LoadScene(indexActuel + 1);
        }
    }
}