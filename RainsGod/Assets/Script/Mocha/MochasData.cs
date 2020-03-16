using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MochaState
{
    BREAK,
    BREED,
    CONSTRUCT,
    REORGANIZE,
    EMIGRATE,
    MEAL,
    MAX_STATE
}

[System.Serializable]
public struct MochaStateInfo
{
    [CustomLabel("優先度")] public int Priority;
    [CustomLabel("全体の割合")] public int Ratio;
    [CustomLabel("必要人数")] public int RequiredNumber;
}

public class MochasData : MonoBehaviour
{
    [CustomLabel("人口上限")]
    public int PopulationLimit;

    [EnumLabel(typeof(MochaState))]
    public MochaStateInfo[] mocha_state_info = new MochaStateInfo[(int)MochaState.MAX_STATE];
}
