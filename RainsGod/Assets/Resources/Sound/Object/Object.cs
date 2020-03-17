using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface ICommand
{

    // メソッドを実装する必要がある
    void Update();
    void Draw();
    void Init();
}


// 抽象クラス
public abstract class Object : MonoBehaviour
{

    // 継承先でも使える
    protected int m_hp;
    protected Vector3 m_pos;
    protected Vector3 m_scale;
    protected Vector3 m_rotate;

    // 継承先でも使える
    public void Attack()
    {
        m_hp--;
    }

    // override出来るメソッド
    public virtual void Init()
    {
        Debug.Log("初期化");
    }

    // 抽象メソッド(中身は継承先で実装する必要がある)
    public abstract void Talk();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
