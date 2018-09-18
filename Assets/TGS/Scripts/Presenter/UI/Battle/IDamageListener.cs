using System.Collections.Generic;
using UnityEngine;

namespace TGS.Presenter.UI.Battle
{
    public interface IDamageListener
    {
        /// <summary>
        /// 削除するべきか
        /// </summary>
        bool Destroy { get; }
        
        /// <summary>
        /// 各値の設定
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        /// <param name="position">出現させる座標</param>
        /// <param name="color">色</param>
        /// <param name="battleHitDamageListener">BattleHitDamageListener</param>
        void SetDamageUI(uint damage, Vector3 position, Color color, IBattleHitDamageListener battleHitDamageListener);

        /// <summary>
        /// 更新処理
        /// </summary>
        void DamageUIUpdate();
    }

    /// <summary>
    /// 文字を描画する為のGameObject
    /// </summary>
    public class DamageListener : MonoBehaviour, IDamageListener
    {
        private uint damageValue;

        private float alpha = 1.0f;
        private Color spriteColor;

        private List<GameObject> spriteObjects = new List<GameObject>();

        private IBattleHitDamageListener battleHitDamageListener;

        /// <summary>
        /// 削除するべきか
        /// </summary>
        public bool Destroy { get; private set; } = false;

        /// <summary>
        /// 各値の設定
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        /// <param name="position">出現させる座標</param>
        /// <param name="color">色</param>
        /// <param name="battleHitDamageListener">BattleHitDamageListener</param>
        public void SetDamageUI(uint damage, Vector3 position, Color color, IBattleHitDamageListener battleHitDamageListener)
        {
            this.damageValue = damage;
            this.transform.position = position;
            this.spriteColor = color;
            this.battleHitDamageListener = battleHitDamageListener;
        }

        private void Start()
        {
            //桁数を算出
            byte digitCount = (byte) damageValue.ToString().Length;

            for (byte i = 0; i < digitCount; i++)
            {
                byte number = (byte) (damageValue.ToString()[i] - '0');

                //文字の生成と設定
                this.spriteObjects.Add(new GameObject($"{i}_{number}", typeof(SpriteRenderer)));
                this.spriteObjects[i].layer = 5;
                this.spriteObjects[i].transform.parent = this.transform;
                
                //SpriteRendererの設定
                SpriteRenderer image = this.spriteObjects[i].GetComponent<SpriteRenderer>();
                
                image.sprite = battleHitDamageListener.sprites[number];
                image.color = this.spriteColor;

                this.spriteObjects[i].transform.localPosition = new Vector3(i - (digitCount / 2.0f) + 0.5f, 0.0f);
            }

            //カメラと同じ角度にして文字がちゃんと見えるようにする
            this.transform.rotation = Camera.main.transform.rotation;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public void DamageUIUpdate()
        {
            //常にカメラと同じ角度にする
            this.transform.rotation = Camera.main.transform.rotation;

            this.transform.position -= new Vector3(0.0f, -(1.0f - alpha) * Time.deltaTime);

            //アルファ値の設定
            this.alpha -= Time.deltaTime;

            foreach (GameObject sprite in this.spriteObjects)
            {
                sprite.GetComponent<SpriteRenderer>().color =
                    new Color(this.spriteColor.r, this.spriteColor.g, this.spriteColor.b, alpha);
            }

            //完全に透明になったら削除
            if (alpha <= 0.0f)
            {
                this.Destroy = true;
            }
        }
    }
}