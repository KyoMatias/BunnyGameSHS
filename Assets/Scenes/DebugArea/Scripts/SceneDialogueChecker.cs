using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneDialogueChecker : MonoBehaviour
{
    public SceneDialoguesSO sceneDialogues;
    private int currentDialogueIndex = -1;
    
    [Header("Dialogue UI")]
    public TextMeshProUGUI Character;
    public TextMeshProUGUI DialogueText;


    [Header("Current Dialogue")] 
    public string CurrentSpeaker;
    public string CurrentDialogue;
    private float _currentDialogueDuration;
    private bool _isPlayingDialogue = false;

    void Start()
    {
        FindAvailableDialogue();
    }

    void FindAvailableDialogue()
    {
        for (int i = 0; i < sceneDialogues.dialogueContents.Count; i++)
        {
            if (!sceneDialogues.dialogueContents[i].Done)
            {
                currentDialogueIndex = i;
                Debug.Log($"Next dialogue to play is at index: {currentDialogueIndex}");
                PlayDialogue();
                return;     
            }
        }
        Debug.Log("All dialogues are done!");
    }

    void PlayDialogue()
    {
        if (currentDialogueIndex >= 0 && currentDialogueIndex < sceneDialogues.dialogueContents.Count)
        {
            SceneDialoguesSO.DialogueContents currentDialogue = sceneDialogues.dialogueContents[currentDialogueIndex];

            CurrentSpeaker = currentDialogue.SpeakerName;
            CurrentDialogue = currentDialogue.Dialogue;
            _currentDialogueDuration = currentDialogue.LineDuration;

            Character.text = currentDialogue.SpeakerName;
            DialogueText.text = currentDialogue.Dialogue;
            Debug.Log($"Playing Dialogue: {CurrentDialogue} (Speaker: {CurrentSpeaker}) Duration: {_currentDialogueDuration}");

            if (!_isPlayingDialogue) 
            {
                StartCoroutine(DialogueCountdown());
            }
        }
        else
        {
            Debug.Log("No valid dialogue set.");
        }
    }

    IEnumerator DialogueCountdown()
    {
        _isPlayingDialogue = true;

        while (_currentDialogueDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentDialogueDuration -= 1f;
        }

        // ✅ Mark dialogue as completed
        sceneDialogues.dialogueContents[currentDialogueIndex].Done = true;
        Debug.Log($"Dialogue {currentDialogueIndex} marked as done.");

        _isPlayingDialogue = false;

        // Move to next available dialogue
        FindAvailableDialogue();
    }
}
