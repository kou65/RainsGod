using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    // 第1引数 Resourcesに入っているPrefabの名前
    // 第2引数 生成される座標
    // 第3引数 生成された時の回転度
    public void CreatePrefab(string prefab_name_, string new_object_name_, Vector3 position_, Vector3 rotation_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);
        prefab.transform.name = new_object_name_;
        prefab.transform.position = new Vector3(position_.x, position_.y, position_.z);
        prefab.transform.eulerAngles = new Vector3(rotation_.x, rotation_.y, rotation_.z);
    }

<<<<<<< HEAD
    public void CreatePrefab(string prefab_name_, Vector3 position_, string new_object_name_)
=======
    // buildingで実験中２
    public static void CreatePrefab(string prefab_name_, GameObject obj_, string new_object_name_)
>>>>>>> cc0cbdef04fbbad1ea18951c4fb6bab0be87b2f0
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.position = obj_.transform.position;
        prefab.transform.rotation = obj_.transform.rotation;

        // 命名とラベル作成
        prefab.name = new_object_name_;
        TagMaker.AddTag(new_object_name_);
        prefab.tag = new_object_name_;
    }
    public static void CreatePrefabTest(string prefab_name_, GameObject obj_, string new_object_name_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

<<<<<<< HEAD
    public void CreatePrefab(string prefab_name_, Vector3 position_, Vector3 rotation_, string new_object_name_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.position = new Vector3(position_.x, position_.y, position_.z);
        prefab.transform.Rotate(rotation_.x, rotation_.y, rotation_.z, Space.World);

        prefab.name = new_object_name_;

        //tagの動的生成
#if UNITY_EDITOR
        TagMaker.AddTag(new_object_name_);
#endif
        prefab.tag = new_object_name_;

    }

    // Objectで実験中
    public static void CreatePrefabTest(string prefab_name_, GameObject obj_, string new_object_name_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.position = obj_.transform.position;

        prefab.transform.rotation = obj_.transform.rotation;
        prefab.transform.parent = obj_.transform;

        prefab.name = new_object_name_;

        //tagの動的生成
#if UNITY_EDITOR
        TagMaker.AddTag(new_object_name_);
#endif
        prefab.tag = new_object_name_;
    }

    // buildingで実験中２
    public void CreatePrefab(string prefab_name_, GameObject obj_, string new_object_name_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.position = obj_.transform.position;
        prefab.transform.rotation = obj_.transform.rotation;

        prefab.name = new_object_name_;

        //tagの動的生成
#if UNITY_EDITOR
        TagMaker.AddTag(new_object_name_);
#endif
        prefab.tag = new_object_name_;
    }

    public static void CreateCloud(GameObject obj_, string prefab_name_, Vector3 position_, float degree_, string new_object_name_)
    {
        Vector3 axis = new Vector3(0, 0, 1);

        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.localPosition = new Vector3(position_.x, position_.y, position_.z);
        prefab.name = new_object_name_;
        prefab.transform.RotateAround(obj_.transform.position, axis, degree_);
=======
        prefab.transform.position = obj_.transform.position;
        prefab.transform.rotation = obj_.transform.rotation;

        // 命名とラベル作成
        prefab.name = new_object_name_;
        TagMaker.AddTag(new_object_name_);
        prefab.tag = new_object_name_;
    }

    public static void CreateChild(GameObject obj_, string prefab_name_, Vector3 position_, float degree_, string new_object_name_)
    {
        Vector3 axis = new Vector3(0, 0, 1);

        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);

        prefab.transform.localPosition = new Vector3(position_.x, position_.y, position_.z);
        prefab.transform.RotateAround(obj_.transform.position, axis, degree_);

        prefab.transform.parent = obj_.transform;

        // 命名とラベル作成
        prefab.name = new_object_name_;
        TagMaker.AddTag(new_object_name_);
        prefab.tag = new_object_name_;

    }
>>>>>>> cc0cbdef04fbbad1ea18951c4fb6bab0be87b2f0

        prefab.transform.parent = obj_.transform;

<<<<<<< HEAD
    }
=======
>>>>>>> cc0cbdef04fbbad1ea18951c4fb6bab0be87b2f0
}
