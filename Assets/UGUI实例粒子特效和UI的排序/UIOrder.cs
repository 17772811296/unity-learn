using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[AddComponentMenu("UI/UIOrder")]
public class UIOrder : MonoBehaviour
{

	[SerializeField]
	private int _sortingOrder=0;
	public int sortingOrder
	{
		get{
			return _sortingOrder;
		}
		set{
			if(_sortingOrder !=value){
				_sortingOrder = value;
				Refresh();
			}
		}
	}

	private Canvas _canvas = null;
	public Canvas canvas
	{
		get
		{
			if(_canvas == null)
			{
				_canvas = gameObject.GetComponent<Canvas>();
				if(_canvas==null)
					_canvas = gameObject.AddComponent<Canvas>();
				_canvas.hideFlags = HideFlags.NotEditable;
			}
			return _canvas;
		}
	}

	public void Refresh()
	{
		canvas.overrideSorting = true;
		canvas.sortingOrder =  _sortingOrder;
		foreach(ParticleSystemRenderer pariicle in transform.GetComponentsInChildren<ParticleSystemRenderer>(true))
		{
			pariicle.sortingOrder = _sortingOrder;
		}
	}

	#if UNITY_EDITOR
	void OnValidate()
	{
		Refresh();
	}

	void Reset()
	{
		Refresh();
	}
	#endif

}


