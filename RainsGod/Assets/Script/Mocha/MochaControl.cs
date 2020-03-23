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

public struct MochaBehaviorInfo
{
    public float Delta;

    public bool IsMove;

    public float StateMaxTime;
    public float StateNowTime;

    public int MoveDirection;
    public float MoveMaxTime;
    public float MoveNowTime;
}


public class MochaControl : MonoBehaviour
{
    public MochaParameter mocha_parameter;
    private MochaState MochaOldState;

    MochaBehaviorInfo mocha_behavior_info;
    private int OldMoveDirection;

    [EnumLabel(typeof(MochaState))]
    public Sprite[] MochaStateSprite = new Sprite[(int)MochaState.MAX_STATE];

    SpriteRenderer MyMochaSpriteRenderer;

    GameObject my_object; // 自分自身の情報を入れる為の変数
    Animator my_animator;

    GameObject mocha_manager_object;
    MochasManager mocha_manager;

    GameObject prefab_generator_object;
    PrefabGenerator prefab_generator;

    void Start()
    {
        //this.mocha_parameter.m_State = MochaState.BREAK;
        this.MochaOldState = this.mocha_parameter.m_State;

        this.OldMoveDirection = 0;

        MyMochaSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        mocha_manager_object = GameObject.Find("MochasManager");
        mocha_manager = mocha_manager_object.GetComponent<MochasManager>();

        prefab_generator_object = GameObject.Find("PrefabGenerator");
        prefab_generator = prefab_generator_object.GetComponent<PrefabGenerator>();

        // 自分自身の情報で初期化
        this.my_object = GameObject.Find(this.transform.name);
        my_animator = GetComponent<Animator>();

        // このモチャをMochasManagerのMochaListの一番最後に追加する
        mocha_manager.AddMochaList(this.my_object);

        mocha_behavior_info.StateMaxTime = 30.0f;
        mocha_behavior_info.StateNowTime = 0.0f;
    }

    void Update()
    {
        StartState();
        StartAnimationMotion();

        switch (this.mocha_parameter.m_State)
        {
            case MochaState.BREAK:
                UpdateBreak();
                break;
            case MochaState.BREED:
                UpdateBreed();
                break;
            case MochaState.CONSTRUCT:
                UpdateConstruct();
                break;
            case MochaState.REORGANIZE:
                UpdateReorganize();
                break;
            case MochaState.EMIGRATE:
                UpdateEmigrate();
                break;
            case MochaState.MEAL:
                UpdateMeal();
                break;
        }
    }

    private void StartState()
    {
        if (this.MochaOldState != this.mocha_parameter.m_State)
        {
            my_animator.SetBool("IsWalkMove", false);

            switch (this.mocha_parameter.m_State)
            {
                case MochaState.BREAK:
                    StartBreak();
                    break;
                case MochaState.BREED:
                    StartBreed();
                    break;
                case MochaState.CONSTRUCT:
                    StartConstruct();
                    break;
                case MochaState.REORGANIZE:
                    StartReorganize();
                    break;
                case MochaState.EMIGRATE:
                    StartEmigrate();
                    break;
                case MochaState.MEAL:
                    StartMeal();
                    break;
            }

            this.MochaOldState = this.mocha_parameter.m_State;
        }
    }

    private void StartAnimationMotion()
    {
        if (this.OldMoveDirection != mocha_behavior_info.MoveDirection)
        {
            if (mocha_behavior_info.MoveDirection != 0)
            {
                my_animator.SetBool("IsWalkMove", true);
            }
            else
            {
                my_animator.SetBool("IsWalkMove", false);
            }

            this.OldMoveDirection = mocha_behavior_info.MoveDirection;

            if(this.OldMoveDirection == -1)
            {
                my_animator.SetFloat("WalkMoveNum", this.OldMoveDirection);
            }
            else if(this.OldMoveDirection == 1)
            {
                my_animator.SetFloat("WalkMoveNum", this.OldMoveDirection);
            }
        }
    }

    // 休憩の準備
    private void StartBreak()
    {
        //MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.BREAK];

        if (this.MochaOldState != this.mocha_parameter.m_State)
        {
            mocha_behavior_info.StateMaxTime = 10.0f;
            mocha_behavior_info.StateNowTime = 0.0f;
        }
        mocha_behavior_info.MoveDirection = Random.Range(-1, 2);
        mocha_behavior_info.MoveMaxTime = Random.Range(1.0f, 5.0f);
        mocha_behavior_info.MoveNowTime = 0.0f;
    }

    // 休憩の挙動
    private void UpdateBreak()
    {
        mocha_behavior_info.MoveNowTime += Time.deltaTime;
        if(mocha_behavior_info.MoveNowTime >= mocha_behavior_info.MoveMaxTime)
        {
            StartBreak();
        }

        float MoveDirection = mocha_behavior_info.MoveDirection / 20.0f;
        UtillityMethod.PlanetRotate(this.gameObject, MoveDirection);

        mocha_behavior_info.StateNowTime += Time.deltaTime;
        if (mocha_behavior_info.StateNowTime >= mocha_behavior_info.StateMaxTime)
        {
            //this.mocha_parameter.m_State = MochaState.BREAK;
            this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
        }
    }

