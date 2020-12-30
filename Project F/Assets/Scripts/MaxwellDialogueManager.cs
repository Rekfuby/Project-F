using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxwellDialogueManager : MonoBehaviour
{
	private GameObject maxwell = null;
	private GameObject labs = null;
	LabsManager labscr;
	
    private Queue<string> playerSentences;
    private Queue<string> npcSentences;
    public bool dialogueFlag;
    public Text npcNameText;
    int playerReplicaCount = 0;
    int npcReplicaCount = 0;
    int[] dialogLogic = new int[] { 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0 };


    void Start()
    {
		if (maxwell == null)
		{
			maxwell = GameObject.Find("Maxwell");
			
		}
		
		if (labs == null)
		{
			labs = GameObject.Find("LabsManager");
			labscr = labs.GetComponent<LabsManager>();
		}
		
        playerSentences = new Queue<string>();
        npcSentences = new Queue<string>();
        playerReplicaCount = 1;
        npcReplicaCount = 1;
    }

    public void StartLockDoorDialogue(Dialogue LockDoorDialogue)
    {
        string levelSentence = "";
        playerSentences.Clear();
        foreach (string Sentence in LockDoorDialogue.playerSentences)
        {
            playerSentences.Enqueue(Sentence);
        }
        levelSentence = playerSentences.Dequeue();
        DialogueMenu.dialogueMenu.SetPlayerText(levelSentence);
    }

    public void StartPromptDialogue(Dialogue PromptDialogue)
    {
        string levelSentence = "";
        playerSentences.Clear();
        foreach (string Sentence in PromptDialogue.playerSentences)
        {
            playerSentences.Enqueue(Sentence);
        }
        levelSentence = playerSentences.Dequeue();
        DialogueMenu.dialogueMenu.SetPlayerText(levelSentence);
    }

    public void StartHoickerDialogue(Dialogue HoickerDialogue)
    {
        string levelSentence = "";
        playerSentences.Clear();
        foreach (string Sentence in HoickerDialogue.playerSentences)
        {
            playerSentences.Enqueue(Sentence);
        }
        levelSentence = playerSentences.Dequeue();
        DialogueMenu.dialogueMenu.SetPlayerText(levelSentence);
    }

    public void StartDialogue(Dialogue maxwellDialogue)
    {
        npcNameText.text = maxwellDialogue.npcName;

        playerSentences.Clear();
        npcSentences.Clear();

        foreach (string playerSentence in maxwellDialogue.playerSentences)
        {
            playerSentences.Enqueue(playerSentence);
        }
        foreach (string npcSentence in maxwellDialogue.npcSentences)
        {
            npcSentences.Enqueue(npcSentence);
        }

        DisplayNextSentence(dialogueFlag);
    }

    public void DisplayNextSentence(bool dialogueFlag)
    {
        Debug.Log("asdas");
        if (playerSentences.Count == 0 && npcSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string playerSentence = "";
        string npcSentence = "";
        if (dialogLogic[(playerReplicaCount + npcReplicaCount) - 2] == 0)
        {
            Debug.Log((playerReplicaCount + npcReplicaCount) - 2);
            dialogueFlag = false;
            npcSentence = npcSentences.Dequeue();
        }
        else
        {
            Debug.Log((playerReplicaCount + npcReplicaCount) - 2);
            dialogueFlag = true;
            playerSentence = playerSentences.Dequeue();
        }

        if (dialogueFlag)
        {
            switch (playerReplicaCount)
            {
                case 1:
                    DialogueMenu.dialogueMenu.SetPlayerText(playerSentence);
                    playerReplicaCount++;
                    break;
                case 2:
                    DialogueMenu.dialogueMenu.SetPlayerText(playerSentence);
                    playerReplicaCount++;
                    break;
                case 3:
                    DialogueMenu.dialogueMenu.SetPlayerText(playerSentence);
                    playerReplicaCount++;
                    break;
                case 4:
                    DialogueMenu.dialogueMenu.SetPlayerText(playerSentence);
                    playerReplicaCount++;
                    break;
                case 5:
                    DialogueMenu.dialogueMenu.SetPlayerText(playerSentence);
                    playerReplicaCount++;
                    break;
                default:
                    break;
            }
        }
        else
        {
            //DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
            switch (npcReplicaCount)
            {
                case 1:
					maxwell.GetComponent<Maxwell>().idle1();
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
                    break;
                case 2:
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
					maxwell.GetComponent<Maxwell>().idle1();
                    break;
                case 3:
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
                    break;
                case 4:
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
                    break;
                case 5:
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
					maxwell.GetComponent<Maxwell>().walkDown();
                    break;
                case 6:
                    DialogueMenu.dialogueMenu.SetNpcText(npcSentence);
                    npcReplicaCount++;
					labscr.unlockSlideDoor();
                    break;
                default:
                    break;
            }
        }
        

    }

    public void EndDialogue()
    {
        DialogueMenu.dialogueMenu.NpcButtonPressed();

    }
}
