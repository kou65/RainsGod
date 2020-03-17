using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    GameObject planet;

    GameObject mocha_obj;

    GameObject prefab_ganerator_obj;
    PrefabGenerator prefab_ganerator;



    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("en");
        mocha_obj = GameObject.Find("mocha");

        prefab_ganerator_obj = GameObject.Find("PrefabGenerator");
        prefab_ganerator = prefab_ganerator_obj.GetComponent<PrefabGenerator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            string building_name = "building" + count ;

            this.transform.rotation = mocha_obj.transform.rotation;
            this.transform.position = mocha_obj.transform.position;

            prefab_ganerator.CreatePrefab("Prefab/Building/buildingPrefab", this.gameObject, building_name);
        }

        if (GameDirector.suicide_message == true)
        {
            count = 0;
        }
    }
}
