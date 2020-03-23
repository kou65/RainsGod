using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Attribute
{
    GRASS,
    SOLID,
    GRASS_SOLID,
    SOLID_GRASS,
    ETC
}

#region 建築物の列挙子
public enum Building
{
    HOUSE,
    STORE,
    NONE
}
public enum BuildingStatus
{
    BUILD,
    COMPLETE,
    NONE
}
public enum BuildingLevel
{
    LV_1,
    LV_2,
    LV_3,
    NONE
}
public enum BuildingType
{
    TYPE_A,
    TYPE_B,
    TYPE_C,
    TYPE_D,
    NONE
}
#endregion

public enum ObjectType
{
    TYPE_A,
    TYPE_B,
    TYPE_C,
    TYPE_D,
    NONE
}


public enum Status
{
    WET,
    FESTIVAL,
    WITHER,
    PEACE,
    NONE
}

public enum Scene
{
    TITLE,
    GAME,
    NONE
}

public enum GlobalEvent
{
    PLANET_INIT,
    ACHOO,
    ETC
}


public class gameData : MonoBehaviour
{
    public const float MAP_SPEED = 1.0f;
    public const float DECLERATION = 0.99f;

    // プレイヤー画像変更の最小速度
    public const float MINIMUM_SPEED = 0.1f;

    // 建築物の最大数
    public const int MAX_BUILDING = 30;

    // 雲の最大数
    public const int MAX_CLOUDS = 20;

    // 土地の最大数
    public const int MAX_ARC = 4;

    // オブジェクトの最大生成数
    public const int MAX_OBJECT = 3;

    // 初期化イベントの時間
    public const float INIT_EVENT_TIME = 2.0f;

    // 建築物の回復速度
    public const int BUILDING_REPAIR = 10;

    public static float speed;




    private void Update()
    {
        speed = Calculater.speed;
    }

}
