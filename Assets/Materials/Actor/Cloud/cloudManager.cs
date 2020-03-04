using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour
{
    GameObject planet;

    //generator
    GameObject prefab_generator_object;
    PrefabGenerator prefab_generator;

    // Start is called before the first frame update
    void Start()
    {

        //generatorの初期化
        prefab_generator_object = GameObject.Find("PrefabGenerator");
        prefab_generator = prefab_generator_object.GetComponent<PrefabGenerator>();

        this.planet = GameObject.Find("en");

        const int DEGREE = 18;

        Vector3 axis = new Vector3(0, 0, 1);

        Vector3 test = new Vector3(0,0,0);

        for (int i = 0; i < 20; i++)
        {
            string cloud_num = "cloud" + i;

            float random_x = Random.Range(-1.0f, 2.0f);
            float random_y = Random.Range(-0.5f, 2.0f);

            this.transform.position = new Vector3(0, 12, 0);

            this.transform.Translate(random_x, random_y, 0);

            prefab_generator.CreatePrefab("kumoPrefab", this.transform.position, DEGREE * i, cloud_num);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
