using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbgButton : MonoBehaviour
{
    public GameObject DebugPanel;
    public GameObject ExitButton;
    public GameObject canvas;
    private GameObject debugPanel;
    private GameObject exitButton;
    /// <summary>
    /// DebugMenu呼び出し
    /// </summary>
    public void OnClick()
    {
        //初回呼び出し
        if (debugPanel == null)
        {
            //パネル、Exitの順で生成
            debugPanel = Instantiate(DebugPanel, this.transform.position, Quaternion.identity);
            debugPanel.transform.parent = canvas.transform;
            exitButton = Instantiate(ExitButton, this.transform.position, Quaternion.identity);
            exitButton.transform.parent = canvas.transform;
        }
        //パネル、Exitの順でアクティブ化
        debugPanel.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }
}
