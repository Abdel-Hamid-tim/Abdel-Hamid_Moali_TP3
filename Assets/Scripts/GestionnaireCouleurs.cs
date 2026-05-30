using UnityEngine;
using TMPro; // Ajouté pour gérer le texte

public class GestionnaireCouleurs : MonoBehaviour
{
    public GameObject papillon;
    public GameObject texteFleurs; 
    public GameObject texteDrapeau; // Ton nouveau texte "Rejoindre le drapeau..."
    
    private string[] ordreCouleurs = { "Rouge", "Bleu", "Jaune", "Vert", "Violet" };
    private int indexActuel = 0;
    
    [HideInInspector] public bool peutFinirNiveau = false;

    void Start()
    {
        if (papillon != null) papillon.tag = ordreCouleurs[0]; 

        // S'assurer que le message du drapeau est caché au début
        if (texteDrapeau != null) texteDrapeau.SetActive(false);
    }

    public void TentativeAvancement(string couleurFleurCliquee, GameObject objetFleur)
    {
        if (couleurFleurCliquee == papillon.tag)
        {
            // Déplace le papillon vers la fleur et change sa couleur
            Vector3 positionFleur = objetFleur.transform.position;
            papillon.transform.position = new Vector3(positionFleur.x, positionFleur.y + 1.2f, positionFleur.z);

            AppliquerCouleur(objetFleur.GetComponent<SpriteRenderer>(), couleurFleurCliquee);
            AppliquerCouleur(papillon.GetComponent<SpriteRenderer>(), couleurFleurCliquee);

            indexActuel++;
            
            if (indexActuel < ordreCouleurs.Length)
            {
                papillon.tag = ordreCouleurs[indexActuel];
            }
            else
            {
                // TOUTES LES FLEURS SONT FAITES
                peutFinirNiveau = true;
                papillon.tag = "Fini";

                // On cache les consignes des fleurs et on AFFICHE le message du drapeau
                if (texteFleurs != null) texteFleurs.SetActive(false);
                if (texteDrapeau != null) texteDrapeau.SetActive(true);
            }
        }
    }

    void AppliquerCouleur(SpriteRenderer sr, string nomCouleur)
    {
        if (sr == null) return;
        if (nomCouleur == "Rouge") sr.color = Color.red;
        else if (nomCouleur == "Bleu") sr.color = Color.blue;
        else if (nomCouleur == "Jaune") sr.color = Color.yellow;
        else if (nomCouleur == "Vert") sr.color = Color.green;
        else if (nomCouleur == "Violet") sr.color = new Color(0.5f, 0f, 0.5f);
    }
}