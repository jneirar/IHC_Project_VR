using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrainSingleton : MonoBehaviour
{
    #region Singleton
    static ScoreTrainSingleton instance;
    public static ScoreTrainSingleton Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        //DontDestroyOnLoad(this);
    }

    #endregion

    public GameObject scoreManager;
    private bool canScore = false;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreManager != null)
            canScore = true;
        
    }

    public void addToScore(int score)
    {
        if(canScore)
            scoreManager.GetComponent<ScoreManagerTrain>().AddScore(score);
    }
}
