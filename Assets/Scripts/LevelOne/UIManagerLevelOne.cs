using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerLevelOne : MonoBehaviour
{
    public GameObject buttonReturn;
    public AudioSource audioSource;

    void Start()
    {
        buttonReturn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
            audioSource.Play();
            GameManager.Instance.UpdateGameState(GameManager.GameState.CampaignState);
        });
    }
}
