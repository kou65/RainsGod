using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject prefab_ganerator_obj;
    public PrefabGenerator prefab_ganerator;

    // Start is called before the first frame update
    void Start()
    {
        prefab_ganerator_obj = GameObject.Find("PrefabGenerator");
        prefab_ganerator = prefab_ganerator_obj.GetComponent<PrefabGenerator>();
        prefab_ganerator.CreatePrefab("playerPrefab", this.transform.position, "player1");

    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
