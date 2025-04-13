// using System.Collections;
// using UnityEngine;
// using System.Collections.Generic;
// public class npcInteraction : npc
// {    
//     private bool z_Interacted = false;
//     public GameObject text_box;
//     private bool playerInRange = false;
//     protected override void OnCollided(GameObject collidedObject)
//     {
//         if (collidedObject.CompareTag("Player"))
//         {
//             playerInRange = true;
//         }
//     }
//     protected override void Update()
//     {
//         base.Update();
//         if (playerInRange && Input.GetKeyDown(KeyCode.E))
//         {
//             OnInteract();
//         }
//     }

//     private void OnInteract()
//     {
//         if (!z_Interacted)
//         {
//             Debug.Log("Help");
//             z_Interacted = true;
//             toggleText();
//         }   
//     }       

//     protected virtual void toggleText() {
//         bool isActive = text_box.activeSelf;
//         text_box.SetActive(!isActive);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : npc
{
    private bool z_Interacted = false;
    public TextFader textFader;
    public GameObject text_box;
    public DialogueManager dialogueManager;
    private bool textFaded = false;

    protected override void OnCollided(GameObject collidedObject)
    {
        if(!textFaded)
            {
                textFaded = true;
                textFader.FadeIn();
            }
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
            
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            dialogueManager.StartDialogue();
            textFader.FadeOut();
            Debug.Log("INTERACT WITH " + name);
        }        
    }

     protected virtual void toggleText() {
        bool isActive = text_box.activeSelf;
        text_box.SetActive(!isActive);
    }

    
}