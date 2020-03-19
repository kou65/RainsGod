using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PrefabGenerator.CreatePrefab("Prefab/Player/playerPrefab", this.gameObject, "player");
    }

}
