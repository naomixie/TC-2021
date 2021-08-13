using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : InteractableObject
{
    public List<string> InspectDescription;

    public char separator = ';';

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Inspectable Object: Interact()");
        ProcessText();
        DialoguePanel.instance.StartPrintText(this);
    }

    public void ProcessText()
    {
        List<string> temp = new List<string>();
        temp = InspectDescription;
        for (int i = 0; i < temp.Count; ++i)
        {
            InspectDescription[i] = temp[i].Replace(separator, '\n');
        }
    }
}
