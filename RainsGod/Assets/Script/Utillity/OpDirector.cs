using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpDirector : MonoBehaviour
{

    public static bool can_title_end = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            can_title_end = true;
        }
        if (can_title_end)
        {

            // 処理の終わりにシーンエンド
        }
    }

    public static void StartTitleEnd(GameObject obj_)
    {
        PrefabGenerator.CreateChild(obj_, "Prefab/Event/TitleEndPrefab", "TitleEnd");
    } 
}
