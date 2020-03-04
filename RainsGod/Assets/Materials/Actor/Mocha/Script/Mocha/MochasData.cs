using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MochaParameter
{
    public int Max;
    public int Min;
}

[System.Serializable]
public struct MochaStatus
{
    [CustomLabel("繁殖力")]   public MochaParameter Breed;
    [CustomLabel("スタミナ")] public MochaParameter Stamina;
}

public enum MochaState
{
    BREAK,
    BREED,
    CONSTRUCTION,
    MAX_STATE
}

[System.Serializable]
public struct MochaStateInfo
{
    [CustomLabel("優先度")]      public int Priority;
    [CustomLabel("全体の割合")]  public int Ratio;
    [CustomLabel("必要人数")]    public int RequiredNumber;
}

public class MochasData : MonoBehaviour
{
    [CustomLabel("パラメーターの最大値の最小値")]
    public MochaStatus mocha_status_parameter;

     [EnumLabel(typeof(MochaState))]
    public MochaStateInfo[] mocha_state_info = new MochaStateInfo[(int)MochaState.MAX_STATE];
}
