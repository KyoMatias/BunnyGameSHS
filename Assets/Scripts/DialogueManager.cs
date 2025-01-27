using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue_LinesSO dialogue_LinesSO;
    [SerializeField] private TextMeshProUGUI DialogueUIText;
    [SerializeField] private TextMeshProUGUI Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowDialogue();
    }

    public void InitiateAll()
    {
        dialogue_LinesSO.ResetDialogues();
        SwitchCharacterOne();
    }

    void ShowDialogue()
    {
        DialogueUIText.SetText(dialogue_LinesSO.CurrentLine);
        Character.SetText(dialogue_LinesSO.GetSpeaker());
    }

    [Button]
    public void ShowNextLine()
    {
        dialogue_LinesSO.NextLine();
    }
    
    [Button]
    public void ShowPreviousLine()
    {
        dialogue_LinesSO.PrevLine();
    }

    [Button]
    public void SwitchCharacterOne()
    {
        dialogue_LinesSO.SwitchCharacter(Dialogue_LinesSO.Characters.Character1);
    }
    [Button]
    public void SwitchCharacterTwo()
    {
        dialogue_LinesSO.SwitchCharacter(Dialogue_LinesSO.Characters.Character2);
    }
}
