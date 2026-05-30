using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GestionnaireCasseTete : MonoBehaviour
{
    private int animauxRanges = 0;
    [SerializeField] private int totalAnimaux = 3;

    public GameObject texteInstruction; 
    public GameObject texteBravo;      

    private void Start()
    {
        if (texteInstruction != null) texteInstruction.SetActive(true);
        if (texteBravo != null) texteBravo.SetActive(false);
    }

    public void VerifierVictoire()
    {
        animauxRanges++;
        // Quand tous les animaux sont placés, déclenche la fin
        if (animauxRanges >= totalAnimaux)
        {
            if (texteInstruction != null) texteInstruction.SetActive(false);
            StartCoroutine(SequenceFinDeJeu());
        }
    }

    private IEnumerator SequenceFinDeJeu()
    {
        if (texteBravo != null) texteBravo.SetActive(true);
        yield return new WaitForSeconds(3f); // Pause avant de redémarrer
        SceneManager.LoadScene(0); 
    }
}