using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TGS.Presenter.UI
{
    public class ButtonManager : MonoBehaviour
    {
        /// <summary>
        /// シーンの遷移
        /// </summary>
        /// <param name="sceneName">遷移先のシーン名</param>
        public void SceneTransition(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}