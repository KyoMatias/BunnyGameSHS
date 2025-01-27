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
