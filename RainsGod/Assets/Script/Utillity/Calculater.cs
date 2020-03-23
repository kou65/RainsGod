using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculater : MonoBehaviour
{
    public static float speed = 0.0f;

    Vector2 startPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject achoo_obj = GameObject.Find("Achoo!");

        if (!achoo_obj)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;
                speed = swipeLength / 500.0f;
            }
        }

        speed *= gameData.DECLERATION;
    }

}
