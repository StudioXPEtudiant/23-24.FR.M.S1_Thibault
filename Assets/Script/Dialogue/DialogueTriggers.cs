
using UnityEngine;
using UnityEngine.UI;

public class DialogueTriggers : MonoBehaviour
{
   public Dialogue dialogue;

   public bool isInRange; 

   private Text interactUI;

   private void Awake()
   {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
   }
    
   void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
  