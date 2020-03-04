using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    public GameObject mocha_obj;
    public mochaController mocha;

    public GameObject message;
    public GameObject message2;
    // Start is called before the first frame update
    void Start()
    {
        this.mocha_obj = GameObject.Find("mocha");
        mocha = mocha_obj.GetComponent<mochaController>();

        this.message = GameObject.Find("message");
        this.message2 = GameObject.Find("message2");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.mocha.hasRain)
        {
            this.message.GetComponent<Text>().text = "モチャ1：雨に当たってます";
        }
        else
        {
            this.message.GetComponent<Text>().text = "モチャ1：雨に当たってません";
        }

        if (this.mocha.attribute_state == Attribute.GRASS)
        {
            this.message2.GetComponent<Text>().text = "モチャ2：草原にいます";
        }
        else if (this.mocha.attribute_state == Attribute.SOLID)
        {
            this.message2.GetComponent<Text>().text = "モチャ2：土にいます";

        }
    }
}
