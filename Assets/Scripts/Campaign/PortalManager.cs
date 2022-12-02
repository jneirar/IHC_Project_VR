using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public int level = 1;
    public AudioSource audioSource;
    private bool level1completed = false;
    private bool level2completed = false;

    void Start()
    {
        level1completed = GameManager.Instance.getLevel1Completed();
        level2completed = GameManager.Instance.getLevel2Completed();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            switch(level)
            {
                case 1:
                    if(!level1completed)
                        GameManager.Instance.UpdateGameState(GameManager.GameState.LevelOneState);
                    break;
                case 2:
                    if(level1completed && !level2completed)
                        GameManager.Instance.UpdateGameState(GameManager.GameState.LevelTwoState);
                    break;
                default:
                    break;
            }
        }
    }
}
