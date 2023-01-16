using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	private DialogueManager dialogueManager;
	
	public void TriggerDialogue()
	{
		if (!dialogueManager.InDialogue)
		{
			dialogueManager.StartDialogue(dialogue);
		}
	}

    private void Start()
    {
		dialogueManager = FindObjectOfType<DialogueManager>();
    }
}