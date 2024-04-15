using UnityEngine;

public class camLookat : MonoBehaviour
{
    public Transform player; // Référence vers le transform du joueur
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra
    public Vector3 offset; // Décalage de la caméra par rapport au joueur

    private Vector3 desiredPosition; // Position cible de la caméra

    void LateUpdate()
    {
        // Calcul de la position cible de la caméra
        desiredPosition = player.position + offset;

        // Appliquer la rotation du joueur à la caméra (sauf sur l'axe Y)
        Quaternion playerRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);
        desiredPosition = player.position + playerRotation * offset;

        // Lissage du déplacement de la caméra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Déplacement de la caméra vers la position cible
        transform.position = smoothedPosition;

        // Orientation de la caméra pour regarder le joueur
        transform.LookAt(player);
    }
}
