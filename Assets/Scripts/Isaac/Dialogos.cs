using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public List<Dialogue> thisDialogue;
    public bool isMenu;
    public bool isOne, isTwo, isTree, isFor;

    private void Awake()
    {
        if (isMenu)
        {

            if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 0 && PlayerPrefs.GetInt("CargarMenu 4") == 0 && PlayerPrefs.GetInt("CargarMenu 3") == 0 && !isOne)
            {
                this.gameObject.SetActive(false);
            }

            if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 0 && PlayerPrefs.GetInt("CargarMenu 4") == 0 && !isTwo)
            {
                this.gameObject.SetActive(false);

            }

            if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 1 && PlayerPrefs.GetInt("CargarMenu 4") == 0 && !isTree)
            {
                this.gameObject.SetActive(false);

            }

            if (PlayerPrefs.GetInt("CargarMenu 1") == 1 && PlayerPrefs.GetInt("CargarMenu 2") == 1 && PlayerPrefs.GetInt("CargarMenu 3") == 1 && PlayerPrefs.GetInt("CargarMenu 4") == 1 && !isFor)
            {
                this.gameObject.SetActive(false);

            }


            //if (!isOne && PlayerPrefs.GetInt("CargarMenu 2") != 1)
            //{
            //    this.gameObject.SetActive(false);
            //}

            //if (!isTwo && PlayerPrefs.GetInt("CargarMenu 2") == 1)
            //{
            //    this.gameObject.SetActive(false);
            //}

            //if (!isTree && PlayerPrefs.GetInt("CargarMenu 3") == 1)
            //{
            //    this.gameObject.SetActive(false);
            //}

            //if (!isFor && PlayerPrefs.GetInt("CargarMenu 4") == 1)
            //{
            //    this.gameObject.SetActive(false);
            //}
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
