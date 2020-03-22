using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleEndController : MonoBehaviour
{

    public enum TitleObject
    {
        PLAYER,
        HIMO,
        TITLE,
        ETC
    }

    const float GRAVITY = 0.05f;
    const float DISTRIBUTION_FORCE = 0.04f;

    public TitleObject obj_type;

    public float himo_gravity_accel = -GRAVITY;
    public float reaction = 0.0f;

    public float player_gravity_accel = -0.02f;
    float count = 0.0f;

    bool can_hoist = false;

    public static bool[] can_end = new bool[(int)TitleObject.ETC];

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < (int)TitleObject.ETC; i++)
        {
            can_end[i] = false;
        }

        switch (obj_type)
        {
            case TitleObject.PLAYER:
                transform.localPosition = new Vector3(0, 6, 10);
                //transform.localPosition = new Vector3(0, 14, 0);
                break;
            case TitleObject.HIMO:
                transform.localPosition = new Vector3(-7, 10, 10);
                break;
            case TitleObject.TITLE:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OpDirector.can_title_end)
        {
            int end_count = 0;

            HimoUpdate();

            DummyUpdate();

            TitleUpdate();

            for (int i = 0; i < (int)TitleObject.ETC; i++)
            {
                if (can_end[i]) { end_count++; }
                if (end_count >= (int)TitleObject.ETC)
                {
                    SceneManager.LoadScene("GameScene");
                }
            }

        }

    }

    void HimoUpdate()
    {
        if (obj_type == TitleObject.HIMO)
        {

            transform.Translate(0, himo_gravity_accel, 0);

            himo_gravity_accel -= GRAVITY * Time.deltaTime;


            if (transform.localPosition.y <= 3.0f)
            {
                transform.localPosition = new Vector3(-7, 3, 10);

                reaction = -himo_gravity_accel - DISTRIBUTION_FORCE;
                himo_gravity_accel = reaction;
            }

            if (reaction < 0)
            {
                can_end[(int)TitleObject.HIMO] = true;
            }
        }
    }

    void DummyUpdate()
    {
        if (obj_type == TitleObject.PLAYER)
        {

            float breek = 0.01f;

            player_gravity_accel += breek * Time.deltaTime;

            if (player_gravity_accel >= 0)
            {
                player_gravity_accel = 0.0f;
            }

            transform.Translate(0, player_gravity_accel, 0);


            if (transform.localPosition.y <= 4.0f)
            {
                transform.localPosition = new Vector3(0, 4, 10);
                can_end[(int)TitleObject.PLAYER] = true;
            }
        }
    }

    void TitleUpdate()
    {
        if (obj_type == TitleObject.TITLE)
        {
            float loose = -0.01f;

            if (transform.localPosition.y >= 10.0f)
            {
                can_end[(int)TitleObject.TITLE] = true;
            }

            if (!can_end[(int)TitleObject.TITLE])
            {
                if (transform.localPosition.y <= -0.5f)
                {
                    can_hoist = true;
                }

                if (can_hoist)
                {
                    transform.Translate(0, 0.1f, 0);
                }
                else
                {
                    transform.Translate(0, loose, 0);
                }
            }

        }
    }
}