using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcManager : MonoBehaviour
{
    public static ArcManager singleton;

    public GameObject[] arc_base = new GameObject[gameData.MAX_ARC];

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

        if (!arc_base[0])
        {
            Spown();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (UtillityMethod.GetMessage(Message.RESPOWN))
        {
            Spown();
        }
        else if(UtillityMethod.GetMessage(Message.SUISIDE))
        {
            Destroy();
        }
    }

    // 現在は草と土の生成のみ
    void Spown()
    {
        int[] random_arc = new int[gameData.MAX_ARC + 1];

        for (int i = 0; i < gameData.MAX_ARC + 1; i++)
        {
            random_arc[i] = Random.Range(0, (int)Attribute.GRASS_SOLID);
            random_arc[4] = random_arc[0];
        }

        for (int i = 0; i < gameData.MAX_ARC; i++)
        {
            float rotation =  90.0f * i;

            string arc_name = "base_arc" + (i + 1);

            if (random_arc[i] == (int)Attribute.GRASS)
            {
                if (random_arc[i + 1] == (int)Attribute.GRASS)
                {
                    PrefabGenerator.CreateCloud(this.gameObject, "grass2Prefab", this.transform.position, rotation, arc_name);
                }
                else
                {
                    PrefabGenerator.CreateCloud(this.gameObject, "grassPrefab", this.transform.position, rotation, arc_name);
                }

            }
            else if (random_arc[i] == (int)Attribute.SOLID)
            {
                if (random_arc[i + 1] == (int)Attribute.SOLID)
                {
                    PrefabGenerator.CreateCloud(this.gameObject, "solid2Prefab", this.transform.position, rotation, arc_name);
                }
                else
                {
                    PrefabGenerator.CreateCloud(this.gameObject, "solidPrefab", this.transform.position, rotation, arc_name);
                }
            }
            else if (random_arc[i] == (int)Attribute.GRASS_SOLID)
            {
                PrefabGenerator.CreateCloud(this.gameObject, "grass_solidPrefab", this.transform.position, rotation, arc_name);
            }
            else if (random_arc[i] == (int)Attribute.SOLID_GRASS)
            {
                PrefabGenerator.CreateCloud(this.gameObject, "solid_grassPrefab", this.transform.position, rotation, arc_name);
            }
        }

        arc_base[0] = GameObject.Find("base_arc1");
        arc_base[1] = GameObject.Find("base_arc2");
        arc_base[2] = GameObject.Find("base_arc3");
        arc_base[3] = GameObject.Find("base_arc4");

        arc_base[0].GetComponent<SpriteRenderer>().sortingOrder = 1;
        arc_base[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
        arc_base[2].GetComponent<SpriteRenderer>().sortingOrder = 3;
        arc_base[3].GetComponent<SpriteRenderer>().sortingOrder = 4;


        //DataBank.bank_arc = arc_base;
    }
    public void Destroy()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);

        }
    }

}
