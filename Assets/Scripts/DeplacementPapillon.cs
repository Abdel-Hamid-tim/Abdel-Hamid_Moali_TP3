using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeplacementPapillon : MonoBehaviour
{
    public float vitesse = 5f;

    void Update()
    {
        // Déplacement sur les axes X et Y
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0) * vitesse * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (autre.CompareTag("Arrivee"))
        {
            GestionnaireCouleurs gc = FindAnyObjectByType<GestionnaireCouleurs>();

            // Vérifie si le joueur a activé toutes les fleurs avant de finir
            if (gc != null && gc.peutFinirNiveau == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                // Rétroaction visuelle si le joueur essaie de finir trop tôt
                if (gc != null && gc.texteFleurs != null)
                {
                    TextMeshProUGUI compTexte = gc.texteFleurs.GetComponent<TextMeshProUGUI>();
                    if (compTexte != null) compTexte.text = "Incomplet ! Active toutes les fleurs !";
                }
            }
        }
    }
}