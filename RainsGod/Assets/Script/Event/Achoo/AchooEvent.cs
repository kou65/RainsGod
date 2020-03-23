using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchooEvent : MonoBehaviour
{

    const int FIRST_TIME = 7;
    const int SECOND_TIME = 10;

    int count = 0;
    bool has_tex = false;


    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    // Update is called once per frame
    void Update()
    {

        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;

            count++;
        }

        if (!has_tex && count >= FIRST_TIME)
        {
            DestroyChild();
            has_tex = true;
            PrefabGenerator.CreateChild(this.gameObject, "Prefab/Event/Achoo/achoo2Prefab", "achoo2");
        }

        if (has_tex && count >= SECOND_TIME)
        {
            DestroyChild();
            Destroy(this.gameObject);
            EventDirector.curr_global_event = GlobalEvent.ETC;
        }
    }

    void Play()
    {

        this.transform.localPosition = new Vector3(5,3,10);
        count = 0;
        Calculater.speed += 999.0f;

        PrefabGenerator.CreateChild(this.gameObject, "Prefab/Event/Achoo/achooPrefab", "achoo");
    }

    void DestroyChild()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
