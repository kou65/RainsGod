using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MochaParameter
{
    [SerializeField, Range(0, 100)]
    public int m_Stamina;

    [SerializeField, Range(0, 100)]
    public int m_Fertility;

    public MochaState m_State;

    [SerializeField, Range(5, 10)]
    public int m_Sight;
}

public class MochaControl : MonoBehaviour
{
    public MochaParameter mocha_parameter;
    private MochaState MochaOldState;

    private bool IsMove = false;

    private float Delta = 0;
    private int BreakCounter = 0;

    GameObject my_object; // 自分自身の情報を入れる為の変数

    GameObject mocha_manager_object;
    MochasManager mocha_manager;

    GameObject prefab_generator_object;
    PrefabGenerator prefab_generator;

    // Start is called before the first frame update
    void Start()
    {
        //this.mocha_parameter.m_State = MochaState.BREAK;
        this.MochaOldState = this.mocha_parameter.m_State;

        mocha_manager_object = GameObject.Find("MochasManager");
        mocha_manager = mocha_manager_object.GetComponent<MochasManager>();

        prefab_generator_object = GameObject.Find("PrefabGenerator");
        prefab_generator = prefab_generator_object.GetComponent<PrefabGenerator>();

        // 自分自身の情報で初期化
        this.my_object = GameObject.Find(this.transform.name);

        // このモチャに個別の名前を付ける
        this.my_object.transform.name = mocha_manager.GenerateNamingMocha();

        // このモチャをMochasManagerのMochaListの一番最後に追加する
        mocha_manager.AddMochaList(this.my_object);
    }

    // Update is called once per frame
    void Update()
    {
        StartState();

        switch (this.mocha_parameter.m_State)
        {
            case MochaState.BREAK:
                Break();
                break;
            case MochaState.BREED:
                Breed();
                break;
            case MochaState.CONSTRUCT:
                Construct();
                break;
            case MochaState.REORGANIZE:
                Reorganize();
                break;
            case MochaState.EMIGRATE:
                Emigrate();
                break;
            case MochaState.MEAL:
                Meal();
                break;
        }
    }

    public void StartState()
    {
        if (this.MochaOldState != this.mocha_parameter.m_State)
        {
            this.MochaOldState = this.mocha_parameter.m_State;

            switch (this.mocha_parameter.m_State)
            {
                case MochaState.BREAK:

                    break;
                case MochaState.BREED:

                    break;
                case MochaState.CONSTRUCT:
                    this.IsMove = true;
                    break;
                case MochaState.REORGANIZE:
                    this.IsMove = true;
                    break;
                case MochaState.EMIGRATE:

                    break;
                case MochaState.MEAL:
                    this.IsMove = true;
                    break;
            }
        }
    }

    // 各ステートの挙動で毎フレーム一秒経つごとにtrue
    private bool OneSecond()
    {
        this.Delta += Time.deltaTime;
        if (Delta > 1.0f)
        {
            this.Delta = 0.0f;
            return true;
        }

        return false;
    }

    // 休憩の挙動
    private void Break()
    {
        if(OneSecond())
        {
            BreakCounter++;
            if(BreakCounter >= 30)
            {
                BreakCounter = 0;
                this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);

            }
        }
    }

    // 繁殖の挙動
    private void Breed()
    {
        if (OneSecond())
        {
            BreakCounter++;
            if (BreakCounter >= 10)
            {
                BreakCounter = 0;
                this.mocha_parameter.m_State = MochaState.EMIGRATE;


                prefab_generator.CreatePrefab("Prefab/MochaPrefab", this.transform.position, this.transform.eulerAngles);
            }
        }
    }

    // 建築の挙動
    private void Construct()
    {
        if (this.IsMove == true)
        {

        }
        else
        {
            if (OneSecond())
            {
                if (this.mocha_parameter.m_Stamina > 0)
                {
                    this.mocha_parameter.m_Stamina--;
                }
                else
                {
                    this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
                }
            }
        }
    }

    // 改装の挙動
    private void Reorganize()
    {
        if (this.IsMove == true)
        {

        }
        else
        {

        }
    }

    float A = 0.0f;

    // 移動の挙動
    private void Emigrate()
    {
        UtillityMethod.PlanetRotate(this.gameObject, 0.1f);

        A += Time.deltaTime;

        if(A >= 10.0f)
        {
            this.mocha_parameter.m_State = MochaState.BREED;
            A = 0.0f;
        }
        
    }

    // 食事の挙動
    private void Meal()
    {
        if (this.IsMove == true)
        {

        }
        else
        {
            if (OneSecond())
            {
                if (this.mocha_parameter.m_Stamina < 100)
                {
                    this.mocha_parameter.m_Stamina++;
                }
                else
                {
                    this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
                }
            }
        }
    }
}
