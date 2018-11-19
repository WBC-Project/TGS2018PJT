using TGS.Application.Manager;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// デバッグメニューのインスタンス作成、表示、データの受け渡し等
/// </summary>
public class DebugMenuManager : SingletonMonoBehaviour<DebugMenuManager> 
{
	public GameObject DebugPanel;
	public GameObject canvas;//
	private GameObject debugPanel;//
	public bool MenuInstantiated = false;//
	/// <summary>
	/// DebugMenu呼び出し
	/// </summary>
	public void OnClick()
	{
		//初回呼び出し
		if (debugPanel == null)
		{
			//パネル生成
			debugPanel = Instantiate(DebugPanel, this.transform.position, Quaternion.identity);
			debugPanel.transform.parent = canvas.transform;//
		}
		//パネルアクティブ化
		debugPanel.gameObject.SetActive(true);
	}
}
