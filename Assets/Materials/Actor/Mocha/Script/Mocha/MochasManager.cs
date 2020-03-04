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
        mocha_data_object = GameObject.Find("MochaData");
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
        AllMochaCounter++;

        string MochaName = "Mocha" + AllMochaCounter;

        return MochaName;
    }

    // 生成されたモチャをListの一番後ろに追加
    public void AddMochaList(GameObject mocha_)
    {
        MochaList.Add(mocha_);
    }

    // 各モチャにステートが終了した時点で次のステートを決める
    public MochaState MochaNextState(GameObject mocha_name_)
    {
        // 次のステートを聞きに来たモチャのリストの要素番号を記憶する
        int MyMochaNumber = MochaList.IndexOf(mocha_name_);

        // -1が返ってきたら失敗
        if(MyMochaNumber == -1)
        {
            Debug.Log("リストから自分を見つけ出すのに失敗");
            return MochaState.BREAK;
        }

        // 変数Mochaで全Mochaの情報に参照できる
        GameObject[] mocha_object = new GameObject[MochaList.Count];
        MochaControl[] mocha = new MochaControl[MochaList.Count];
        for(int i = 0; i <  MochaList.Count; i++)
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
            EachStateRatio[(int)mocha[i].m_State]++;
        }

        // 現在のモチャ全体のステート比率を調べる
        float EntireStateRatio = MochaList.Count;
        float[] RealStateRatio = new float[(int)MochaState.MAX_STATE];
        for (int i = 0; i < (int)MochaState.MAX_STATE; i++)
        {
            RealStateRatio[i] = EachStateRatio[i] / EntireStateRatio ;
        }

        // 行動可能なステートを選別していくためのList
        // List<MochaState> MyPossibleStateList = new List<MochaState>();
        List<MochaState> MyPossibleGuideHighStateList = new List<MochaState>();
        List<MochaState> MyPossibleGuideLowStateList = new List<MochaState>();

        void SortingStateList(MochaState mocha_state_)
        {
            if (RealStateRatio[(int)mocha_state_] < GuideStateRatio[(int)mocha_state_])
            {
                MyPossibleGuideHighStateList.Add(mocha_state_);
            }
            else
            {
                MyPossibleGuideLowStateList.Add(mocha_state_);
            }
        }

        // 聞いてきたモチャのMAXになっているパラメーターを調べる
        // もしMAXになっているパラメーターがあったら該当のステートをListに追加する
        {
            MyPossibleGuideLowStateList.Add(MochaState.BREAK);

            if (mocha[MyMochaNumber].status_parameter.m_Breed >=
               mocha[MyMochaNumber].status_parameter_max.m_Breed)
            {
                SortingStateList(MochaState.BREED);
            }

            if (mocha[MyMochaNumber].status_parameter.m_Stamina >=
               mocha[MyMochaNumber].status_parameter_max.m_Stamina)
            {
                SortingStateList(MochaState.CONSTRUCTION);
            }
        }

        // 次のリストを決定
        if (MyPossibleGuideHighStateList.Count > 0)
        {
            // 各ステートリストの要素をステート優先度が高い順に並び替える
            for (int i = 0; i < MyPossibleGuideHighStateList.Count; i++)
            {
                MochaState MinPriority = MyPossibleGuideHighStateList[i];

                for (int j = i + 1; j < MyPossibleGuideHighStateList.Count; j++)
                {
                    if (mocha_data.mocha_state_info[(int)MyPossibleGuideHighStateList[j]].Priority <
                        mocha_data.mocha_state_info[(int)MinPriority].Priority)
                    {
                        MinPriority = MyPossibleGuideHighStateList[j];
                    }
                }

                MyPossibleGuideHighStateList.Remove(MinPriority);
                MyPossibleGuideHighStateList.Insert(0, MinPriority);
            }

            return MyPossibleGuideHighStateList[0];
        }
        else
        {
            // 各ステートリストの要素をステート優先度が高い順に並び替える
            for (int i = 0; i < MyPossibleGuideLowStateList.Count; i++)
            {
                MochaState MinPriority = MyPossibleGuideLowStateList[i];

                for (int j = i + 1; j < MyPossibleGuideLowStateList.Count; j++)
                {
                    if (mocha_data.mocha_state_info[(int)MyPossibleGuideLowStateList[j]].Priority <
                        mocha_data.mocha_state_info[(int)MinPriority].Priority)
                    {
                        MinPriority = MyPossibleGuideLowStateList[j];
                    }
                }

                MyPossibleGuideLowStateList.Remove(MinPriority);
                MyPossibleGuideLowStateList.Insert(0, MinPriority);
            }

            return MyPossibleGuideLowStateList[0];
        }
    }
}
