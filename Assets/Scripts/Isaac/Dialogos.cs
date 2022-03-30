using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public List<Dialogue> thisDialogue;
    public bool isMenu;

    private void Start()
    {
        
        DialogueManager.intance.dialogos = thisDialogue;
        if (isMenu)
        {
            DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        }
    }
}
