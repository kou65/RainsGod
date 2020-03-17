using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cameraController : MonoBehaviour
{
    public static cameraController singleton;

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

        if (DataBank.GetCurrScene() == Scene.TITLE)
        {
            PrefabGenerator.CreateCloud(gameObject, "title_logoPrefab", new Vector3(0,10,0), 0, "Title_Logo");

            PrefabGenerator.CreateCloud(gameObject, "player_dummyPrefab", new Vector3(0,14,0), 0, "player_dummy");

            PrefabGenerator.CreateCloud(gameObject, "himoPrefab", new Vector3(-7,18,0), 0, "himo");
        }


    }

    // Update is called once per frame
    void Update()
    {
        // タイトルシーンでの処理
        if (DataBank.GetCurrScene() == Scene.TITLE)
        {
            UtillityMethod.PlanetRotate(this.gameObject, -gameData.MAP_SPEED * Time.deltaTime);
        }
        // ゲームシーンでの処理
        else
        {
            UtillityMethod.PlanetRotate(this.gameObject, gameData.speed);

            if (UtillityMethod.GetMessage(Message.RESPOWN))
            {
                transform.position = new Vector3(0, 10, -10);
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            DestroyChild("Title_Logo");
            DestroyChild("player_dummy");
        }


    }

    void DestroyChild(string name_)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == name_)
            {
                Destroy(child.gameObject);
            }

        }
    }

}
