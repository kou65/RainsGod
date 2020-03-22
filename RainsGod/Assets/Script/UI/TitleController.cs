using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{

    public enum LogoStatus
    {
        SAMPLE_1,
        SAMPLE_2,
        SAMPLE_3,
        SAMPLE_4,
    }

    SpriteRenderer sprite_render;

    public Sprite sample_1;
    public Sprite sample_2;
    public Sprite sample_3;
    public Sprite sample_4;

    public LogoStatus status = LogoStatus.SAMPLE_1;

    // Start is called before the first frame update
    void Start()
    {
        sprite_render = gameObject.GetComponent<SpriteRenderer>();

        switch (status)
        {
            case LogoStatus.SAMPLE_1:
                this.transform.localPosition = new Vector3(0, 1, 10);
                sprite_render.sprite = sample_1;
                break;
            case LogoStatus.SAMPLE_2:
                this.transform.localPosition = new Vector3(0, 0, 10);
                sprite_render.sprite = sample_2;
                break;
            case LogoStatus.SAMPLE_3:
                this.transform.localPosition = new Vector3(0, 0, 10);
                sprite_render.sprite = sample_3;
                break;
            case LogoStatus.SAMPLE_4:
                this.transform.localPosition = new Vector3(4,0,10);
                sprite_render.sprite = sample_4;
                break;
        }
    }

}
