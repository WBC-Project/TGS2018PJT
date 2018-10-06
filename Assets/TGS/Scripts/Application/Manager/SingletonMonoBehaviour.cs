using System;
using UnityEngine;

namespace TGS.Application.Manager
{
    /// <summary>
    /// よくあるMonobehaviourを使ったSingletonクラスだが、拡張しやすいようにちょっと変更してあげたもの
    /// </summary>
    /// <typeparam name="T">シングルトンを適用したいクラス</typeparam>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        // TODO: ここでタグ管理をしているのだが、そもそもハードコーディングされているのはよくないので修正するか後ほど検討する(kuramoto)
        protected static readonly string[] findTags =
        {
            "GameController",
        };

        #region Instance Propertys

        private bool isInstanceChecked = false;

        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                Type type = typeof(T);
                foreach (var findTag in findTags)
                {
                    GameObject[] objs = GameObject.FindGameObjectsWithTag(findTag);
                    foreach (var obj in objs)
                    {
                        instance = (T) obj.GetComponent(type);
                        if (instance != null)
                        {
                            return instance;
                        }
                    }
                }

                // TODO: 本来はエラーになる想定
                return null;
            }
        }

        #endregion

        /// <summary>
        /// UnityEngine Awake
        /// </summary>
        protected virtual void Awake()
        {
            if (!this.isInstanceChecked)
            {
                this.CheckInstance();
            }
        }

        /// <summary>
        /// UnityEngine Start
        /// </summary>
        protected virtual void Start()
        {
            if (!this.isInstanceChecked)
            {
                this.CheckInstance();
            }
        }

        /// <summary>
        /// インスタンスがあるかチェックを行う
        /// </summary>
        /// <returns></returns>
        protected bool CheckInstance()
        {
            // Instanceがない場合
            if (instance == null)
            {
                instance = (T) this;
                return true;
            }

            // 正常なインスタンスが挿入されている場合
            if (Instance == this)
            {
                return true;
            }

            // 不正なインスタンスが入っていた場合
            {
                Destroy(this);
                return false;
            }
        }
    }
}