using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueMenu : MonoBehaviour
{
    [SerializeField]
    public static DialogueMenu dialogueMenu;
    [SerializeField]
    public TMPro.TMP_Text dialogueNpcText;
    [SerializeField]
    public TMPro.TMP_Text dialoguePlayerText;
    [SerializeField]
    public GameObject playerDialogue;
    [SerializeField]
    public GameObject npcDialogue;

    void Awake()
    {
        dialogueMenu = this;
        dialogueMenu.gameObject.SetActive(false);
    }
    public void SetNpcText(string text)
    {
        dialogueNpcText.text = text;
        playerDialogue.SetActive(false);
        npcDialogue.SetActive(true);
        dialogueMenu.gameObject.SetActive(true);
    }

    public void NpcButtonPressed()
    {
        dialogueMenu.gameObject.SetActive(false);
    }

    public void SetPlayerText(string text)
    {
        dialoguePlayerText.text = text;
        playerDialogue.SetActive(true);
        npcDialogue.SetActive(false);
        dialogueMenu.gameObject.SetActive(true);
    }

    public void PlayerButtonPressed()
    {
        dialogueMenu.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
