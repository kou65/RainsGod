using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    public GameObject camera_controller;

    // Start is called before the first frame update
    void Start()
    {
        camera_controller = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position =
    new Vector3(
        camera_controller.transform.position.x,
        camera_controller.transform.position.y,
        0
    );

        this.transform.rotation = camera_controller.transform.rotation;
    }
}
