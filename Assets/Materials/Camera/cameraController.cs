using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject planet;
    public GameObject data;

    //public float speed;
    //Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("en");
        data = GameObject.Find("GameData");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.startPos = Input.mousePosition;
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    Vector2 endPos = Input.mousePosition;
        //    float swipeLength = endPos.x - this.startPos.x;
        //    this.speed = swipeLength / 500.0f;
        //}

        Vector3 axis = new Vector3(0, 0, 1);

        transform.RotateAround(planet.transform.position, axis, gameData.speed);
        //transform.RotateAround(planet.transform.position, axis, data.GetComponent<gameData>().speed);

        //this.speed *= gameData.DECLERATION;


    }
}
