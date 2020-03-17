using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBank : MonoBehaviour
{

    static Scene curr_scene;

    public static DataBank singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (!singleton)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            curr_scene = Scene.TITLE;
        }
        else
        {
            curr_scene = Scene.GAME;
        }

    }

    public static Scene GetCurrScene()
    {
        return curr_scene;
    }

}
