using UnityEngine;

public class GlisserDeposer : MonoBehaviour
{
    private bool estGlisse = false;
    private bool aEteBouge = false; 
    private Vector3 positionInitiale;
    
    public Transform nidCible; // La cible où l'animal doit être déposé
    public float distanceDeValidation = 1f; 

    private void Start()
    {
        positionInitiale = transform.position;
    }

    private void OnMouseDown() // Détecte le clic sur l'animal
    {
        estGlisse = true;
        aEteBouge = true; 
    }

    private void OnMouseUp() // Détecte le lâcher de l'animal
    {
        estGlisse = false;
        if (!aEteBouge) return;

        // Vérifie si l'animal est assez proche du nid
        if (Vector3.Distance(transform.position, nidCible.position) < distanceDeValidation)
        {
            transform.position = nidCible.position; // Aligne l'objet sur la cible
            GetComponent<Collider2D>().enabled = false; // Désactive le clic pour verrouiller
            
            // Notifie le gestionnaire que l'animal est bien rangé
            FindFirstObjectByType<GestionnaireCasseTete>()?.VerifierVictoire();
            this.enabled = false; // Arrête ce script
        }
        else
        {
            transform.position = positionInitiale; // Retour au point de départ
        }
    }

    private void OnMouseDrag() // Suit la souris pendant le glisser
    {
        if (estGlisse)
        {
            Vector3 posSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posSouris.z = 0f; 
            transform.position = posSouris;
        }
    }
}