using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerCampaign : MonoBehaviour
{
    public GameObject buttonMainMenu;
    private bool level1completed = false;
    private bool level2completed = false;
    public GameObject[] portals;
    public AudioSource audioSource;

    void Start()
    {
        level1completed = GameManager.Instance.getLevel1Completed();
        level2completed = GameManager.Instance.getLevel2Completed();

        buttonMainMenu.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenuState);
        });

        if (level1completed)
        {
            //Get first child of portal
            portals[0].transform.GetChild(1).gameObject.SetActive(false);
            portals[0].transform.GetChild(2).gameObject.SetActive(true);
        }
        if (level2completed)
        {
            //Get first child of portal
            portals[1].transform.GetChild(1).gameObject.SetActive(false);
            portals[1].transform.GetChild(2).gameObject.SetActive(true);
        }
    }



}
