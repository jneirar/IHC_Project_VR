using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMainMenu : MonoBehaviour
{
    public GameObject buttonNewCampaign;
    public GameObject buttonContinue;
    public GameObject buttonTrain;
    public GameObject buttonQuit;
    public GameObject buttonHelp;
    private bool level1completed = false;
    public AudioSource audioSource;
    public GameObject canvasHelp;

    void Start()
    {
        buttonNewCampaign.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            listenerNewCampaign();
        });

        buttonContinue.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState);
        });

        buttonTrain.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            GameManager.Instance.UpdateGameState(GameManager.GameState.TrainState);
        });

        buttonQuit.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            Application.Quit();
        });

        level1completed = GameManager.Instance.getLevel1Completed();

        if (level1completed)
            buttonContinue.GetComponent<UnityEngine.UI.Button>().interactable = true;
        else
            buttonContinue.GetComponent<UnityEngine.UI.Button>().interactable = false;
        
        buttonHelp.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            //Application.OpenURL("https://docs.google.com/document/d/1OF8BWNarcY1D1j3AGBU1oX_iX_2UB0Acx714vTkxrbA/edit?usp=share_link");
            if(canvasHelp.activeSelf)
                canvasHelp.SetActive(false);
            else
                canvasHelp.SetActive(true);
        });
    }


    void listenerNewCampaign()
    {
        GameManager.Instance.setLevel1Completed(false);
        GameManager.Instance.setLevel2Completed(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState);
    }
}
