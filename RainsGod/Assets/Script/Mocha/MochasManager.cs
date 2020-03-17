using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MochasManager : MonoBehaviour
{
    private List<GameObject> MochaList = new List<GameObject>();

    // 各ステートの割合を記憶
    private float[] GuideStateRatio = new float[(int)MochaState.MAX_STATE];

    // 今まで生まれてきたモチャをカウントする為の変数
    private int AllMochaCounter;

    GameObject mocha_data_object;
    MochasData mocha_data;

    void Start()
    {
        mocha_data_object = GameObject.Find("MochasData");
        mocha_data = mocha_data_object.GetComponent<MochasData>();

        // ステート割合の目安
        float EntireStateRatio = 0.0f;
        for (int i = 0; i < (int)MochaState.MAX_STATE; i++)
        {
            EntireStateRatio += mocha_data.mocha_state_info[i].Ratio;
        }
        for (int i = 0; i < (int)MochaState.MAX_STATE; i++)
        {
            GuideStateRatio[i] = mocha_data.mocha_state_info[i].Ratio / EntireStateRatio;
        }

        AllMochaCounter = 0;
    }

    // 新しく生まれるモチャの名前を返す
    // 名前の後に数字を付けることによって同じ名前のモチャが生まれないようにしている。
    public string GenerateNamingMocha()
    {
        string MochaName = "Mocha" + AllMochaCounter++;

        return MochaName;
    }

    // 生成されたモチャをListの一番後ろに追加
    public void AddMochaList(GameObject mocha_)
    {
        MochaList.Add(mocha_);
    }

    public MochaState MochaNextState(GameObject mocha_name_)
    {
        // 次のステートを聞きに来たモチャのリストの要素番号を記憶する
        int MyMochaNumber = MochaList.IndexOf(mocha_name_);

        // -1が返ってきたら失敗
        if (MyMochaNumber == -1)
        {
            Debug.Log("リストから自分を見つけ出すのに失敗");
            return MochaState.BREAK;
        }

        // 変数Mochaで全Mochaの情報に参照できる
        GameObject[] mocha_object = new GameObject[MochaList.Count];
        MochaControl[] mocha = new MochaControl[MochaList.Count];
        for (int i = 0; i < MochaList.Count; i++)
        {
            mocha_object[i] = GameObject.Find(MochaList[i].name);
            mocha[i] = mocha_object[i].GetComponent<MochaControl>();
        }

        // 各ステートのモチャが何人いるのか調べる
        float[] EachStateRatio = new float[(int)MochaState.MAX_STATE];
        for (int i = 0; i < (int)MochaState.MAX_STATE; i++)
        {
            EachStateRatio[i] = 0.0f;
        }
        for (int i = 0; i < MochaList.Count; i++)
        {
            EachStateRatio[(int)mocha[i].mocha_parameter.m_State]++;
        }

        // 現在のモチャ全体のステート比率を調べる
        float EntireStateRatio = MochaList.Count;
        float[] RealStateRatio = new float[(int)MochaState.MAX_STATE];
        for (int i = 0; i < (int)MochaState.MAX_STATE; i++)
        {
            RealStateRatio[i] = EachStateRatio[i] / EntireStateRatio;
        }

        // 行動可能なステートを選別していくためのList
        List<MochaState> MyPossibleHighStateList = new List<MochaState>();
        List<MochaState> MyPossibleLowStateList = new List<MochaState>();


        // ステートの設定した割合と実際の割合を比較し、合ったListに入れる
        void SortingStateList(MochaState mocha_state_)
        {
            if (RealStateRatio[(int)mocha_state_] < GuideStateRatio[(int)mocha_state_])
            {
                MyPossibleHighStateList.Add(mocha_state_);
            }
            else
            {
                MyPossibleLowStateList.Add(mocha_state_);
            }
        }

        // 聞いてきたモチャのMAXになっているパラメーターを調べる
        // もしMAXになっているパラメーターがあったら該当のステートをListに追加する
        {
            SortingStateList(MochaState.BREAK);

            /*if ( もし今いる土地の潤い度が一定値以上なら &&
                    モチャの総人口が人口上限未満なら)
            {
                SortingStateList(MochaState.BREED);
            }*/

            /*if(もしスタミナが一定値以上なら)
            {
                SortingStateList(MochaState.CONSTRUCT);
            }
            */

            /* if(暇しているモチャを探して、そのモチャのステートもして)
            {
                SortingStateList(MochaState.REORGANIZE);
            }
            */

            SortingStateList(MochaState.EMIGRATE);

            /*if (もしスタミナが一定値以下なら)
            {
                SortingStateList(MochaState.MEAL);
            }
            */
        }

        void SortMyList(List<MochaState> mocha_state_)
        {
            // 各ステートリストの要素をステート優先度が高い順に並び替える
            for (int i = 0; i < mocha_state_.Count; i++)
            {
                MochaState MinPriority = mocha_state_[i];

                for (int j = i + 1; j < mocha_state_.Count; j++)
                {
                    if (mocha_data.mocha_state_info[(int)mocha_state_[j]].Priority <
                        mocha_data.mocha_state_info[(int)MinPriority].Priority)
                    {
                        MinPriority = mocha_state_[j];
                    }
                }

                mocha_state_.Remove(MinPriority);
                mocha_state_.Insert(0, MinPriority);
            }
        }

        SortMyList(MyPossibleHighStateList);
        SortMyList(MyPossibleLowStateList);

        List<MochaState> MyPossibleStateList = new List<MochaState>();
        MyPossibleStateList.AddRange(MyPossibleHighStateList);
        MyPossibleStateList.AddRange(MyPossibleLowStateList);

        // もし改装ステートに移行するなら、まず一緒に改装ステートに入れるモチャを探す
        if(MyPossibleStateList[0] == MochaState.REORGANIZE)
        {
            for (int i = 0; i < MochaList.Count; i++)
            {
                if (i == MyMochaNumber)
                {
                    continue;
                }

                if (mocha_data.mocha_state_info[(int)MochaState.REORGANIZE].Priority < mocha_data.mocha_state_info[(int)mocha[i].mocha_parameter.m_State].Priority)
                {

                }
            }
        }

        return MyPossibleStateList[0];
    }
}
