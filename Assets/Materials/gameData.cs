using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Attribute
{
    GRASS,
    SOLID,
    GRASS_SOLID,
    // α以降
    DESERT,
    SEA,
    ETC
}

public enum Building
{
    HOUSE,
    STORE,
    NONE
}

public enum Status
{
    WET,
    FESTIVAL,
    WITHER,
    PEACE,
    NONE
}


public class gameData : MonoBehaviour
{
    public const float MAP_SPEED = 1.0f;
    public const float DECLERATION = 0.99f;

    public static float speed = 0.0f;
    Vector2 startPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            speed = swipeLength / 500.0f;
        }
        speed *= DECLERATION;

    }

}
