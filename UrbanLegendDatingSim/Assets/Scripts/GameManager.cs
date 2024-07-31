using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int frameRate = 60;
    int vSync = 1;

    float fadeTime1 = 0.016f;
    float fadeTime3 = 0.1f;

    public DialogueManager dialogueManager;

    [Header("UI Elements")]
    public GameObject uiPanel;
    public GameObject gameScene;

    public GameObject dialoguePanel;

    public GameObject trapperVisitor;

    [Header("Bools")]
    public bool complete_rosary;
    public bool complete_flag;
    public bool complete_gun;


    [Header("Ink & Ending Vars")]
    public GameObject endScene;
    public GameObject endscreenUI;
    public GameObject endtextUI;
    public GameObject endbuttonsUI;
    public TextMeshProUGUI endText;
    public string endstate = "";

    public int trapper_ending = 0;

    public SpriteRenderer foxSprite;
    public Sprite fox_dead;
    public TextAsset introJSON;
    public TextAsset end_neutralJSON;
    public TextAsset end_goodJSON;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = vSync;
    }

    void Start()
    {
        StartCoroutine(StartQuotes());
        endScene.SetActive(false);
    }

    void Update()
    {
        //visitorIntroduced = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("visitorIntroduced")).value;
    }

    private IEnumerator StartQuotes()
    {
        int delayTime = 8;

        //Fade in quotes
        yield return new WaitForSeconds(2);
       //StartCoroutine(FadeIn(quotesPanel, fadeTime1));

        //Wait for seconds
        yield return new WaitForSeconds(delayTime);

        //Enable Game Scene
        //cannotTranscriptButton.SetActive(true);
        gameScene.SetActive(true);

        //Fade in game UI
        StartCoroutine(FadeIn(uiPanel, fadeTime1));

        //Start first cut scene
        FindObjectOfType<AudioManager>().Play("Campfire");
        FindObjectOfType<AudioManager>().Play("Crickets");

        yield return new WaitForSeconds(2);
    }

    public IEnumerator TrapperIntro()
    {
        Debug.Log("Trapper intro cut scene");
        yield return new WaitForSeconds(2);

        //Dialogue start
        DialogueManager.GetInstance().DialogueStart(introJSON);
        //enableTrapperItems = true;
    }


    public void DialogueMode()
    {

        //Enable dialogue mode
        StartCoroutine(FadeIn(dialoguePanel, fadeTime3));
        //if (dialogueManager.canContinue)
        //{
        //    dialogueManager.ChoicesDisplay();
        //}
    }


    private IEnumerator FadeIn(GameObject obj, float fadeTime)
    {
        Debug.Log("IN: " + obj);

        if (obj.GetComponent<CanvasGroup>() != null)
        {
            while (obj.GetComponent<CanvasGroup>().alpha < 1)
            {
                obj.GetComponent<CanvasGroup>().alpha += fadeTime;
                yield return null;
            }
        }


        if (obj.GetComponent<SpriteRenderer>() != null)
        {
            float alphaVal = obj.GetComponent<SpriteRenderer>().color.a;
            Color color = obj.GetComponent<SpriteRenderer>().color;

            while (obj.GetComponent<SpriteRenderer>().color.a < 1)
            {

                alphaVal += fadeTime;
                color.a = alphaVal;
                obj.GetComponent<SpriteRenderer>().color = color;
                yield return null;
            }
        }
    }

    private IEnumerator FadeOut(GameObject obj, float fadeTime)
    {
        Debug.Log("OUT: " + obj);
        if (obj.GetComponent<CanvasGroup>() != null)
        {
            while (obj.GetComponent<CanvasGroup>().alpha > 0)
            {
                obj.GetComponent<CanvasGroup>().alpha -= fadeTime;
                yield return null;
            }
        }


        if (obj.GetComponent<SpriteRenderer>() != null)
        {
            float alphaVal = obj.GetComponent<SpriteRenderer>().color.a;
            Color color = obj.GetComponent<SpriteRenderer>().color;
            while (obj.GetComponent<SpriteRenderer>().color.a > 0)
            {

                alphaVal -= fadeTime;
                color.a = alphaVal;
                obj.GetComponent<SpriteRenderer>().color = color;
                yield return null;
            }
        }
    }


    public IEnumerator EndGame()
    {
        //Disable dialogue mode
        StartCoroutine(FadeOut(dialoguePanel, fadeTime3));
        yield return new WaitForSeconds(3);
        endScene.SetActive(true);

        //Fade in ending screen
        endScene.SetActive(true);
        StartCoroutine(FadeIn(endscreenUI, fadeTime1));
        StartCoroutine(FadeOut(gameScene, fadeTime1));
        StartCoroutine(FadeOut(uiPanel, fadeTime1));

        if (endstate == "neutral")
        {
            endText.text = "Neutral ending achieved.";
        }
        else if (endstate == "good")
        {
            endText.text = "Good ending achieved!";
        }

        yield return new WaitForSeconds(5);
        StartCoroutine(FadeIn(endtextUI, fadeTime1));
        gameScene.SetActive(false);

        yield return new WaitForSeconds(4);
        StartCoroutine(FadeIn(endbuttonsUI, fadeTime1));
    }

    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    private void MoveObject(GameObject obj, GameObject objTarget, float speed)
    {
        obj.transform.position = Vector2.MoveTowards(obj.transform.position, objTarget.transform.position, speed * Time.deltaTime);
    }
}
