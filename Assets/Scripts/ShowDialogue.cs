using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShowDialogue : MonoBehaviour
{
    public Dialogue dialogueClass;

    private bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isFirst)
        {
            dialogueClass.GameObject().SetActive(true);
            isFirst = false;
        }
        else
        {
            dialogueClass.GameObject().SetActive(true);
            dialogueClass.Start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueClass.GameObject().SetActive(false);
        }
    }
}
