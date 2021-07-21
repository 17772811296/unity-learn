using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//UnityEvent:负责管理UnityAction，提供了AddListener，RemoveListener等方法
//注意：UnityEvent如果带参数，需要写一个继承类
public class MyEvent : UnityEvent<int, string> { }
public class Script_05_08 : MonoBehaviour 
{
    public UnityAction<int, string> action1;
    public UnityAction<int, string> action2;
    public MyEvent myEvent = new MyEvent();

    public void RunMyEvent1(int a,string b)
    {
        Debug.LogFormat("RunMyEvent1,{0},{1}", a, b);
    }

    public void RunMyEvent2(int a, string b)
    {
        Debug.LogFormat("RunMyEvent1,{0},{1}", a, b);
    }

    void Start () 
	{
        action1 = RunMyEvent1;
        action2 = RunMyEvent2;

        myEvent.AddListener(action1);
        myEvent.AddListener(action2);
    }
	
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.A))
        {
            action1.Invoke(0, "ooo");
            action2(0, "ooo");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            myEvent.Invoke(100, "ppp");
        }
	}
}
