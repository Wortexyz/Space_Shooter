using TMPro;
using UnityEngine;

public class DialogieManager : MonoBehaviour
{
   

    [SerializeField] TMP_Text DialogueText;
    
    [SerializeField] string[] Texts;
    int dialogueIndex = 0;

    public void ChangeText()
    {

        if (dialogueIndex < Texts.Length)
        {

            DialogueText.text = Texts[dialogueIndex];
            dialogueIndex++;

        }
    }



        


    }
