using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public int numOfBars;
    public RectTransform origin;
    public GameObject bar;
    public GameObject[] barsCount;
    public AudioSource uwu;
    bool xd;
    // Start is called before the first frame update
    void Start()
    {
        float posX = origin.position.x;

        for (int i = 0; i < numOfBars; i++)
        {
            Instantiate(bar, new Vector3(posX, origin.position.y, origin.position.z), Quaternion.identity, origin.transform);
            posX += .3f;
        }

        barsCount = GameObject.FindGameObjectsWithTag("Bar");

        
    }

    // Update is called once per frame 0.0099831
    void Update()
    {
       

        float[] spectrum = new float[1024];
        uwu.GetOutputData(spectrum, 0);

        //AudioListener.GetOutputData(spectrum, 0);

        for (int i = 0; i < numOfBars; i++)
        {
            Vector3 prevScale = barsCount[i].transform.localScale;

            prevScale.y = spectrum[i] * 50;

            barsCount[i].transform.localScale = prevScale;
        }
        
    }
}
