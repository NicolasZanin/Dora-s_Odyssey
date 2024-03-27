using UnityEngine;

public class camLookat : MonoBehaviour
{
    public Transform player; // R�f�rence vers le transform du joueur
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la cam�ra
    public Vector3 offset; // D�calage de la cam�ra par rapport au joueur

    private Vector3 desiredPosition; // Position cible de la cam�ra

    void LateUpdate()
    {
        // Calcul de la position cible de la cam�ra
        desiredPosition = player.position + offset;

        // Appliquer la rotation du joueur � la cam�ra (sauf sur l'axe Y)
        Quaternion playerRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);
        desiredPosition = player.position + playerRotation * offset;

        // Lissage du d�placement de la cam�ra
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // D�placement de la cam�ra vers la position cible
        transform.position = smoothedPosition;

        // Orientation de la cam�ra pour regarder le joueur
        transform.LookAt(player);
    }
}
