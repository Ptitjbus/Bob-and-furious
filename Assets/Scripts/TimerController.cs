using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : BaseController<TimerController>
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    AudioController audioController;

    private void Awake() {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }


    void Start() {
        // on ajoute la fonction TogglePause à l'événement OnEscapePressed
        InputController.Instance().OnEscapePressed += TogglePause;
    }

    private void TogglePause() {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    // Update is called once per frame
    void Update() {
        // decrease the remaining time
        remainingTime -= Time.deltaTime;

        // update the timer color text
        if (remainingTime < 10 && remainingTime > 0) {
            timerText.color = Color.red;
        }
        // if the remaining time is less than 0, we stop the timer
        else if (remainingTime < 0) {
            remainingTime = 0;
            audioController.PlaySFX(audioController.reveil);

            // change the scene
            SceneManager.LoadSceneAsync(3);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}