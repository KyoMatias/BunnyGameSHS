using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogues", fileName = "DL_Line")]
public class Dialogue_LinesSO : ScriptableObject
{
    public enum Characters
    {
        Character1,
        Character2,
    }
    public Characters CurrentCharacter;
    public string[] dialogueLines;
    public DialogueContainer[] dialogueContainer;
    public string CurrentLine;
    public string CharName;
    public string Char2Name;
    public string currentSpeaking;
    public int CurrentLineIndex;


    public void SwitchCharacter(Characters characters)
    {
        CurrentCharacter = characters;
        switch (CurrentCharacter)
        {
            case Characters.Character1:
            GetCurrentlySpeaking(GetCharacterName());
            break;
            case Characters.Character2:
            GetCurrentlySpeaking(GetCharacterTwoName());
            break;
            default:
            break;
        }
    }
    public void NextLine()
    {
        if(dialogueLines.Length == 0)
        {
            Debug.LogError("There Are No Available Lines");
            return;
        }

        CurrentLineIndex++;
        if(CurrentLineIndex >= dialogueLines.Length)
        {
            CurrentLineIndex = 0;
        }
        CurrentLine = dialogueLines[CurrentLineIndex];

    }

    public void PrevLine()
    {
        CurrentLineIndex--;
    }

    public void ResetDialogues()
    {
        CurrentLineIndex = 0;
        CurrentLine = dialogueLines[CurrentLineIndex];
    }

    public string GetCharacterName()
    {
        return CharName;
    }
    
    public string GetCharacterTwoName()
    {
        return Char2Name;
    }

    public string GetCurrentlySpeaking(string chara)
    {
        currentSpeaking = chara;
        return currentSpeaking;
    }

    public string GetSpeaker()
    {
        return currentSpeaking;
    }


}
[System.Serializable]

public class CharacterSheet
{
    public string CharacterName;
}

[System.Serializable]
//The Dialogue Container Class is a DEBUG Class that aims to focus on the flexibility of the Array System on the Dialogue Manager.
//The main objective of the Dialogue container is to eliminate the redundancy of lines in the CutsceneManager.cs script.
public class DialogueContainer
{
    [SerializeField] private string DialogueCategory;// Sets the Category of the Dialogue for Organization.
    [SerializeField] private int DialogueNum;// Sets the Dialogue Number for ease of search by the algorithm.
    public string DialogueID;// A public variable that returns the full identification ID of the Dialogue.
    public string CharacterName;// Displays the currently speaking character's name to the inspector.
    public string CharacterLine;// Displays the Line that the character will say in the Dialogue UI.
    public float DialogueTime;// Sets the Amount of time the Dialogue will be displayed before it automatically switches to the next one.
    public bool IsDone;// DEBUG: Sets the trigger if the whole dialogue for the scene is finish.

   public string returnID()
    {
        return DialogueID = DialogueCategory + DialogueNum;
    }
}
