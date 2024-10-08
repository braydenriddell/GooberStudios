using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public GameManager gameManager;
    public TextAsset loadGlobalsJSON;

    private Coroutine typewritterEffectCoroutine;
    private DialogueVariables variablesScript;

    [Header("UI Elements")]
    public GameObject dialogueBox;
    public TextMeshProUGUI text;
    public Story currentStory;
    public GameObject continueButton;
    public GameObject mainText;
    public GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public TextMeshProUGUI nameText;
    public GameObject clickanywhere_skip;
    public GameObject clickanywhere_next;

    [Header("Options")]
    public SpriteRenderer character;
    public float typewritterSpeed = 0.04f;
    public float punctuationSpeed = 0.1f;

    public bool dialoguePlaying;
    public bool canContinue = false;
    private bool skipButtonPressed = false;
    private bool dialogueTyping = false;

    private const string TAG_NAME = "name";
    private const string TAG_SPRITE = "sprite";


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one dialogue manager in scene");
        }
        instance = this;

        variablesScript = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {

        //Set dialogue assets to false
        dialoguePlaying = false;
        dialogueBox.SetActive(false);

        //Get choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            skipButtonPressed = true;
        }

        if (canContinue == true && dialoguePlaying == false)
        {
            return;
        }

        if (canContinue && skipButtonPressed && currentStory.currentChoices.Count == 0)
        {
            skipButtonPressed = false;
        }

        //Audio
        //if (dialogueTyping == true && skipButtonPressed == false)
        //{
            //FindObjectOfType<AudioManager>().Play("DialogueWriting");
            //if (FindObjectOfType<AudioManager>().CheckIfPlaying("DialogueWriting") == false)
            //{
            //    FindObjectOfType<AudioManager>().Play("DialogueWriting");
            //}
            //Debug.Log("dialogue audio");
        //}
        //else
        //{
            //FindObjectOfType<AudioManager>().Stop("DialogueWriting");
        //}
    }

    public void ClickAnywhereSkip()
    {
        skipButtonPressed = true;
        clickanywhere_skip.SetActive(false);
    }

    public void DialogueStart(TextAsset inkJSON)
    {
        //Enable all dialogue assets
        currentStory = new Story(inkJSON.text);
        dialoguePlaying = true;
        dialogueBox.SetActive(true);
        mainText.gameObject.SetActive(true);

        variablesScript.StartListening(currentStory);

        DialogueContinue();
    }

    public void DialogueContinue()
    {
        clickanywhere_skip.SetActive(true);

        if (currentStory.canContinue)
        {
            //Current dialogue text with typewritter effect
            if (typewritterEffectCoroutine != null)
            {
                StopCoroutine(typewritterEffectCoroutine);
            }
            typewritterEffectCoroutine = StartCoroutine(TypewritterEffect(currentStory.Continue()));

            //Tag handler
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(DialogueExit());
        }
    }

    public IEnumerator DialogueExit()
    {
        yield return new WaitForSeconds(0.2f);

        variablesScript.StopListening(currentStory);

        //Disable dialogue assets
        dialoguePlaying = false;
        dialogueBox.SetActive(false);
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
        text.text = "";
        clickanywhere_skip.SetActive(false);
        Debug.Log("Exit Dialogue");
    }

    private void ChoicesDisplay()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //If more choices than supported
        if (currentChoices.Count > choices.Length)
        {
            Debug.Log("Doesn't support this many number of choices. Can only do: " + currentChoices.Count);
        }

        //Enable choices being used
        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            //Disables continue button if there are choices
            continueButton.gameObject.SetActive(false);
            clickanywhere_skip.SetActive(false);
            clickanywhere_next.SetActive(false);

            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        //DIsable reamining choices not being used
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(ChoiceSelect());
    }

    private IEnumerator ChoiceSelect()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void ChoiceMake(int choiceIndex)
    {
        if (canContinue == true)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            DialogueContinue();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            //Failsafe
            if (splitTag.Length != 2)
            {
                Debug.Log("Tag could not be parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case TAG_NAME:
                    nameText.text = tagValue;
                    break;
                case TAG_SPRITE:
                    if (tagValue == "null")
                    {
                        character.sprite = null;
                    }
                    character.sprite = Resources.Load<Sprite>(tagValue);
                    //avatarImage.sprite = avatarSprite;
                    break;
                default:
                    Debug.Log("Tag not set up in handler: " + tag);
                    break;
            }
        }
    }

    private IEnumerator TypewritterEffect(string line)
    {
        //Clear dialogue text box
        text.text = line;
        text.maxVisibleCharacters = 0;

        //Disable continue assets while dialogue is going
        continueButton.gameObject.SetActive(false);
        clickanywhere_next.SetActive(false);
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }


        canContinue = false;
        dialogueTyping = true;


        //Display one at a time
        foreach (char letter in line.ToCharArray())
        {

            if (skipButtonPressed == true)
            {
                skipButtonPressed = false;
                dialogueTyping = false;
                text.maxVisibleCharacters = line.Length;
                break;
            }

            //Check for punctuation
            if (letter == '.' || letter == '!' || letter == '?' || letter == ',')
            {
                text.maxVisibleCharacters++;
                yield return new WaitForSeconds(punctuationSpeed);
            }
            else
            {
                text.maxVisibleCharacters++;
                yield return new WaitForSeconds(typewritterSpeed);
            }
        }

        //Activate continue assets
        continueButton.gameObject.SetActive(true);
        clickanywhere_next.SetActive(true);
        ChoicesDisplay();

        //Continue after message is typed out
        canContinue = true;
        dialogueTyping = false;
    }

    //Gets variable in global ink file
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        variablesScript.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    //Changes variable in global ink file
    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if (variablesScript.variables.ContainsKey(variableName))
        {
            //Update variable
            variablesScript.variables.Remove(variableName);
            variablesScript.variables.Add(variableName, variableValue);
            Debug.Log("Initialized " + variableName + " = " + variableValue);
        }
        else
        {
            Debug.Log(variableName + " is not initialized");
        }
    }
}
