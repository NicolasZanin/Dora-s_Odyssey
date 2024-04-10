using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private List<DialogString> dialogueStrings = new List<DialogString>();
    [SerializeField] private Transform npcTransform;

    private bool hasSpoken = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpoken)
        {
            other.gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings, npcTransform);
            hasSpoken = true;
        }
    }
}

[System.Serializable]
public class DialogString
{
    public string text;
    public bool isEnd;

    [Header("Branch")] 
    public bool isQuestion;
    public string answerOption1;
    public string answerOption2;
    public int option1IndexJump;
    public int option2IndexJump;

    [Header("Triggered Event's")] 
    public UnityEvent startDialogEvent;

    public UnityEvent endDialogEvent;
}
