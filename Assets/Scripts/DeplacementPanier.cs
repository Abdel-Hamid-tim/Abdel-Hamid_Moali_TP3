using UnityEngine;

public class DeplacementPanier : MonoBehaviour
{
    public float vitesse = 5f;
    public float limiteX = 8f; 

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 position = transform.position + new Vector3(inputX * vitesse * Time.deltaTime, 0, 0);
        position.x = Mathf.Clamp(position.x, -limiteX, limiteX);
        transform.position = position;
    }
}