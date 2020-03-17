using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GroundElement
{
    NONE,
    GROSS,
    SOIL,
}

public enum SlotElement
{
    NONE,
    ARCH,
    PLANT,
    FOOD,
    TOTAL,
}


// 惑星スロット
public struct Slot
{
    // 地面の属性
    public GroundElement ground_element;

    // スロットの属性
    public SlotElement slot_element;

    // うるおい度
    public float moisture;

    // 惑星オブジェクト(戻り値)
    public GameObject p_obj;
}


public class SlotManager : MonoBehaviour
{

    // 動的にランダムに生成
    // 外部から参照する方法

    // オブジェクト最大数
    const int MAX_OBJECT_SLOT_NUM = 20;

    const int OBJECT_NUM = 3;

    // プレハブオブジェクト
    public GameObject m_plant_obj;
    public GameObject m_arch_obj;
    public GameObject m_food_obj;

    // ランダム数値
    public int m_arch_rand_max;
    public int m_arch_rand_min;

    public int m_plant_rand_max;
    public int m_plant_rand_min;

    public int m_food_rand_max;
    public int m_food_rand_min;

    // それぞれのオブジェクト数を格納する配列
    int[] m_obj_num_list;

    // 惑星オブジェクト配列
    Slot[] m_planet_slot_list;

    // 各オブジェクト配列
    List <Slot> m_plant_slot_list;
    List <Slot> m_arch_slot_list;
    List <Slot> m_food_slot_list;

    // モチャリストからも茶の名前を取ってくる


    void Init()
    {

        // 可変長配列生成
        m_plant_slot_list = new List<Slot>();
        m_arch_slot_list = new List<Slot>();
        m_food_slot_list = new List<Slot>();

        m_obj_num_list = new int[(int)SlotElement.TOTAL];

        // オブジェクト分の配列を用意
        m_planet_slot_list = new Slot[MAX_OBJECT_SLOT_NUM];
    }


    // 最大スロット数を返す
    public int GetSelectMaxSlotNum(SlotElement slot_elem)
    {
        // 選んだスロットから最大数を取り出す
        return m_obj_num_list[(int)slot_elem];
    }

    // 選択したスロットを返す
    // 参照用
    public Slot GetSelectSlot(SlotElement slot_elem, int slot_num)
    {
        // 選んだスロットから最大数を取り出す
        int total_obj_num = m_obj_num_list[(int)slot_elem];

        Slot slot;
        slot.p_obj = null;
        slot.ground_element = GroundElement.NONE;
        slot.slot_element = SlotElement.NONE;
        slot.moisture = 0.0f;

        // 適合したスロットを返す
        switch (slot_elem) {

            case SlotElement.ARCH:
       slot = m_arch_slot_list[slot_num % total_obj_num];
                break;

            case SlotElement.PLANT:
                slot = m_plant_slot_list[slot_num % total_obj_num];
                break;

            case SlotElement.FOOD:
                slot = m_food_slot_list[slot_num % total_obj_num];
                break;
        }
        return slot;
    }

    void InitSlot()
    {

        Slot slot;
        slot.p_obj = null;
        slot.ground_element = GroundElement.NONE;
        slot.slot_element = SlotElement.NONE;
        slot.moisture = 0.0f;

        for (int i = 0; i < MAX_OBJECT_SLOT_NUM; i++)
        {

            m_planet_slot_list[i] = slot;
        }
    }

    void ResetSlot()
    {
        Init();

        RandomNumCreate();

        RandomInsert();

        CreateObject();
    }

    // ランダムで生成数を返す
    // 参照渡ししたい
    void InsertTotalRatioRandom(int arch_rand,int plant_rand,int food_rand)
    {
        int none = 0;

        int[] rand_array = { none,arch_rand, plant_rand, food_rand };
        float[] ratio_array = {0.0f,0.0f,0.0f};
       
        // 全体
        int total = 0;

        // 全体数割り出し
        for(int i = 0; i < (int)SlotElement.TOTAL; i++)
        {
            total += rand_array[i];
        }

        // 全体比率を出す
        for (int i = 0; i < (int)SlotElement.TOTAL; i++)
        {
            ratio_array[i] = rand_array[i] / total;
        }

        // 総固定スロット数から全体比率分の乱数を設定

        // 建築
        m_obj_num_list[0] = (int)(ratio_array[0] * MAX_OBJECT_SLOT_NUM);

        // 植物
        m_obj_num_list[1] = (int)(ratio_array[1] * MAX_OBJECT_SLOT_NUM);

        // 食べ物
        m_obj_num_list[2] = (int)(ratio_array[2] * MAX_OBJECT_SLOT_NUM);
    }


