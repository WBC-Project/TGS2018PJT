using UnityEngine;
/// <summary>
///値をデバッグメニューからやり取りするためのスクリプト
/// </summary>

public class DebugMenuMng : MonoBehaviour
{
	public bool debugMode = false;
	public bool instBeen = false;
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}