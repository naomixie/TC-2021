using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public static DialoguePanel instance;
    public GameObject Panel;
    public Text DialogueText;
    //储存中间值
    public List<string> DisplayText;
    private float timer;
    private bool isPrint = false;
    public float perCharSpeed = 1;

    private string current_print_text;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        printText();
    }

    public void DisplayDialogueText(string dialogue)
    {
        Panel.SetActive(true);
        isPrint = true;
        timer = 0;
        current_print_text = dialogue;
    }

    public void CloseDialoguePanel()
    {
        Panel.SetActive(false);
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
