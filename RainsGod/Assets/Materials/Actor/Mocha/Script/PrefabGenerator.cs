using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    // 第1引数 Resourcesに入っているPrefabの名前
    // 第2引数 生成される場所
    // 第3引数 生成されたオブジェクトの名前を決める
    public void CreatePrefab(string prefab_name_, Vector3 position_, string new_object_name_)
    {
        GameObject blueprint = (GameObject)Resources.Load(prefab_name_);
        GameObject prefab = Instantiate(blueprint);
        prefab.transform.position = new Vector3(position_.x, position_.y, position_.z);
        prefab.name = new_object_name_;
    }
}
