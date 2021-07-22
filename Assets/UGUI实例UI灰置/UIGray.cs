using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DisallowMultipleComponent]
public class UIGray : MonoBehaviour
{
	private bool _isGray = false;
	public bool isGray 
	{
		get{ return _isGray;}  
		set
		{
			if(_isGray != value)
			{
				_isGray = value;
				SetGray(isGray);
			}
		}
	}

	static private Material _defaultGrayMaterial;
	static private Material grayMaterial
	{
		get
		{
			if(_defaultGrayMaterial == null)
			{
				_defaultGrayMaterial = new Material(Shader.Find("UI/Gray"));
			}
			return _defaultGrayMaterial;
		}    
	}

	void SetGray(bool isGray) 
	{
		int i =0, count = 0;
		Image [] images =  transform.GetComponentsInChildren<Image>();
		count = images.Length;
		for(i =0; i< count; i++)
		{
			Image g = images[i];
			if(isGray)
			{
				g.material = grayMaterial;
			}else
			{
				g.material  = null;
			}
		}
	}
}
#if UNITY_EDITOR
//告知编辑器类该编辑器所针对的运行时类型。
[CustomEditor(typeof(UIGray))]
public class UIGrayInspector : Editor
{
    //实现此函数以创建自定义检视面板。
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UIGray gray = target as UIGray;
        gray.isGray = GUILayout.Toggle(gray.isGray, " isGray");
        if (GUI.changed)
        {
            //将 target 对象标记为“脏”（仅适用于非场景对象）。
            EditorUtility.SetDirty(target);
        }
    }
}
#endif

