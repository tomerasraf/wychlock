using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogueSequence = new List<GameObject>();
    public int currentDialogueIndex = 0;
    public static Action finishedDialogue;

    public bool TryPlayNextDialogue()
    {
        if (currentDialogueIndex < dialogueSequence.Count)
        {
            dialogueSequence[currentDialogueIndex].SetActive(true);
            currentDialogueIndex++;
            return true;
        }
        else
        {
            Debug.Log("End of dialogue sequence.");
            finishedDialogue?.Invoke();
            return false;
        }
    }

    public void SetDialogueIndex(int index)
    {
        if (index >= 0 && index < dialogueSequence.Count)
        {
            dialogueSequence[index].SetActive(true);
            currentDialogueIndex = index + 1;
        }
        else
        {
            Debug.LogWarning("Dialogue index out of range.");
        }
    }
}
