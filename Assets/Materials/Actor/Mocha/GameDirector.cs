using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    public GameObject mocha;
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        this.mocha = GameObject.Find("mocha");
        this.message = GameObject.Find("message");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.mocha.GetComponent<mochaController>().hasRain)
        {
            this.message.GetComponent<Text>().text = "モチャ：雨に当たってます";
        }
        else
        {
            this.message.GetComponent<Text>().text = "モチャ：雨に当たってません";
        }
    }
}
