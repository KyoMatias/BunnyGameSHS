using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneDialoguesSO", menuName = "Debug/SceneDialoguesSO")]
public class SceneDialoguesSO : ScriptableObject
{
    // These will now be visible in the Inspector
    [Header("Character Names")]
    public string Character1;
    public string Character2;
    public string Character3;
    public string Character4;
    public string Character5;

    public List<DialogueContents> dialogueContents = new List<DialogueContents>();

    [System.Serializable]
    public class DialogueContents
    {
        public Speaker CurrentSpeaker;
        public string SpeakerName;
        [TextArea]
        public string Dialogue;
        public float LineDuration;
        public bool Done;

        public DialogueContents(string name, string dialogue, float lineDuration, bool done)
        {
            this.SpeakerName = name;
            this.Dialogue = dialogue;
            this.LineDuration = lineDuration;
            this.Done = done;
        }

        public enum Speaker
        {
            DefaultString,
            Character1,
            Character2,
            Character3,
            Character4,
            Character5,
        }

        // ** Reference to parent ScriptableObject to get character names **
        public void ChangeSpeaker(SceneDialoguesSO sceneDialogues)
        {
            switch (CurrentSpeaker)
            {
                case Speaker.DefaultString:
                    SpeakerName = "DefaultCharacterString";
                    break;
                case Speaker.Character1:
                    SpeakerName = sceneDialogues.Character1;
                    break;
                case Speaker.Character2:
                    SpeakerName = sceneDialogues.Character2;
                    break;
                case Speaker.Character3:
                    SpeakerName = sceneDialogues.Character3;
                    break;
                case Speaker.Character4:
                    SpeakerName = sceneDialogues.Character4;
                    break;
                case Speaker.Character5:
                    SpeakerName = sceneDialogues.Character5;
                    break;
                default:
                    SpeakerName = "DefaultCharacterString";
                    break;
            }
        }
    }

    [Button]
    public void ResetTick()
    {
        foreach (DialogueContents dialogueContent in dialogueContents)
        {
            dialogueContent.Done = false;
        }
    }
    
}
