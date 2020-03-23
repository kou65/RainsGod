﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpDirector : MonoBehaviour
{

    public GameObject camera_controller;
    public GameObject planet;

    // Start is called before the first frame update
    void Start()
    {

        camera_controller = GameObject.Find("Main Camera");
        planet = GameObject.Find("en");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(0, 0, 1);

        transform.RotateAround(planet.transform.position, axis, gameData.speed);

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }

    }
}