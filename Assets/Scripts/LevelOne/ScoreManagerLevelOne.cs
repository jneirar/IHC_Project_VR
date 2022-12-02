using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerLevelOne : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas_count;
    public GameObject audience;
    public GameObject canvasResult;
    private int goalScore = 100;
    private int goalTime = 1;
    private int score = 0;
    private float time = 0;
    private bool finished = false;
    private UnityEngine.UI.Text goalText;
    private UnityEngine.UI.Text scoreText;
    private UnityEngine.UI.Text timeText;
    private UnityEngine.UI.Button buttonReturn;

    private UnityEngine.UI.Text goalTextCount;
    private UnityEngine.UI.Text counterTextCount;

    private UnityEngine.UI.Text lblResult;
    private UnityEngine.UI.Text lblMessage;
    private UnityEngine.UI.Button btnNext;

    public AudioSource audioSourceWin;
    public AudioSource audioSourceLose;
    public AudioSource audioSourceButton;

    void Start()
    {
        finished = GameManager.Instance.getLevel1Completed();
        buttonReturn = canvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Button>();
        goalText = canvas.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>();
        scoreText = canvas.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>();
        timeText = canvas.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.GetComponent<UnityEngine.UI.Text>();

        goalTextCount = canvas_count.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        counterTextCount = canvas_count.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>();

        lblResult = canvasResult.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        lblMessage = canvasResult.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>();
        btnNext = canvasResult.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Button>();

        string textGoal = "Objetivo: Consigue " + goalScore.ToString() + " puntos en menos de " + goalTime.ToString() + " minuto";
        if(goalTime > 1)
            textGoal += "s";
        goalTextCount.text = textGoal;
        goalText.text = textGoal;

        canvasResult.SetActive(false);
        if(!finished)
        {
            audience.SetActive(false);
            canvas.SetActive(false);
            StartCoroutine(Countdown(5));
        }
        else
        {
            // Never will happen
        }
        
    }


    void Update() 
    {
        if(!finished)
        {
            scoreText.text = "Puntaje: " + score + " puntos";
            time += Time.deltaTime;
            timeText.text = "Tiempo: " + Mathf.Floor(time / 60) + " m " + Mathf.Floor(time % 60) + " s";

            if(score >= goalScore)
            {
                GameManager.Instance.setLevel1Completed(true);
                finished = true;
                // Mostrar pantalla de victoria
                canvasResult.SetActive(true);
                lblResult.text = "¡Ganaste!";
                lblResult.color = Color.green;
                lblMessage.text = "Pasaste al siguiente nivel";
                btnNext.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
                    audioSourceButton.Play();
                    GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState);
                });
                //btnNext.onClick.AddListener(() => GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState));
                
                audioSourceWin.Play();
            }

            if(time >= goalTime * 60)
            {
                finished = true;
                // Mostrar pantalla de derrota
                canvasResult.SetActive(true);
                // Get lblResult from panel from canvasResult
                lblResult.text = "¡Lo sentimos!";
                lblResult.color = Color.red;
                lblMessage.text = "Intentalo de nuevo";
                btnNext.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
                    audioSourceButton.Play();
                    GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState);
                });
                //btnNext.onClick.AddListener(() => GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState));

                audioSourceLose.Play();
            }
        }
        else
        {
            audience.SetActive(false);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            counterTextCount.text = counter.ToString();
            yield return new WaitForSeconds(1);
            counter--;
        }
        counterTextCount.fontSize = 30;
        counterTextCount.text = "¡Vamos!";
        yield return new WaitForSeconds(1);
        time = 0;
        canvas_count.SetActive(false);
        audience.SetActive(true);
        canvas.SetActive(true);
    }
}
