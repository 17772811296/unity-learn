using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script_05_06 : MonoBehaviour ,IPointerClickHandler 
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogFormat("<color=red>{0},</color>", gameObject.name);
        
    }

    void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}
}
