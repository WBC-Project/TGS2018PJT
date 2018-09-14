using System.Collections.Generic;
using UnityEngine;

namespace TGS.Presenter.UI.Battle
{
    public class BattleHitDamageListener
    {
        private static List<GameObject> UIDatas = new List<GameObject>();

        private static bool initialize = false;

        /// <summary>
        /// UIの画像データ
        /// </summary>
        public static Sprite[] sprites { get; private set; }

        private static void Initialize()
        {
            sprites = Resources.LoadAll<Sprite>("Sprites/UI/NumberFont");

            initialize = true;
        }

        /// <summary>
        /// ダメージ描画の開始
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        /// <param name="position">出現させる座標</param>
        /// <param name="color">色</param>
        public static void Play(uint damage, Vector3 position, Color color)
        {
            if (!initialize)
            {
                Initialize();
            }

            UIDatas.Add(new GameObject("Damage_" + damage, typeof(DamageListener)));
            UIDatas[UIDatas.Count - 1].GetComponent<DamageListener>().SetDamageUI(damage, position, color);
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public static void Update()
        {
            for (int i = 0; i < UIDatas.Count; i++)
            {
                DamageListener damageListener = UIDatas[i].GetComponent<DamageListener>();

                damageListener.DamageUIUpdate();

                if (damageListener.Destroy)
                {
                    GameObject.Destroy(UIDatas[i]);
                    UIDatas.RemoveAt(i);
                }
            }
        }
    }

    /// <summary>
    /// 文字を描画する為のGameObject
    /// </summary>
    public class DamageListener : MonoBehaviour
    {
        private uint damageValue;

        private float alpha = 1.0f;
        private Color spriteColor;

        private List<GameObject> spriteObjects = new List<GameObject>();

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
        public void SetDamageUI(uint damage, Vector3 position, Color color)
        {
            this.damageValue = damage;
            this.transform.position = position;
            this.spriteColor = color;
        }

        private void Start()
        {
            //桁数を算出
            byte digitCount = (byte) damageValue.ToString().Length;

            for (byte i = 0; i < digitCount; i++)
            {
                byte number = (byte) (damageValue.ToString()[i] - '0');

                //文字の生成と設定
                this.spriteObjects.Add(new GameObject(string.Format("{0}_{1}", i, number), typeof(SpriteRenderer)));
                this.spriteObjects[i].layer = 5;
                this.spriteObjects[i].transform.parent = this.transform;
                
                //SpriteRendererの設定
                SpriteRenderer image = this.spriteObjects[i].GetComponent<SpriteRenderer>();
                
                image.sprite = BattleHitDamageListener.sprites[number];
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