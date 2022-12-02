using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    #region Singleton
    static SwitchScene instance;
    public static SwitchScene Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
    #endregion

    private GameObject loadingBarCanvas;
    private Image loadingBar;

    public void loadScene(string pathScene)
    {
        // Find LoadingBarCanvas even if it is not active
        loadingBarCanvas = FindInActiveObjectByName("LoadingBarCanvas");
        loadingBar = loadingBarCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        loadingBarCanvas.transform.SetParent(GameObject.Find("OVRPlayerController").transform);
        loadingBarCanvas.transform.localPosition = new Vector3(-0.01f, 1.72f, 5.61f);
        loadingBarCanvas.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        loadingBarCanvas.SetActive(true);
        StartCoroutine("loadSceneCoroutine", pathScene);
    }

    IEnumerator loadSceneCoroutine(string pathScene)
    {
        Debug.Log("Loading scene: (" + pathScene + ")...");
        int indexScene = SceneUtility.GetBuildIndexByScenePath(pathScene);
        Debug.Log("Index scene: (" + indexScene + ")...");
        AsyncOperation loadSceneProgress = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Single);

        while (!loadSceneProgress.isDone)
        {
            loadingBar.fillAmount = loadSceneProgress.progress;
            yield return null;
        }
        loadingBarCanvas = FindInActiveObjectByName("LoadingBarCanvas");
        loadingBar = loadingBarCanvas.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        loadingBarCanvas.SetActive(false);
    }

    /* Quit Application */
    public void quitApp()
    {
        Application.Quit();
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
}

}
