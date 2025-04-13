using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class npcInteraction : npc
{   
    public TextFader textFader;
    public DialogueManager dialogueManager;
    private bool z_Interacted = false;
    public GameObject text_box;
    private bool playerInRange = false;
    private bool textFaded = false;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (playerInRange)
        {
            if(!textFaded)
            {
                textFaded = true;
                textFader.FadeIn();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteract();
            }
        }
    }

    private void OnInteract()
    {
        if (!z_Interacted)
        {
            Debug.Log("Help");
            z_Interacted = true;
            dialogueManager.StartDialogue();
            textFader.FadeOut();
            //toggleText();
        }   
    }       

    protected virtual void toggleText() {
        bool isActive = text_box.activeSelf;
        text_box.SetActive(!isActive);
    }
}
