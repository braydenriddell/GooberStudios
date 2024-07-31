using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    private Story globalVariablesStory;

    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        //Read global file
        globalVariablesStory = new Story(loadGlobalsJSON.text);

        //Initialize dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized Dictionary with: " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        TransferVariables(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    public void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            //Remove old variable
            variables.Remove(name);
            //Replace with updated variable
            variables.Add(name, value);
        }

        Debug.Log("Variable changed: " + name + " = " + value);
    }

    private void TransferVariables(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
