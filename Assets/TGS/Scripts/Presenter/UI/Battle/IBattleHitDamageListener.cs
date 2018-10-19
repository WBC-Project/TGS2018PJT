using System.Collections.Generic;
using UnityEngine;

namespace TGS.Presenter.UI.Battle
{
    public interface IBattleHitDamageListener
    {
        /// <summary>
        /// UIの画像データ
        /// </summary>
        Sprite[] sprites { get; }
        
        /// <summary>
        /// ダメージ描画の開始
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        /// <param name="position">出現させる座標</param>
        /// <param name="color">色</param>
        void Draw(uint damage, Vector3 position, Color color);

        /// <summary>
        /// 更新処理
        /// </summary>
        void BattleHitDamageListenerUpdate();
    }
    
    public class BattleHitDamageListener : MonoBehaviour, IBattleHitDamageListener
    {
        private List<GameObject> UIDatas = new List<GameObject>();

        /// <summary>
        /// UIの画像データ
        /// </summary>
        public Sprite[] sprites { get; private set; }

        private void Start()
        {
            sprites = Resources.LoadAll<Sprite>("Sprites/UI/NumberFont");
        }

        /// <summary>
        /// ダメージ描画の開始
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        /// <param name="position">出現させる座標</param>
        /// <param name="color">色</param>
        public void Draw(uint damage, Vector3 position, Color color)
        {
            UIDatas.Add(new GameObject($"Damage_{damage}", typeof(DamageListener)));
            UIDatas[UIDatas.Count - 1].GetComponent<IDamageListener>().SetDamageUI(damage, position, color, this);
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public void BattleHitDamageListenerUpdate()
        {
            for (int i = 0; i < UIDatas.Count; i++)
            {
                IDamageListener damageListener = UIDatas[i].GetComponent<IDamageListener>();

                damageListener.DamageUIUpdate();

                if (damageListener.Destroy)
                {
                    GameObject.Destroy(UIDatas[i]);
                    UIDatas.RemoveAt(i);
                }
            }
        }
    }
}