using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(0,8,0);

        for (int i = 0; i < gameData.MAX_OBJECT; i++)
        {
            PrefabGenerator.CreatePrefabTest("objPrefab", this.gameObject, "iwa");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



}
