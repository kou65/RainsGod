using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtillityMethod : MonoBehaviour
{

    // GameDirectorのメッセージ変数を返すメソッド
    public static bool GetMessage(Message message_)
    {

        if (message_ == Message.RESPOWN)
        {
            return GameDirector.spown_message;
        }
        else if (message_ == Message.SUISIDE)
        {
            return GameDirector.suicide_message;
        }

        return false;
    }

    // en を中心軸に移動させるメソッド
    public static void PlanetRotate(GameObject object_ ,float degree_)
    {
        GameObject planet = GameObject.Find("en");
        GameObject data = GameObject.Find("GameData");

        Vector3 axis = new Vector3(0, 0, 1);

        object_.transform.RotateAround(planet.transform.position, axis, degree_);
    }

}
