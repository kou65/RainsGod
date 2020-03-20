using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    SpriteRenderer sprite_render;

    public Sprite grass_object_a;
    public Sprite grass_object_b;
    public Sprite grass_object_c;
    public Sprite grass_object_d;

    public Sprite solid_object_a;
    public Sprite solid_object_b;
    public Sprite solid_object_c;
    public Sprite solid_object_d;

    GameObject parent;
    GameObject three_parent;

    pirceBase pirce_pearent;

    ObjectType obj_type;

    // Start is called before the first frame update
    void Start()
    {
        sprite_render = gameObject.GetComponent<SpriteRenderer>();

        parent = this.transform.parent.gameObject;
        three_parent = parent.transform.parent.gameObject;

        pirce_pearent = three_parent.GetComponent<pirceBase>();

        this.transform.localPosition = new Vector3(0, Random.Range(7.0f,9.5f), 0);

        this.transform.RotateAround(parent.transform.position, new Vector3(0,0,1), Random.Range(-30,30));

        obj_type = (ObjectType)Random.Range(0, (int)ObjectType.NONE);

    }

    // Update is called once per frame
    void Update()
    {


        switch (pirce_pearent.land_attribute)
        {
            case Attribute.GRASS:
                switch (obj_type)
                {
                    case ObjectType.TYPE_A:
                        sprite_render.sprite = grass_object_a;
                        break;
                    case ObjectType.TYPE_B:
                        sprite_render.sprite = grass_object_b;
                        break;
                    case ObjectType.TYPE_C:
                        sprite_render.sprite = grass_object_c;
                        break;
                    case ObjectType.TYPE_D:
                        sprite_render.sprite = grass_object_d;
                        break;
                }
                break;
            case Attribute.SOLID:
                switch (obj_type)
                {
                    case ObjectType.TYPE_A:
                        sprite_render.sprite = solid_object_a;
                        break;
                    case ObjectType.TYPE_B:
                        sprite_render.sprite = solid_object_b;
                        break;
                    case ObjectType.TYPE_C:
                        sprite_render.sprite = solid_object_c;
                        break;
                    case ObjectType.TYPE_D:
                        sprite_render.sprite = solid_object_d;
                        break;
                }
                break;
        }


    }
}
