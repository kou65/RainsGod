using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Message
{
    SUISIDE,
    RESPOWN
}
public class GameDirector : MonoBehaviour
{

    public GameObject mocha_obj;
    public mochaController mocha;

    public GameObject message;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;
    public GameObject message5;

    public static bool suicide_message = false;
    public static bool spown_message = false;

    public static bool destroy_event = false;
    public static bool spown_event = false;

    static float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.mocha_obj = GameObject.Find("mocha");
        mocha = mocha_obj.GetComponent<mochaController>();

        this.message = GameObject.Find("message");
        this.message2 = GameObject.Find("message2");
        this.message3 = GameObject.Find("message3");
        this.message4 = GameObject.Find("message4");
        this.message5 = GameObject.Find("message5");
    }

    // Update is called once per frame
    void Update()
    {
 
        spown_message = false;
        suicide_message = false;

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
        this.message3.GetComponent<Text>().text = "SPACE：建築";
        this.message4.GetComponent<Text>().text = "ヒモチャ：全削除";
        this.message5.GetComponent<Text>().text = "ENTER：生成";

        if (destroy_event)
        {
            suicide_message = true;
            destroy_event = false;
        }
        if (spown_event)
        {
            spown_message = true;
            spown_event = false;
        }
    }

    public static void OnMessage(Message msg_)
    {
        switch (msg_)
        {
            case Message.RESPOWN:
                spown_message = true;
                break;
            case Message.SUISIDE:
                suicide_message = true;
                break;
        }
    }
}
