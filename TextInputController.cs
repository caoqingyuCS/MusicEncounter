using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Supercyan.AnimalPeopleSample; //什么意思？
using UnityEngine.EventSystems;
public class TextInputController : MonoBehaviour
{
    public TMP_InputField playerinputField;
    public TextToMusicNotes textToMusicNotes;
    public SimpleSampleCharacterControl characterControl;
    public bool isTyping = false;
    private void Start()
    {
        playerinputField.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnEndEdit(string text)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(PlayNotesFromText(text));
            playerinputField.text = "";
            playerinputField.DeactivateInputField();
        }
    }

    private IEnumerator PlayNotesFromText(string text)
    {
        if (textToMusicNotes == null)
        {
            Debug.LogError("TextToMusicNotes reference not set.");
            yield break;
        }

        foreach (char character in text)
        {
            if (char.IsLetter(character))
            {
                textToMusicNotes.PlayNoteForCharacter(character);
                yield return new WaitForSeconds(0.5f); // adjust the delay between notes as needed
            }
        }
    }

    private void Update(){
        if(playerinputField.isFocused){
            isTyping = true;
        }
        else
        {
            isTyping = false;
        }
    }

}
