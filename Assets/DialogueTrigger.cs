using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<DialogueString> dialogueStrings = new List<DialogueString>();
    [SerializeField] private Transform NPCTransform;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<DialogueManager>().DialogueStart(dialogueStrings, NPCTransform);
    }
}

[System.Serializable]
public class DialogueString
{
    public string text;
    public bool beginCourse;
    public bool isEnd;

    [Header("Branch")] 
    public bool isQuestion;

    public string answerOption1;
    public string answerOption2;
    public int option1IndexJump;
    public int option2IndexJump;

    [Header("Triggered Events")] 
    public UnityEvent startDialogueEvent;

    public UnityEvent endDialogueEvent;
    

}
