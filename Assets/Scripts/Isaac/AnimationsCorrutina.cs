using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCorrutina : MonoBehaviour
{
    public bool canContinue, isCarretera, isRocas, isCiudad;
    public GameObject guiaVisual ;

    private void Awake()
    {
        if (isCiudad)
        {
            guiaVisual.SetActive(false);

        }
    }
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
        if (isCiudad)
        {
            StartCoroutine(UrbanoCorrutine());

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
        GameObject cvCamInicio = GameObject.Find("CM Inicio");
        GameObject cvCamPOV = GameObject.Find("CM Muestra");
        GameObject cvCamGame = GameObject.Find("CM Game");

        GameObject rc = GameObject.Find("Rocas");
        GameObject anim = GameObject.Find("MasterAnim");

        GameObject thisDialogue = GameObject.Find("DialogoRocas");
        yield return new WaitForSeconds(2);
        DialogueManager.intance.dialogos = thisDialogue.GetComponent<Dialogos>().thisDialogue;

        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index == 2);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.5f);

        cvCamInicio.SetActive(false);
        yield return new WaitForSeconds(.7f);
        DialogueManager.intance.index = 3;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[3]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 5);
        DialogueManager.intance.HideDialogo();

        cvCamInicio.SetActive(true);
        cvCamPOV.SetActive(false);
        yield return new WaitForSeconds(1f);
        DialogueManager.intance.index = 6;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[6]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 7);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.1f);


        cvCamInicio.SetActive(false);
        yield return new WaitForSeconds(1f);
        guiaVisual.SetActive(true);
        RaycastMovementDetection.instance.marcoContador.gameObject.SetActive(true);

        RaycastMovementDetection.instance.contador.gameObject.SetActive(true);
        rc.GetComponent<Animator>().SetInteger("State", 1);
        yield return new WaitForSeconds(.5f);
        anim.GetComponent<Animator>().SetInteger("Started", 1);
        yield return new WaitForSeconds(.5f);
        RaycastMovementDetection.instance.start = true;

        StartCoroutine(ControlRoquerio.instance.GetNumber());
        StartCoroutine(ControlRoquerio.instance.RandomForce());
        yield return new WaitUntil(() =>RaycastMovementDetection.instance.win == true);
        guiaVisual.SetActive(false);
        RaycastMovementDetection.instance.contador.gameObject.SetActive(false);
        RaycastMovementDetection.instance.marcoContador.gameObject.SetActive(false);


        StopCoroutine(ControlRoquerio.instance.GetNumber());
        StopCoroutine(ControlRoquerio.instance.RandomForce());

        cvCamInicio.SetActive(true);
        yield return new WaitForSeconds(1.2f);

        DialogueManager.intance.index = 8;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[8]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 11);
        //cvCamCarretera.SetActive(false);
        DialogueManager.intance.HideDialogo();
        //PlayerPrefs.SetInt("CargarMenu 2", 1);
        PlayerPrefs.SetInt("CargarMenu 4", 1);
        ChangeScene.intance.CargarNivel(0);
    }

    IEnumerator UrbanoCorrutine()
    {
        GameObject cvCamInicio = GameObject.Find("CM Inicio");
        GameObject cvCamGame = GameObject.Find("CM GAME");
        GameObject cvCamRueda = GameObject.Find("CM Rueda");


        GameObject thisDialogue = GameObject.Find("DialogoInicio");
        yield return new WaitForSeconds(2);
        DialogueManager.intance.dialogos = thisDialogue.GetComponent<Dialogos>().thisDialogue;

        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[0]);

        yield return new WaitUntil(() => DialogueManager.intance.index == 3);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.5f);

        cvCamInicio.SetActive(false);
        yield return new WaitForSeconds(.7f);
        DialogueManager.intance.index = 3;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[3]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 5);
        DialogueManager.intance.HideDialogo();

        cvCamInicio.SetActive(true);
        yield return new WaitForSeconds(1f);
        DialogueManager.intance.index = 6;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[6]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 7);
        DialogueManager.intance.HideDialogo();
        yield return new WaitForSeconds(.1f);


        cvCamInicio.SetActive(false);
        yield return new WaitForSeconds(1f);
        guiaVisual.SetActive(true);
        RaycastMovementDetection.instance.marcoContador.gameObject.SetActive(true);

        RaycastMovementDetection.instance.contador.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        yield return new WaitForSeconds(.5f);
        RaycastMovementDetection.instance.start = true;

        //yield return new WaitUntil(() => RaycastMovementDetection.instance.win == true);

        cvCamInicio.SetActive(true);
        yield return new WaitForSeconds(1.2f);

        DialogueManager.intance.index = 8;
        DialogueManager.intance.ShowDialogo(DialogueManager.intance.dialogos[8]);
        yield return new WaitUntil(() => DialogueManager.intance.index == 11);
        //cvCamCarretera.SetActive(false);
        DialogueManager.intance.HideDialogo();
        //PlayerPrefs.SetInt("CargarMenu 2", 1);
        PlayerPrefs.SetInt("CargarMenu 3", 1);
        ChangeScene.intance.CargarNivel(0);
    }
}
