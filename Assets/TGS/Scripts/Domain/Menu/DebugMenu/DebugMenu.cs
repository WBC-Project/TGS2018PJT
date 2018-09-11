using UnityEngine;
/// <summary>
/// ゲーム開始時等、デバッグメニューを出したい任意のタイミングで、このスクリプトを呼んでください。
/// </summary>

public class DebugMenu : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}