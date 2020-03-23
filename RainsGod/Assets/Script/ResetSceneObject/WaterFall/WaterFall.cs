using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterFall : MonoBehaviour
{

    public bool m_is_end;

    public Water prefab;
    private Water m_water;

    public bool IsEnd()
    {
        return m_is_end;
    }

    // Start is called before the first frame update
    void Start()
    {

        // プレハブ受け取り
        //prefab = (Water)Resources.Load("Prefab/Water");

        // 一つだけ生成
       m_water = Instantiate(prefab, new Vector3(0.0f,20.0f,0.0f),Quaternion.identity);

        m_is_end = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 終了
        if (m_water.IsEndWater() == true)
        {
            m_is_end = true;
        }
    }
}
