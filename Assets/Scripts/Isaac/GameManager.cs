using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameRunning;
    public bool canPause = true;
    public GameObject pasuePanel;

    public AudioSource bgm;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            ChangedGameRunningState();
        }
    }

    
    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void ChangedGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {

            Time.timeScale = 1f;

        }
        else
        {

            Time.timeScale = 0f;
        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }



}