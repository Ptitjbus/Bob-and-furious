using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : BaseController<TimerController>
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }


    void Start()
    {
        // on ajoute la fonction TogglePause à l'événement OnEscapePressed
        InputController.Instance().OnEscapePressed += TogglePause;
    }

    private void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            audioController.PlaySFX(audioController.reveil);
            timerText.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}