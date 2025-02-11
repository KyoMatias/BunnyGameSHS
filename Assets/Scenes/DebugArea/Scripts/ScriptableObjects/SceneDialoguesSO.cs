using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneDialoguesSO", menuName = "Debug/SceneDialoguesSO")]
public class SceneDialoguesSO : ScriptableObject
{   
    public List<DialogueContents> dialogueContents = new List<DialogueContents>();
    [System.Serializable]
    public class  DialogueContents
    {
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
