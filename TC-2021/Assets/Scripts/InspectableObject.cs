using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : InteractableObject
{
    public List<string> InspectDescription;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Inspectable Object: Interact()");
        DialoguePanel.instance.StartPrintText(this);
    }
}