    // 繁殖の準備
    private void StartBreed()
    {
        MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.BREED];

        mocha_behavior_info.StateMaxTime = 10.0f;
        mocha_behavior_info.StateNowTime = 0.0f;
    }

    // 繁殖の挙動
    private void UpdateBreed()
    {
        mocha_behavior_info.StateNowTime += Time.deltaTime;
        if (mocha_behavior_info.StateNowTime >= mocha_behavior_info.StateMaxTime)
        {
            this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);

            prefab_generator.CreatePrefab("Prefab/Mocha/MochaPrefab", mocha_manager.GenerateNamingMocha(), this.transform.position, this.transform.eulerAngles);
        }
    }

    // 建築の準備
    private void StartConstruct()
    {
        MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.CONSTRUCT];

        mocha_behavior_info.IsMove = true;

        mocha_behavior_info.MoveDirection = 1;
        mocha_behavior_info.MoveMaxTime = Random.Range(5.0f, 10.0f);
        mocha_behavior_info.MoveNowTime = 0.0f;

        mocha_behavior_info.StateNowTime = 0.0f;
    }

    // 建築の挙動
    private void UpdateConstruct()
    {
        if (mocha_behavior_info.IsMove == true)
        {
            float MoveDirection = mocha_behavior_info.MoveDirection / 20.0f;
            UtillityMethod.PlanetRotate(this.gameObject, MoveDirection);
          
            mocha_behavior_info.MoveNowTime += Time.deltaTime;
            if (mocha_behavior_info.MoveNowTime >= mocha_behavior_info.MoveMaxTime)
            {
                mocha_behavior_info.IsMove = false;
                my_animator.SetBool("IsWalkMove", false);
            }
        }
        else
        {
            mocha_behavior_info.StateNowTime -= Time.deltaTime;
            if (mocha_behavior_info.StateNowTime <= 0.0f)
            {
                this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
            }

            this.mocha_parameter.m_Stamina = (int)mocha_behavior_info.StateNowTime;
        }
    }

    // 改装の準備
    private void StartReorganize()
    {
        MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.REORGANIZE];

        mocha_behavior_info.IsMove = true;
    }

    // 改装の挙動
    private void UpdateReorganize()
    {
        if (mocha_behavior_info.IsMove == true)
        {

        }
        else
        {

        }
    }

    float A = 0.0f;

    // 移動の準備
    private void StartEmigrate()
    {
        MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.EMIGRATE];

        mocha_behavior_info.MoveDirection = 1;
        mocha_behavior_info.MoveMaxTime = 20.0f;
        mocha_behavior_info.MoveNowTime = 0.0f;
    }

    // 移動の挙動
    private void UpdateEmigrate()
    {
        float MoveDirection = mocha_behavior_info.MoveDirection / 20.0f;
        UtillityMethod.PlanetRotate(this.gameObject, MoveDirection);

        mocha_behavior_info.MoveNowTime += Time.deltaTime;
        if (mocha_behavior_info.MoveNowTime >= mocha_behavior_info.MoveMaxTime)
        {
            this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
        }
    }

    // 食事の準備
    private void StartMeal()
    {
        MyMochaSpriteRenderer.sprite = MochaStateSprite[(int)MochaState.MEAL];

        mocha_behavior_info.IsMove = true;

        mocha_behavior_info.MoveDirection = -1;
        mocha_behavior_info.MoveMaxTime = Random.Range(5.0f, 10.0f);
        mocha_behavior_info.MoveNowTime = 0.0f;

        mocha_behavior_info.StateMaxTime = 100.0f;
        mocha_behavior_info.StateNowTime = this.mocha_parameter.m_Stamina;
    }

    // 食事の挙動
    private void UpdateMeal()
    {
        if (mocha_behavior_info.IsMove == true)
        {
            float MoveDirection = mocha_behavior_info.MoveDirection / 20.0f;
            UtillityMethod.PlanetRotate(this.gameObject, MoveDirection);

            mocha_behavior_info.MoveNowTime += Time.deltaTime;
            if (mocha_behavior_info.MoveNowTime >= mocha_behavior_info.MoveMaxTime)
            {
                mocha_behavior_info.IsMove = false;
                my_animator.SetBool("IsWalkMove", false);
            }
        }
        else
        {
            mocha_behavior_info.StateNowTime += Time.deltaTime;
            if (mocha_behavior_info.StateNowTime >= mocha_behavior_info.StateMaxTime)
            {
                this.mocha_parameter.m_State = mocha_manager.MochaNextState(this.my_object);
            }

            this.mocha_parameter.m_Stamina = (int)mocha_behavior_info.StateNowTime;
        }
    }
}
