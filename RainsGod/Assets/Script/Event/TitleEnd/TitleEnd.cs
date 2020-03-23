using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PrefabGenerator.CreateChild(this.gameObject, "Prefab/Event/TitleEnd/himo_dummyPrefab", "himo");
        PrefabGenerator.CreateChild(this.gameObject, "Prefab/Event/TitleEnd/player_dummyPrefab", "player_dummy");
        PrefabGenerator.CreateChild(this.gameObject, "Prefab/Event/TitleEnd/title_logoPrefab", "TitleLogo");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