    void RandomNumCreate()
    {
        int none = 0;

        int arch_rand = 
            Random.Range(m_arch_rand_min, m_arch_rand_max);

        int plant_rand = 
           Random.Range(m_plant_rand_min, m_plant_rand_max);

        int food_rand = 
           Random.Range(m_food_rand_min, m_food_rand_max);

        int[] rand_array = { none,arch_rand, plant_rand, food_rand };

        // 全体
        int total = 0;

        // 全体数割り出し(NONEは入れない)
        for (int i = (int)SlotElement.NONE; i < (int)SlotElement.TOTAL; i++)
        {
            total += rand_array[i];
        }

        // 最大数が超えてたら最大まで戻す、最小はok

        // 建築から、noneは入れない
        int obj_count = (int)SlotElement.ARCH;

        // 合計より下なら平均的に減算
        while (total > MAX_OBJECT_SLOT_NUM)
        {

            // オブジェクト数加算
            rand_array[(obj_count % ((int)SlotElement.TOTAL - 1))]--;

            // －まで来たら0に戻す
            if(rand_array[(obj_count % ((int)SlotElement.TOTAL - 1))] < 0)
            {
                rand_array[(obj_count % ((int)SlotElement.TOTAL - 1))] = 0;
            }

            // 再計算
            // 全体数割り出し
            total = 0;
            for (int i = 0; i < OBJECT_NUM; i++)
            {
                total += rand_array[i];
            }

            // 最終まで来たら
            if(obj_count == ((int)SlotElement.TOTAL - 1))
            {
                obj_count = (int)SlotElement.ARCH;
            }

            obj_count++;
        }

        // 本体に代入
        for(int i = 0; i < (int)SlotElement.TOTAL; i++)
        {
            m_obj_num_list[i] = rand_array[i];
        }
    }


    void RandomInsert()
    {
        GameObject none_obj = m_arch_obj;
        GameObject[] object_list = {none_obj, m_arch_obj, m_plant_obj, m_food_obj };
        SlotElement[] slot_element_list = { SlotElement.NONE,SlotElement.ARCH, SlotElement.PLANT, SlotElement.FOOD };

        // どれぐらい代入したか比べる変数
        int obj_count = 0;

        for (int j = 0; j < (int)SlotElement.TOTAL; j++)
        {
            // 建築スロット
            for (int i = 0; i < m_obj_num_list[j]; i++)
            {

                // 最大数を超えていたら終了
                if (obj_count >= MAX_OBJECT_SLOT_NUM)
                {
                    break;
                }

                // 20あまり算
                int rand_num = (Random.Range(0, MAX_OBJECT_SLOT_NUM)) % MAX_OBJECT_SLOT_NUM;

                // 制限
                if (m_planet_slot_list[rand_num].p_obj != null)
                {
                    i--;
                    continue;
                }

                // 植物オブジェクト代入
                m_planet_slot_list[rand_num].p_obj = object_list[j];
                m_planet_slot_list[rand_num].slot_element = slot_element_list[j];

                obj_count++;

            }
        }
    }


    void CreateObject()
    {
        // オブジェクト取得
        GameObject get_obj;

        // 最大スロット数分
        for (int i = 0; i < MAX_OBJECT_SLOT_NUM; i++)
        {

            Vector3 pos = new Vector3(32 * i, 0, 0);
            Vector3 axis = new Vector3(32 * i, 0, 0);
            float angle = Time.deltaTime;

            transform.RotateAround(pos, axis, angle);

            // 入っていないならもう一度
            if (m_planet_slot_list[i].p_obj == null)
            {
                continue;
            }

            // 生成
            get_obj = Instantiate(m_planet_slot_list[i].p_obj,
                transform.position, Quaternion.identity);

            // 全体配列に代入
            m_planet_slot_list[i].p_obj = get_obj;

            // それぞれの配列に代入
            switch (m_planet_slot_list[i].slot_element) {

                case SlotElement.ARCH:
                    m_arch_slot_list.Add(m_planet_slot_list[i]);
                    break;

                case SlotElement.PLANT:
                    m_plant_slot_list.Add(m_planet_slot_list[i]);
                    break;

                case SlotElement.FOOD:
                    m_food_slot_list.Add(m_planet_slot_list[i]);
                    break;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
