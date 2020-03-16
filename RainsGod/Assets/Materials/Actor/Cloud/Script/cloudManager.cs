using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudManager : MonoBehaviour
{
    
    public static cloudManager singleton;

    GameObject planet;


    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null )
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }


        Spown();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UtillityMethod.GetMessage(Message.RESPOWN))
        {
            Spown();
        }
        else if (UtillityMethod.GetMessage(Message.SUISIDE))
        {
            Destroy();
        }

    }

    void Spown()
    {
        this.planet = GameObject.Find("en");

        const int DEGREE = 18;

        Vector3 axis = new Vector3(0, 0, 1);

        Vector3 test = new Vector3(0, 0, 0);

        for (int i = 0; i < gameData.MAX_CLOUDS; i++)
        {
            string cloud_num = "cloud" + i;


            PrefabGenerator.CreateCloud(this.gameObject, "kumoPrefab", new Vector3(Random.Range(-1.5f,1.5f), Random.Range(12, 15), 0), DEGREE * i, cloud_num);

        }
    }

    public void Destroy()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);

        }
    }
}
