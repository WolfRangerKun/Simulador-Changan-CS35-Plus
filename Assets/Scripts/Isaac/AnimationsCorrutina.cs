using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCorrutina : MonoBehaviour
{
    public bool canContinue, isCarretera, isRocas, isCiudad;
    void Start()
    {
        if (isCarretera)
        {
            StartCoroutine(CarreteraCorrutine());

        }
        if (isRocas)
        {
            StartCoroutine(RocasCorrutine());

        }
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

        yield return new WaitForSeconds(2);
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
        yield return new WaitForSeconds(1.7f);

        DialogueManager.intance.index = 15;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[15]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 22);
        DialogueManager.intance.HideDialogo();
        MiniGameCanvas.instance.canUse = true;
        StartCoroutine(MiniGameCanvas.instance.RamdomAutoX());

        yield return new WaitForSeconds(60);
        print("dialogo de termino");
        ///// falta hacer el final pal menu
        MiniGameCanvas.instance.canUse = false;
        MiniGameCanvas.instance.autoFrente.GetComponent<Rigidbody2D>().isKinematic = true;
        MiniGameCanvas.instance.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        DialogueManager.intance.HideDialogo();

        StopCoroutine(MiniGameCanvas.instance.RamdomAutoX());

        DialogueManager.intance.dialogos = thisDialogue.GetComponent<Dialogos>().thisDialogue;
        DialogueManager.intance.index = 23;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[23]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 26);
        DialogueManager.intance.HideDialogo();
        PlayerPrefs.SetInt("CargarMenu 2", 1);
        ChangeScene.intance.CargarNivel(0);
    }



    public void CanContinue()
    {
        canContinue = true;
    }

    IEnumerator RocasCorrutine()
    {
        //GameObject cvCamCarretera = GameObject.Find("Cm Presentation");
        //GameObject cvCamBth = GameObject.Find("CM vcamBlouetoodth");
        //GameObject cvCamGame = GameObject.Find("CM vcamGAME");


        GameObject thisDialogue = GameObject.Find("DialogoRocas");
        yield return new WaitForSeconds(2);
        DialogueManager.intance.dialogos = thisDialogue.GetComponent<Dialogos>().thisDialogue;

        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index == 5);
        //cvCamCarretera.SetActive(false);
        DialogueManager.intance.HideDialogo();
        RaycastMovementDetection.instance.start = true;
        yield return new WaitForSeconds(.7f);
        StartCoroutine(ControlRoquerio.instance.GetNumber());
        StartCoroutine(ControlRoquerio.instance.RandomForce());
        yield return new WaitUntil(() =>RaycastMovementDetection.instance.win == true);
        StopCoroutine(ControlRoquerio.instance.GetNumber());
        StopCoroutine(ControlRoquerio.instance.RandomForce());
        DialogueManager.intance.index = 6;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[6]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 9);
        //cvCamCarretera.SetActive(false);
        DialogueManager.intance.HideDialogo();
        //PlayerPrefs.SetInt("CargarMenu 2", 1);
        ChangeScene.intance.CargarNivel(0);
    }
}
