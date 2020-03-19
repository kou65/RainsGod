using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{

    public GameObject[] arc_base = new GameObject[4];
    public GameObject[] building_obj = new GameObject[gameData.MAX_BUILDING];
    public BuildingBase[] building = new BuildingBase[gameData.MAX_BUILDING];


    public bool has_strong = false;

    SpriteRenderer sprite_render;

    public Sprite strong_right_player;
    public Sprite strong_left_player;
    public Sprite strong_center_player;
    public Sprite right_player;
    public Sprite left_player;
    public Sprite center_player;

    // Start is called before the first frame update
    void Start()
    {
        sprite_render = gameObject.GetComponent<SpriteRenderer>();

        this.transform.localPosition = new Vector3(0,2,0);

        for (int i = 0; i < 4; i++)
        {
            string tmp_name = "base_arc" + (i+ 1);
            arc_base[i] = GameObject.Find(tmp_name);
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (gameData.speed < -gameData.MINIMUM_SPEED && !has_strong)
        {
            sprite_render.sprite = right_player; 
        }
        else if(gameData.speed > gameData.MINIMUM_SPEED && !has_strong)
        {
            sprite_render.sprite = left_player;
        }
        else if(gameData.speed < -gameData.MINIMUM_SPEED && has_strong)
        {
            sprite_render.sprite = strong_right_player;
        }
        else if(gameData.speed > gameData.MINIMUM_SPEED && has_strong)
        {
            sprite_render.sprite = strong_left_player;
        }
        else if(gameData.speed < gameData.MINIMUM_SPEED && gameData.speed > gameData.MINIMUM_SPEED && has_strong)
        {
            sprite_render.sprite = strong_center_player;
        }
        else
        {
            sprite_render.sprite = center_player;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!has_strong)
            {
                has_strong = true;
            }
            else
            {
                has_strong = false;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        GameObject mocha = GameObject.Find("mocha");


        if (collision.tag == "mocha")
        {
            mocha.GetComponent<mochaController>().ChangeHasRain(true);
        }
        if (collision.tag == "base_arc1")
        {
            arc_base[0].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc2")
        {
            arc_base[1].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc3")
        {
            arc_base[2].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc4")
        {
            arc_base[3].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "building" && this.has_strong)
        {
            for (int i = 0; i < gameData.MAX_BUILDING; i++)
            {
                string building_name = "building" + (i + 1);
                building_obj[i] = GameObject.Find(building_name);

                if (!building_obj[i]) { break; }

                building[i] = building_obj[i].GetComponent<BuildingBase>();

            }

        }

        for (int i = 0; i < gameData.MAX_BUILDING; i++)
        {
            if (!this.has_strong)
            {
                continue;
            }

            string building_name = "building" + (i + 1);

            if (collision.tag == building_name)
            {

                building[i].has_heavy_rain = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision_)
    {
        GameObject mocha = GameObject.Find("mocha");

        if (collision_.tag == "mocha")
        {
            mocha.GetComponent<mochaController>().ChangeHasRain(false);
            Debug.Log("雨が当たってません");

        }
        if (collision_.tag == "base_arc1")
        {
            arc_base[0].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc2")
        {
            arc_base[1].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc3")
        {
            arc_base[2].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc4")
        {
            arc_base[3].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        for (int i = 0; i < gameData.MAX_BUILDING; i++)
        {
            string building_name = "building" + (i + 1);

            if (collision_.tag == building_name)
            {

                building[i].has_heavy_rain = false;

            }
        }
    }

}
