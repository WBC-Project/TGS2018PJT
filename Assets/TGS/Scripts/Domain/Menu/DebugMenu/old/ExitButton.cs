using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
	/// <summary>
	/// DebugMenu呼び出し
	/// </summary>
	public void OnClick()
	{
		Debug.Log("push!");
		this.gameObject.SetActive(false);
	}
}
