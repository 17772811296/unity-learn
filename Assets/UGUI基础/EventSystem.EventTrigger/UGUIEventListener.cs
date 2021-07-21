using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//给 text image 基础UI添加点击事件
public class UGUIEventListener : UnityEngine.EventSystems.EventTrigger 
{
    public UnityAction<GameObject> OnClick = null;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (OnClick!=null)
        {
            OnClick(gameObject);
        }
    }

    public static UGUIEventListener Get(GameObject o)
    {
        UGUIEventListener listener = o.GetComponent<UGUIEventListener>();
        if (listener!=null)
        {
            listener = o.AddComponent<UGUIEventListener>();
        }
        return listener;
    }

}
