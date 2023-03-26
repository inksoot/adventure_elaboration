using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Player")
        {
            Debug.Log("enemy contact with player");
            FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
        }
    }

    public void TriggerDialogue()
    {
        
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }
}
