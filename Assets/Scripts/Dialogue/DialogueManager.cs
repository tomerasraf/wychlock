using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogueSequence = new List<GameObject>();
    private int currentDialogueIndex = 1;

    public void PlayNextDialogue()
    {
        if (currentDialogueIndex < dialogueSequence.Count)
        {
            dialogueSequence[currentDialogueIndex].SetActive(true);
            currentDialogueIndex++;
        }
        else
        {
            Debug.Log("End of dialogue sequence.");
        }
    }

    public void SetDialogueIndex(int index)
    {
        if (index >= 1 && index < dialogueSequence.Count)
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
