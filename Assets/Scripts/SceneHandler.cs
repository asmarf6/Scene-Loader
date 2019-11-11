using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public string sceneName;
    public GameObject sphere;
    private AsyncOperation sceneAsync;


    // Start is called before the first frame update
    void Start()
    {
        Scene sc = SceneManager.GetActiveScene();
        if(sc.name == "Scene1")
        {
            LoadNewScene();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void LoadNewScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        async.allowSceneActivation = false;
        sceneAsync = async;

        //Wait until we are done loading the scene
        while (async.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + async.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }
    void enableScene(int index)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            if (sphere != null && sphere.GetComponent<ClickHandler>().isClicked == true)
            {
                Debug.Log(sphere.GetComponent<ClickHandler>().checkClick().name);
                SceneManager.MoveGameObjectToScene(sphere.GetComponent<ClickHandler>().checkClick(), sceneToLoad);
                SceneManager.SetActiveScene(sceneToLoad);
            }
            
            
        }
    }

    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading Scene");
        enableScene(2);
        Debug.Log("Scene Activated!");
    }
}
