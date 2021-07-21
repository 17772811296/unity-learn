using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Script_05_12 : MonoBehaviour 
{
    public Image image = null;
    private SpriteAtlas m_SpriteAtlas = null;
	void Start () 
	{
        m_SpriteAtlas = Resources.Load<SpriteAtlas>("New Sprite Atlas");
	}

    private void OnGUI()
    {
        if (GUILayout.Button("<size=80>更换 Sprite</size>"))
        {
            image.sprite = m_SpriteAtlas.GetSprite("unity");
        }
    }
    void Update () 
	{
		
	}
}
