using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    [SerializeField] int initialScene;
    // Start is called before the first frame update
    void Start()
    {
        LoadScene(initialScene);
    }

    public static void LoadScene(int sceneID){
        SceneManager.LoadScene(sceneID, LoadSceneMode.Additive);
    }

    public static void UnloadScene(int sceneID) 
    {
        SceneManager.UnloadSceneAsync(sceneID);
    }
}
