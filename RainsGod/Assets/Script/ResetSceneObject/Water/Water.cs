using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    // 11.fから
    const float INIT_Y_POS = 16.0f;

    // 13.fおろす
    const float END_POS_DISTANCE = 13.0f;

    // おろす速度
    const float DOWN_SPEED = 0.1f;


    private bool is_end;


    Vector3 m_pos;

    public bool IsEndWater()
    {
        return is_end;
    }

    // Start is called before the first frame update
    void Start()
    {
        is_end = false;

        m_pos = new Vector3(0.0f, INIT_Y_POS, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        // 自機からEND_POSまでの距離になったら終了
        if(transform.position.y <=  - END_POS_DISTANCE)
        {
            is_end = true;
            // 自分を削除
            Destroy(this.gameObject);
        }
        else
        {
            // おろす
            m_pos.y -= DOWN_SPEED;
            transform.position = m_pos;
        }
        
    }
}
