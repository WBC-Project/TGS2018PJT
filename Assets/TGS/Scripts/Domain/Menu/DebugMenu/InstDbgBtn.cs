using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InstDbgBtn : MonoBehaviour
{
	public GameObject canvas;
	public GameObject DbgButton;

	/// <summary>
	/// Buttonの生成
	/// </summary>
	void Start()
	{
		
		GameObject prefab = Instantiate(DbgButton, this.transform.position, Quaternion.identity);
		prefab.transform.SetParent(canvas.transform,false);
	}
}
