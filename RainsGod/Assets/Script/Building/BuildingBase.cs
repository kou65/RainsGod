using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase: MonoBehaviour
{
    public GameObject player_obj;
    public playerController player;

    SpriteRenderer sprite_render;

    public Sprite under_construction;
    public Sprite comprite_construction;
    public Sprite ruin_construction;

    public int hp = 10;
    public BuildingStatus status = BuildingStatus.BUILD;
    public bool has_heavy_rain = false;

    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        player_obj = GameObject.Find("player1");
        player = player_obj.GetComponent<playerController>();

        sprite_render = gameObject.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;



        switch (status)
        {
            case BuildingStatus.BUILD:
                if (delta > span)
                {
                    delta = 0;

                    this.hp += 1;
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
                        this.hp -= 1;
                    }
                    else
                    {
                        if (hp < 100)
                        {
                            this.hp += 1;
                        }
                    }
                }

                break;
            case BuildingStatus.NONE:
                sprite_render.sprite = ruin_construction;
                //Destroy(this.gameObject);
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

        if (GameDirector.suicide_message == true)
        {
            Destroy();
        }

    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
