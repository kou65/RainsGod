using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    GameObject planet;

    GameObject mocha_obj;

    GameObject prefab_ganerator_obj;
    PrefabGenerator prefab_ganerator;

    Attribute curr_attrivute = Attribute.ETC;

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
            curr_attrivute = (Attribute)Random.Range(0, (int)Attribute.GRASS_SOLID);

            count++;
            string building_name = "building" + count ;

            this.transform.rotation = mocha_obj.transform.rotation;
            this.transform.position = mocha_obj.transform.position;

            switch (curr_attrivute)
            {
                case Attribute.GRASS:
                    prefab_ganerator.CreatePrefab("Prefab/Building/GrassBuildingPrefab", this.gameObject, building_name);
                    break;
                case Attribute.SOLID:
                    prefab_ganerator.CreatePrefab("Prefab/Building/SolidBuildingPrefab", this.gameObject, building_name);
                    break;
            }
        }

        if (GameDirector.suicide_message == true)
        {
            count = 0;
        }
    }
}
