// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class DialogueManager : MonoBehaviour
// {
//     public GameObject textBox;
//     public TextMeshProUGUI textDisplay;
//     public string[] dialogueLines;
//     public float typingSpeed = 0.05f;

//     private int index = 0;
//     private bool isTyping = false;

//     void Start()
//     {
//         textBox.SetActive(false);
//     }

//     public void StartDialogue()
//     {
//         index = 0;
//         textBox.SetActive(true);
//         StartCoroutine(TypeLine());
//     }

//     void Update()
//     {
//         if (textBox.activeSelf && Input.GetKeyDown(KeyCode.E))
//         {
//             if (isTyping)
//             {
//                 // Skip to full line if typing
//                 StopAllCoroutines();
//                 textDisplay.text = dialogueLines[index];
//                 isTyping = false;
//             }
//             else
//             {
//                 // Move to next line
//                 NextLine();
//             }
//         }
//     }

//     IEnumerator TypeLine()
//     {
//         isTyping = true;
//         textDisplay.text = "";
//         foreach (char letter in dialogueLines[index].ToCharArray())
//         {
//             textDisplay.text += letter;
//             yield return new WaitForSeconds(typingSpeed);
//         }
//         isTyping = false;
//     }

//     void NextLine()
//     {
//         index++;
//         if (index < dialogueLines.Length)
//         {
//             StartCoroutine(TypeLine());
//         }
//         else
//         {
//             textBox.SetActive(false);
//         }
//     }
// }
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI textDisplay;
    public string[] dialogueLines;
    public float typingSpeed = 0.05f;

    public TMP_InputField answerInputField;
    public GameObject inputPanel;
    public Button submitButton;
    public TextMeshProUGUI feedbackText;
    public string correctAnswer = "mov rsp bit-cat"; // Set your correct answer here

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        textBox.SetActive(false);
        inputPanel.SetActive(false);
        feedbackText.text = "";

        submitButton.onClick.AddListener(CheckAnswer);
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
                StopAllCoroutines();
                textDisplay.text = dialogueLines[index];
                isTyping = false;
            }
            else
            {
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

    IEnumerator HideInputAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    inputPanel.SetActive(false);

    // Optional: Clear feedback afterward
    feedbackText.text = "";
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
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        textBox.SetActive(false);
        inputPanel.SetActive(true);
        answerInputField.text = "";
        feedbackText.text = "Enter instruction:";
    }

    void CheckAnswer()
    {
        string playerAnswer = answerInputField.text.Trim().ToLower();
        string expected = correctAnswer.Trim().ToLower();

        if (playerAnswer == expected)
{
    feedbackText.text = "Correct!";
    StartCoroutine(HideInputAfterDelay(1.5f)); // wait 1.5 seconds before hiding
}
        else
        {
            feedbackText.text = "Looks like you're going nowhere.";
        }
    }
}
