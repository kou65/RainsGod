using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase: MonoBehaviour
{
    protected SpriteRenderer sprite_render;

    // 旧画像
    public Sprite under_construction;
    public Sprite comprite_construction;
    public Sprite ruin_construction;

#region 本画像

    public Sprite lv1_build_type_a;
    public Sprite lv2_build_type_a;
    public Sprite lv3_build_type_a;
    public Sprite lv1_build_type_b;
    public Sprite lv2_build_type_b;
    public Sprite lv3_build_type_b;
    public Sprite lv1_build_type_c;
    public Sprite lv2_build_type_c;
    public Sprite lv3_build_type_c;
    public Sprite lv1_build_type_d;
    public Sprite lv2_build_type_d;
    public Sprite lv3_build_type_d;


    public Sprite lv1_complete_type_a;
    public Sprite lv2_complete_type_a;
    public Sprite lv3_complete_type_a;
    public Sprite lv1_complete_type_b;
    public Sprite lv2_complete_type_b;
    public Sprite lv3_complete_type_b;
    public Sprite lv1_complete_type_c;
    public Sprite lv2_complete_type_c;
    public Sprite lv3_complete_type_c;
    public Sprite lv1_complete_type_d;
    public Sprite lv2_complete_type_d;
    public Sprite lv3_complete_type_d;
#endregion

    public int hp = 10;
    public bool has_heavy_rain = false;

    public BuildingStatus status = BuildingStatus.BUILD;
    public BuildingLevel building_level = BuildingLevel.NONE;
    public BuildingType building_type = BuildingType.NONE;

    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        StatusUpdate();

        SpriteUpdate();

        Destroy();
    }

    protected void Init()
    {
        hp = 10;

        int random_level = Random.Range(0, (int)BuildingLevel.NONE);
        int random_type = Random.Range(0, (int)BuildingType.NONE);

        building_level = (BuildingLevel)random_level;
        building_type = (BuildingType)random_type;

        status = BuildingStatus.BUILD;

        sprite_render = gameObject.GetComponent<SpriteRenderer>();

    }

    protected void StatusUpdate()
    {
        delta += Time.deltaTime;

        switch (status)
        {
            case BuildingStatus.BUILD:
                if (delta > span)
                {
                    delta = 0;

                    this.hp += gameData.BUILDING_REPAIR;
                }

                sprite_render.sprite = under_construction;

                break;
            case BuildingStatus.COMPLETE:
                sprite_render.sprite = comprite_construction;
                if (delta > span)
                {
                    delta = 0;

                    if (has_heavy_rain)
                    {
                        this.hp -= gameData.BUILDING_REPAIR;
                    }
                    else
                    {
                        if (hp < 100)
                        {
                            this.hp += gameData.BUILDING_REPAIR;
                        }
                    }
                }

                break;
            case BuildingStatus.NONE:
                sprite_render.sprite = ruin_construction;
                break;
        }

        if (hp > 0 && hp < 100 && !has_heavy_rain && status != BuildingStatus.COMPLETE && status != BuildingStatus.NONE)
        {
            status = BuildingStatus.BUILD;
        }
        else if (has_heavy_rain && status == BuildingStatus.BUILD)
        {
            status = BuildingStatus.NONE;
        }

        if (hp >= 100)
        {
            status = BuildingStatus.COMPLETE;

        }
        else if (hp <= 0)
        {
            status = BuildingStatus.NONE;
        }

    }


    protected void SpriteUpdate()
    {
        switch (building_type)
        {
            case BuildingType.TYPE_A:
                switch (building_level)
                {
                    case BuildingLevel.LV_1:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv1_build_type_a;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv1_complete_type_a;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_2:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv2_build_type_a;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv2_complete_type_a;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_3:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv3_build_type_a;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv3_complete_type_a;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.NONE:
                        break;
                }
                break;
            case BuildingType.TYPE_B:
                switch (building_level)
                {
                    case BuildingLevel.LV_1:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv1_build_type_b;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv1_complete_type_b;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_2:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv2_build_type_b;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv2_complete_type_b;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_3:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv3_build_type_b;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv3_complete_type_b;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.NONE:
                        break;
                }
                break;
            case BuildingType.TYPE_C:
                switch (building_level)
                {
                    case BuildingLevel.LV_1:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv1_build_type_c;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv1_complete_type_c;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_2:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv2_build_type_c;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv2_complete_type_c;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_3:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv3_build_type_c;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv3_complete_type_c;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.NONE:
                        break;
                }
                break;
            case BuildingType.TYPE_D:
                switch (building_level)
                {
                    case BuildingLevel.LV_1:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv1_build_type_d;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv1_complete_type_d;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_2:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv2_build_type_d;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv2_complete_type_d;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.LV_3:
                        switch (status)
                        {
                            case BuildingStatus.BUILD:
                                sprite_render.sprite = lv3_build_type_d;
                                break;
                            case BuildingStatus.COMPLETE:
                                sprite_render.sprite = lv3_complete_type_d;
                                break;
                            case BuildingStatus.NONE:
                                sprite_render.sprite = null;
                                break;
                        }
                        break;
                    case BuildingLevel.NONE:
                        break;
                }
                break;
        }
    }

    protected void Destroy()
    {
        if (GameDirector.suicide_message == true)
        {
            Destroy(this.gameObject);
        }
    }
}
