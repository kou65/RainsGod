using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    SpriteRenderer sprite_render;

    public Sprite grass_construction;
    public Sprite solid_construction;

    GameObject parent;
    GameObject three_parent;

    pirceBase pirce_pearent;

    // Start is called before the first frame update
    void Start()
    {
        sprite_render = gameObject.GetComponent<SpriteRenderer>();

        parent = this.transform.parent.gameObject;
        three_parent = parent.transform.parent.gameObject;

        pirce_pearent = three_parent.GetComponent<pirceBase>();

        this.transform.localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 1), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(pirce_pearent.land_attribute == Attribute.GRASS)
        {
            sprite_render.sprite = grass_construction;
        }
        else if (pirce_pearent.land_attribute == Attribute.SOLID)
        {
            sprite_render.sprite = solid_construction;
        }
    }
}
