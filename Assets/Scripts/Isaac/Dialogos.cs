using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public List<Dialogue> thisDialogue;
    public bool isMenu;

    private void Awake()
    {
        if (this.gameObject.name == "DialogoMenu 2" && PlayerPrefs.GetInt("CargarMenu 2") != 1)
        {
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.name == "DialogoMenu 1" && PlayerPrefs.GetInt("CargarMenu 2") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        
        DialogueManager.intance.dialogos = thisDialogue;
        if (isMenu)
        {
            
            DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        }
    }
}
