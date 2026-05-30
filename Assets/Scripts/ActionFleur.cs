using UnityEngine;

public class ActionFleur : MonoBehaviour
{
    void OnMouseDown()
    {
        // Cherche le composant de gestion des couleurs dans toute la scène
        GestionnaireCouleurs gestionnaire = FindAnyObjectByType<GestionnaireCouleurs>();
        
        if (gestionnaire != null)
        {
            // Envoie le Tag de la fleur cliquée et l'objet lui-même au gestionnaire
            gestionnaire.TentativeAvancement(gameObject.tag, gameObject);
        }
        else
        {
            Debug.LogError("GestionnaireCouleurs introuvable !");
        }
    }
}