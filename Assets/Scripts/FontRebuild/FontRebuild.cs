using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//调整文字大小时候，由于重建字体贴图，造成文字花屏，通过监听场景文字重构
//事件，整体刷新当前场景所有字体。
public class FontRebuild : MonoBehaviour 
{
    private Font m_NeedRebuildFont = null;
	void Start () 
	{
        Font.textureRebuilt += delegate (Font font)
          {
              m_NeedRebuildFont = font;
          };
	}
	
	void Update () 
	{
        if (m_NeedRebuildFont)
        {
            //找到场景中所有Text，重新刷新
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            if (texts!=null)
            {
                foreach (Text item in texts)
                {
                    if (item.font==m_NeedRebuildFont)
                    {
                        item.FontTextureChanged();
                    }
                }
            }
            m_NeedRebuildFont = null;
        }
	}
}
