using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionnaireMenu : MonoBehaviour
{
    public void DemarrerJeu() 
    {
        // Réactive le temps au cas où le jeu serait en pause
        Time.timeScale = 1f; 
        
        // Charge la scène à l'index 1 (souvent le Niveau 1)
        SceneManager.LoadScene(1);
    }
}
