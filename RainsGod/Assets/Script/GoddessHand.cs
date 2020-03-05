using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoddessHand : MonoBehaviour
{

    public enum State
    {
        DOWN, // 降りる
        DROP, // 落とす
        WAIT, // 待機
        UP,   // 上がる
    };

    // 落ちてくる速さ
    const float DOWN_SPEED = 0.02f;

    // 上がる速度
    const float UP_SPEED = 0.02f;

    // 落とすしている時間
    const float DROP_TIME = 3.0f;

    // 落ちてくる間隔
    const float DOWN_TIME_INTERVAL = 0.0f;

    // 上がってくる時間の感覚
    const float UP_TIME_INTERVAL = 0.0f;

    // 下に止まる位置
    const float DOWN_STOP_POS = 2.0f;

    // 上に止まる位置
    const float UP_STOP_POS = 0.0f;

    // 間隔時間
    float m_interval_timer;

    // 状態
    State m_state;

    // 位置
    Vector3 m_pos;

    // 状態を返す関数
    public State GetState()
    {
        return m_state;
    }


    void DebugFunction()
    {

        Debug.Log(m_interval_timer);
    }

    // Start is called before the first frame update
    void Start()
    {

        m_pos = transform.position;

        m_interval_timer = 0.0f;
        m_state = State.DOWN;
    }

    void ChangeState()
    {

        // 落ちる位置まで来てないなら
        if (DOWN_STOP_POS >= m_pos.y
            && m_state == State.DOWN)
        {

            m_state = State.DROP;
        }
      
        // 落ちている時間の時上がる状態変化
        else if (m_state == State.DROP)
        {
            // 落としている時間
            if (Time.time >= DROP_TIME)
            {
                m_state = State.UP;
            }
        }

    }


    void StateFunction()
    {

        // 下に落ちている状態なら
        if (m_state == State.DOWN)
        {
            // 時間間隔で落とす
            if (DOWN_TIME_INTERVAL <= m_interval_timer)
            {
                m_interval_timer = 0.0f;
                m_pos.y -= DOWN_SPEED;
            }
        }
       
        // 上がっている状態
        if (m_state == State.UP)
        {
            // 時間間隔で上がる
            if(UP_TIME_INTERVAL <= m_interval_timer)
            {
                m_interval_timer = 0.0f;
                m_pos.y += UP_SPEED;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        DebugFunction();

        // 時間加算
        m_interval_timer += Time.deltaTime;

        // 状態変化
        ChangeState();

        // 状態処理
        StateFunction();

        // 最終位置を代入
        transform.position = m_pos;

    }
}
