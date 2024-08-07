using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int frameRate = 60;
    int vSync = 1;

    float fadeTime1 = 0.016f;

    public DialogueManager dialogueManager;

    [Header("UI Elements")]
    public GameObject uiPanel;
    public GameObject dialoguePanel;
    [SerializeField] GameObject blackScreen;

    [Header("Bools")]
    public bool shouldEnd;
    bool ending = false;


    public TextAsset introJSON;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
        QualitySettings.vSyncCount = vSync;
    }

    void Start()
    {
        DialogueManager.GetInstance().DialogueStart(introJSON);
        Invoke("MothmanIntro", 2);
        //StartCoroutine(FadeOut(blackScreen, 4f));
    }

    void Update()
    {
        shouldEnd = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("end")).value;

        if (shouldEnd && !ending)
        {
            StartCoroutine(EndGame());
        }
    }


    public void MothmanIntro()
    {
        Debug.Log("Mothman intro");

        //Dialogue start
        DialogueManager.GetInstance().DialogueStart(introJSON);
    }

    IEnumerator EndGame()
    {
        ending = true;
        yield return new WaitForSeconds(2);
        blackScreen.SetActive(true);
        //StartCoroutine(FadeIn(blackScreen, 2f));
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndScreen");
        yield return null;
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
        yield return null;
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
        yield return null;
    }

    /*public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }*/

    /*private void MoveObject(GameObject obj, GameObject objTarget, float speed)
    {
        obj.transform.position = Vector2.MoveTowards(obj.transform.position, objTarget.transform.position, speed * Time.deltaTime);
    }*/
}
