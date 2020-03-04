using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatusParameter
{
    public int m_Breed;
    public int m_Stamina;
}

public class MochaControl : MonoBehaviour
{
    [SerializeField]
    public StatusParameter status_parameter_max;   // このモチャのパラメーターの最大値
    public StatusParameter status_parameter;       // このモチャの現在のパラメーター
    public MochaState m_State;                     // このモチャの現在のステート

    GameObject my_object; // 自分自身の情報を入れる為の変数

    GameObject mocha_data_object;
    MochasData mocha_data;

    GameObject mocha_manager_object;
    MochasManager mocha_manager;

    GameObject prefab_generator_object;
    PrefabGenerator prefab_generator;

    private float Delta = 0.0f; // 一秒経過したか計測するのに使用する変数

    void Start()
    {
        mocha_data_object = GameObject.Find("MochaData");
        mocha_data = mocha_data_object.GetComponent<MochasData>();

        mocha_manager_object = GameObject.Find("MochaManager");
        mocha_manager = mocha_manager_object.GetComponent<MochasManager>();

        prefab_generator_object = GameObject.Find("PrefabGenerator");
        prefab_generator = prefab_generator_object.GetComponent<PrefabGenerator>();

        my_object = GameObject.Find(this.transform.name);   // 自分自身の情報で初期化

        // このモチャをMochaManagerのMochaListの一番最後に追加する
        mocha_manager.AddMochaList(my_object);

        // ステータスの最大値をランダムで初期化
        status_parameter_max.m_Breed = Random.Range(this.mocha_data.mocha_status_parameter.Breed.Max, this.mocha_data.mocha_status_parameter.Breed.Min);
        status_parameter_max.m_Stamina = Random.Range(this.mocha_data.mocha_status_parameter.Stamina.Max, this.mocha_data.mocha_status_parameter.Stamina.Min);

        // 現在のステータスを0で初期化
        status_parameter.m_Breed = 0;
        status_parameter.m_Stamina = 0;

        m_State = MochaState.BREAK;
    }

    void Update()
    {
        switch(this.m_State)
        {
            case MochaState.BREAK:
                Break();
                break;
            case MochaState.BREED:
                Breed();
                break;
            case MochaState.CONSTRUCTION:
                Construction();
                break;
        }


        float MoveX = Random.Range(-0.01f, 0.01f);
        float MoveY = Random.Range(-0.01f, 0.01f);

        this.transform.Translate(MoveX, MoveY, 0);

        if (this.transform.position.x > 9 ||
            this.transform.position.x < -9 ||
            this.transform.position.y > 5 ||
            this.transform.position.y < -5)
        {
            this.transform.Translate(-MoveX * 2, -MoveY * 2, 0);
        }
    }

    // 各ステートの挙動で毎フレーム一秒経つごとにtrue
    private bool OneSecond()
    {
        this.Delta += Time.deltaTime;
        if(Delta > 1.0f)
        {
            this.Delta = 0.0f;
            return true;
        }

        return false;
    }

    // ステータスパラメーターを１＋する　ステータスパラメーターがMAXになったらture
    private bool SterusParameterAdd(ref int parameter_, int max_parameter_)
    {
        if(parameter_ < max_parameter_)
        {
            parameter_++;
        }

        if (parameter_ >= max_parameter_)
        {
            return true;
        }

        return false;
    }

    // ステータスパラメーターを１－する　ステータスパラメーターが0になったらture
    private bool SterusParameterSub(ref int parameter_)
    {
        if (parameter_ > 0)
        {
            parameter_--;
        }

        if (parameter_ <= 0)
        {
            return true;
        }

        return false;
    }

    // ステートが変更されたら画像が変わる仮の処理
    private void ChangeArt()
    {
        switch (this.m_State)
        {
            case MochaState.BREAK:
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);                break;
            case MochaState.BREED:
                this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                break;
            case MochaState.CONSTRUCTION:
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                break;
        }
    }


    // 休憩の挙動
    private void Break()
    {
        if(OneSecond() == true) // 一秒に一回
        {
            if(SterusParameterAdd(ref this.status_parameter.m_Breed, this.status_parameter_max.m_Breed) ||
               SterusParameterAdd(ref this.status_parameter.m_Stamina, this.status_parameter_max.m_Stamina))
            {
                m_State = mocha_manager.MochaNextState(my_object);
                ChangeArt();
            }
        }
    }

    // 繁殖の挙動
    private void Breed()
    {
        if (OneSecond() == true)
        {
            if(SterusParameterSub(ref this.status_parameter.m_Breed))
            {
                prefab_generator.CreatePrefab("MochaPrefab", this.transform.position, mocha_manager.GenerateNamingMocha());

                m_State = mocha_manager.MochaNextState(my_object);

                ChangeArt();
            }
        }
    }

     // 建設の挙動
    private void Construction()
    {
        if (OneSecond() == true)
        {
            if (SterusParameterSub(ref this.status_parameter.m_Stamina))
            {
                m_State = mocha_manager.MochaNextState(my_object);

                ChangeArt();
            }
        }
    }
}
