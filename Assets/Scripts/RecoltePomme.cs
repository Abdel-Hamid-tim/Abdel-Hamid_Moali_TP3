using UnityEngine;

public class RecoltePomme : MonoBehaviour
{
    // Tes références actuelles
    public AudioSource sonCrunch;
    public GameObject prefabEtoiles;
    
    // La nouvelle référence pour le GameManager
    public GestionnaireDeJeu gestionnaire; 

    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Touché : " + collision.name);

    if (collision.gameObject.CompareTag("Pomme"))
    {
        Debug.Log("Pomme détectée !");

        // 1. Jouer le son
        if (sonCrunch != null)
            sonCrunch.Play();

        // 2. Créer les particules à la position de la pomme
        if (prefabEtoiles != null)
            Instantiate(prefabEtoiles, collision.transform.position, Quaternion.identity);

        // 3. Informer le gestionnaire qu'on a marqué un point
        if (gestionnaire != null)
            gestionnaire.AjouterPoint();

        // 4. Détruire la pomme
        Destroy(collision.gameObject);
    }
}
}
