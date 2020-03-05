using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant : PlantBase
{

    GameObject m_obj;

    private Fruit m_fruit;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクト名から取得
        m_obj = GameObject.Find("Fruit");

        // GoddessHandの中にあるGoddessHandを取得して変数に格納
        m_fruit = m_obj.GetComponent<Fruit>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーで果実が生成される
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 pos =
                transform.position;

            Instantiate(m_fruit, pos, Quaternion.identity);
        }
    }
}
