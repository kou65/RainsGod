using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDirector : MonoBehaviour
{
    public static GlobalEvent curr_global_event = GlobalEvent.ETC;

    public static bool can_achoo_event = false;

    public static bool can_planet_init_event = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            PlanetInitUpdate();

            AchooUpdate();

    }

    public static void StartAchooEvent(GameObject obj_)
    {
        PrefabGenerator.CreateChild(obj_, "Prefab/Event/Achoo/AchooEventPrefab", "Achoo!");
        curr_global_event = GlobalEvent.ACHOO;
        can_achoo_event = false;
    }

    void AchooUpdate()
    {
    if (curr_global_event == GlobalEvent.ETC)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                can_achoo_event = true;
            }
        }
    }

    public static void StartPlanetInitEvent()
    {
        if (curr_global_event == GlobalEvent.ETC)
        {
            curr_global_event = GlobalEvent.PLANET_INIT;
        }
    }

    void PlanetInitUpdate()
    {
        if (curr_global_event == GlobalEvent.PLANET_INIT)
        {
            if (InitEvent.InitPlanet())
            {
                curr_global_event = GlobalEvent.ETC;
            }
        }


    }
}
