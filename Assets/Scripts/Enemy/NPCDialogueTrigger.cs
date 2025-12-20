using TMPro;
using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string message = "היי! חם פה ליד האח…";
    [SerializeField] private TextMeshProUGUI dialogueText;

    void Start()
    {
        if (dialogueText != null)
            dialogueText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        dialogueText.text = message;
        dialogueText.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        dialogueText.gameObject.SetActive(false);
    }
}
