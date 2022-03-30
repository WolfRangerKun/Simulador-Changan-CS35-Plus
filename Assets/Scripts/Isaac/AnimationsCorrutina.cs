using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCorrutina : MonoBehaviour
{
    public bool canContinue;
    void Start()
    {
        StartCoroutine(CarreteraCorrutine());
    }

    IEnumerator CarreteraCorrutine()
    {
        GameObject cvCamCarretera = GameObject.Find("Cm Presentation");
        GameObject cvCamBth = GameObject.Find("CM vcamBlouetoodth");
        GameObject cvCamGame = GameObject.Find("CM vcamGAME");


        GameObject thisDialogue = GameObject.Find("DialogoInicio");
        yield return new WaitForSeconds(6);
        DialogueManager.intance.dialogos = thisDialogue.GetComponent<Dialogos>().thisDialogue;

        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index == 5);
        cvCamCarretera.SetActive(false);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.7f);

        cvCamBth.GetComponent<Animator>().SetTrigger("Go");

        yield return new WaitForSeconds(3);
        DialogueManager.intance.index = 6;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[6]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 10);

        DialogueManager.intance.HideDialogo();

        print("conectate");
        yield return new WaitUntil(() => canContinue == true);
        print("conectado");

        DialogueManager.intance.index = 11;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[11]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 14);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.7f);

        cvCamBth.SetActive(false);
        yield return new WaitForSeconds(1);

        DialogueManager.intance.index = 15;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[15]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 23);
        DialogueManager.intance.HideDialogo();

        /// falta hacer el final pal menu
    }

    public void CanContinue()
    {
        canContinue = true;
    }
}
