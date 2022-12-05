using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StoryText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index = 0;
    public float textSpeed;

    private void OnEnable()
    {
        NextText();
    }
    private void NextText()
    {
        if (index <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
    }
    IEnumerator WriteSentence()
    {

        foreach (char Character in sentences[index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(textSpeed);

        }
        index++;
        yield return new WaitForSeconds(0.8f);
        NextText();
    }
}
