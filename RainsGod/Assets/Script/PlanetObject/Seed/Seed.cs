using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{

    // 最大速度
    const float MAX_SPEED = 0.02f;

    // 最小速度
    const float MIN_SPEED = 0.005f;

    // 加速度
    const float ADD_SPEED = 0.01f;

    GameObject obj;
    GoddessHand m_god;

    Vector2 m_pos;

    void DebugFunction()
    {
        Debug.Log(Time.time);
    }

    private void Find()
    {

        // オブジェクト名から取得
        obj = GameObject.Find("GoddessHandS(Clone)");

        // GoddessHandの中にあるGoddessHandを取得して変数に格納
        m_god = obj.GetComponent<GoddessHand>();
    }

    float GetAddSpeed2()
    {
        float v = (MAX_SPEED - MIN_SPEED) / Time.time;
        return v;
    }

    float GetAddSpeed1(float add_speed)
    {
        // 加速度
        float v = MIN_SPEED + add_speed * Time.time;
        return v;
    }

    // 落ちる
    void Fall()
    {
        // 落ちている状態なら
        if(m_god.GetState() == GoddessHand.State.DROP)
        {
            transform.parent = null;
        }
        else
        {
            // 親が存在しているならば
            if (transform.parent != null)
            {
                m_pos = transform.parent.position;
            }
        }

        // 独立しているなら
        if(transform.parent == null)
        {
            m_pos.y -= GetAddSpeed1(ADD_SPEED);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        m_pos.x = m_pos.y = 0.0f;

        Find();
    }

    // Update is called once per frame
    void Update()
    {
        DebugFunction();

        Fall();

        transform.position = m_pos;
    }
}
