using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public static DialoguePanel instance;
    public GameObject Panel;
    public Text DialogueText;
    //储存中间值
    public List<string> DisplayText = null;
    public int print_progress;
    private float timer;
    public bool isPrint = false;
    public float perCharSpeed = 1;

    private string current_print_text;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        DisplayText = null;
    }

    void Update()
    {
        printText();
    }

    public void StartPrintText(InspectableObject inspectableObject)
    {
        if (DisplayText == null)
        {
            // Debug.Log("Start Printing Text");
            print_progress = 0;
            DisplayText = inspectableObject.InspectDescription;
            DisplayDialogueText(DisplayText[print_progress]);
        }
    }

    public void PrintNextText()
    {
        // Print to the end of texts
        if (DisplayText == null) return;
        if (print_progress + 1 == DisplayText.Count)
        {
            // Debug.Log("Print ends");
            DisplayText = null;
            current_print_text = "";
            PanelManager.instance.Showpanel(PanelType.HUD);
            isPrint = false;
        }
        // Continue printing the next part
        else
        {
            // Debug.Log("Printed next text");
            ++print_progress;
            DisplayDialogueText(DisplayText[print_progress]);
        }
    }

    public void DisplayDialogueText(string dialogue)
    {
        PanelManager.instance.Showpanel(PanelType.Dialogue);
        isPrint = true;
        timer = 0;
        current_print_text = dialogue;
    }

    public void InstantPrintText()
    {
        DialogueText.text = current_print_text;
        isPrint = false;
    }

    void printText()
    {
        try
        {
            if (isPrint)
            {
                DialogueText.text = current_print_text.Substring(0, (int)(perCharSpeed * timer));//截取
                timer += Time.deltaTime;
            }
        }
        catch (System.Exception)
        {
            printEnd();
        }
    }

    void printEnd()
    {
        isPrint = false;
    }


}
