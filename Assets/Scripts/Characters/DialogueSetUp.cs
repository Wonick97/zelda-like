using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSetUp : MonoBehaviour
{
    public Dialogue dialogue;
    public TextMeshProUGUI nameDialogue;
    public TextMeshProUGUI textDialogue;
    public Image face;

    private int dialogueID = 0;
    private int sentenceID = 0;
    public bool dialogueStarted;

    public void DialogueTrigger()
    {
        /* HABLA EL SIGUIENTE PERSONAJE DEL DIALOGO */
        if (sentenceID >= dialogue.dialogue_segment[dialogueID].sentences.Length)
        {
            dialogueID++;
            sentenceID = 0;
        }
        /* CONTINUA EL DIALOGO */
        if (dialogue.dialogue_segment.Count > dialogueID)
        {
            dialogueStarted = true;
            nameDialogue.text = dialogue.dialogue_segment[dialogueID].speaker;
            textDialogue.text = dialogue.dialogue_segment[dialogueID].sentences[sentenceID];
            face.sprite = dialogue.dialogue_segment[dialogueID].face;
        }
        /* TERMINA EL DIALOGO */
        else
        {
            dialogueStarted = false;
            //Desactiva el canvas del dialogo
            face.GetComponentInParent<Canvas>().gameObject.SetActive(false);
            //Reactiva canvas de 'Press E to talk'
            GetComponentInChildren<Canvas>(true).gameObject.SetActive(true);
            //Resetea los valores para volver a comenzar el diálogo
            dialogueID = 0;
            sentenceID = 0;
        }
    }

    public void NextSentence()
    {
        sentenceID++;
        DialogueTrigger();
    }
}
