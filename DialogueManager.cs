using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI textDisplay;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        textBox.SetActive(false);
    }

    public void StartDialogue()
    {
        index = 0;
        textBox.SetActive(true);
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (textBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                // Skip to full line if typing
                StopAllCoroutines();
                textDisplay.text = dialogueLines[index];
                isTyping = false;
            }
            else
            {
                // Move to next line
                NextLine();
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textDisplay.text = "";
        foreach (char letter in dialogueLines[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        index++;
        if (index < dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            textBox.SetActive(false);
        }
    }
}
