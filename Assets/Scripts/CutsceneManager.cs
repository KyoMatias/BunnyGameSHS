using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public GameObject FadeHud;
    public DialogueManager dialogueManager;
    public GameObject DialogueHUD;

    void Awake()
    {
        DialogueHUD.transform.DOLocalMove(new Vector3(-960,-1200,0), 0.1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        InitiateParameters();
        StartCoroutine(StartScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartScene()
    {

        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fade());
        yield return new WaitForSeconds(1.0f);
        SlideIn();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(StartDialogues());
        


    }
    IEnumerator StartDialogues()
    {
        dialogueManager.ShowNextLine();// M: Shit..
        yield return new WaitForSeconds(2.0f);

        dialogueManager.ShowNextLine();//M: I'm coming home late, again...
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine();//M: These workloads from class are too much.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine();//M: Too Much.
        yield return new WaitForSeconds(2f);

        dialogueManager.ShowNextLine(); // M: My mathematics exam feels like a failure.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // M: And Professor Facundo failed me on Coo.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // M: Now Principal Torda will revoke my Hon.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // M: Not like this.
        yield return new WaitForSeconds(2);

        dialogueManager.ShowNextLine(); // M: Please, Not Like This.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // H: Huh? Boe is calling?
        yield return new WaitForSeconds(2);

        dialogueManager.ShowNextLine(); // H: What for? She is usually asleep by this ho.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // H: Hello?
        yield return new WaitForSeconds(2);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: Macy, you at home by any chance?
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterOne();
        dialogueManager.ShowNextLine(); // M: Not yet, I'm still on the train.
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: You're still not home?
        yield return new WaitForSeconds(2);

        dialogueManager.SwitchCharacterOne();
        dialogueManager.ShowNextLine(); // M: No Boe, Like what I said,
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // M: If I want to keep my honors,
        yield return new WaitForSeconds(2);

        dialogueManager.ShowNextLine(); // M: I need all the time I need. and it's crucial!
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: Just don't overwork yourself with it.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // B: You'll figure it out.
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterOne();
        dialogueManager.ShowNextLine(); // M: Easy for you to say, You are a medalist.
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: It's not my fault my family is strict.
        yield return new WaitForSeconds(3);

        dialogueManager.ShowNextLine(); // B: Anyhow, I called because I came to check
        yield return new WaitForSeconds(3);

         dialogueManager.SwitchCharacterOne();
        dialogueManager.ShowNextLine(); // M: Why so?
        yield return new WaitForSeconds(2);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: Tons of People, specifically students are
        yield return new WaitForSeconds(3);

        dialogueManager.SwitchCharacterOne();
        dialogueManager.ShowNextLine(); // M: Really?
        yield return new WaitForSeconds(2);

        dialogueManager.SwitchCharacterTwo();
        dialogueManager.ShowNextLine(); // B: Yeah, and there are no clues nor evid
        yield return new WaitForSeconds(3);
    }

    void InitiateParameters()
    {
        dialogueManager.InitiateAll();
    }

    void SlideIn()
    {
        DialogueHUD.transform.DOLocalMove(new Vector3(-960,-540,0), 2);
    }

    public IEnumerator Fade()
    {
        CanvasGroup FadeCanvas = FindAnyObjectByType<CanvasGroup>();
        Camera camera= FindAnyObjectByType<Camera>();
        FadeCanvas.interactable = false;
        Color startColor = camera.backgroundColor;
        Color EndColor = new Color32(0,0,0, 255);
        float t = 0.0f;
        float duration = 3.0f;
        while (FadeCanvas.alpha > 0.0f)
        {
            camera.backgroundColor = Color.Lerp(startColor, EndColor, t);
            if(t < 1)
            {
                t += Time.deltaTime / duration;
            }
            FadeCanvas.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
        camera.backgroundColor = new Color32(0,0,0, 255);
    }
    //     public IEnumerator DoFade()
    // {
    //     CanvasGroup canvasGroup = FindObjectOfType<CanvasGroup>();
    //     Camera camera = FindObjectOfType<Camera>();
    //     canvasGroup.interactable = false;
    //     Color startcolor = camera.backgroundColor;
    //     Color endcolor = new Color32(41, 57, 73, 255);
    //     float t = 0.0f;
    //     float duration = 3.0f;
    //     while (canvasGroup.alpha > 0)
    //     {
    //         camera.backgroundColor = Color.Lerp(startcolor, endcolor, t);
    //         if (t < 1)
    //         {
    //             t += Time.deltaTime / duration;
    //         }
    //         canvasGroup.alpha -= Time.deltaTime / 2;
    //         yield return null;
    //     }
    //     yield return null;
    //     camera.backgroundColor = new Color32(41, 57, 73, 255);
    //     SceneManager.LoadScene("MainOSScreen");
    // }


}
