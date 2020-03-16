using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : MonoBehaviour
{

    public GameObject player_obj;
    public playerController player;

    SpriteRenderer sprite_render;

    public Sprite on_aura;
    public Sprite no_aura;

    // Start is called before the first frame update
    void Start()
    {
        player_obj = GameObject.Find("player1");
        player = player_obj.GetComponent<playerController>();

        sprite_render = gameObject.GetComponent<SpriteRenderer>();



    }

    // Update is called once per frame
    void Update()
    {
        if (player.has_strong == true)
        {
            sprite_render.sprite = on_aura;
        }
        else
        {
            sprite_render.sprite = no_aura;
        }
    }
}
