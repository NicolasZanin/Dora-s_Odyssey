using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popScreamer : MonoBehaviour
{
    public GameObject screamerObject;
    public AudioSource audioSource;
    public AudioClip clip;
    public int x;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")){
            StartCoroutine(scream());
        }
    }

    IEnumerator scream()
    {
        print("test");
        screamerObject.transform.position = new Vector3(screamerObject.transform.position.x, x, screamerObject.transform.position.z);
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(5);
        print("test2");
        screamerObject.transform.position = new Vector3(screamerObject.transform.position.x, 100, screamerObject.transform.position.z);
    }
}
