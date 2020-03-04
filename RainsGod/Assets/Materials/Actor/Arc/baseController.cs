using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseController : MonoBehaviour
{
    public float speed;
    Vector2 startPos;

    public GameObject[] base_pirce = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            this.speed = swipeLength / 500.0f;
        }
        this.base_pirce[0].transform.Rotate(0, 0, this.speed);
        this.base_pirce[1].transform.Rotate(0, 0, this.speed);
        this.base_pirce[2].transform.Rotate(0, 0, this.speed);
        this.base_pirce[3].transform.Rotate(0, 0, this.speed);

        this.speed *= gameData.DECLERATION;

    }
}
