using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InitEvent
{
    static bool during_event = false;
    static bool complete_destroy = false;

    static float count = 0.0f;

    public static bool InitPlanet()
    {
        if (!HasInitEvent())
        {
            DestroyPlanet();
        }
        else if (HasInitEvent())
        {
            count += Time.deltaTime;

            if (count >= gameData.INIT_EVENT_TIME)
            {
                RespownPlanet();
                count = 0;
                return true;
            }

        }
        return false;

    }

    public static void DestroyPlanet()
    {
        during_event = true;
       
        GameDirector.destroy_event = true;
    }

    public static void RespownPlanet()
    {
        during_event = false;

        GameDirector.spown_event = true;
    }

    public static bool HasInitEvent()
    {
        return during_event;
    }
}

