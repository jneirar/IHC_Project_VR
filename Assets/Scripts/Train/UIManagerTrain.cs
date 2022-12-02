using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerTrain : MonoBehaviour
{
    public GameObject buttonMainMenu;
    public AudioSource audioSource;

    void Start()
    {
        buttonMainMenu.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenuState);
        });
    }
}
