using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResetSceneManager : MonoBehaviour
{
    public enum State
    {
        WATER_FALL_SCENE,
        GODDESS_HAND_SCENE,
    }


    GameObject obj;

    public GoddessHand m_goddess_hand;

    public WaterFall m_water_fall;
    private WaterFall get_water_fall;

    State m_state;

    // Start is called before the first frame update
    void Start()
    {

        m_state = State.WATER_FALL_SCENE;

        // 滝生成(参照受け取り)
        get_water_fall = Instantiate(m_water_fall, m_water_fall.transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (get_water_fall.IsEnd() == true && m_state == State.WATER_FALL_SCENE)
        {
            // 女神の手生成
            Instantiate(m_goddess_hand,new Vector3(0.0f,5.0f,0.0f), Quaternion.identity);

            m_state = State.GODDESS_HAND_SCENE;
        }
    }


}
