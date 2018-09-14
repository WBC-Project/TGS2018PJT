using System.Collections.Generic;
using TGS.Utility;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace TGS.Presenter.UI
{
    public class HitDamageUI
    {
        private class DamageUI : MonoBehaviour
        {
            private uint damageValue;

            private float alpha = 1.0f;
            private Color spriteColor;

            private List<GameObject> spriteObjects = new List<GameObject>(0);

            public bool Destroy { get; private set; } = false;

            public void SetDamageUI(uint damage, Vector3 position, Color color)
            {
                damageValue = damage;

                this.transform.position = position;

                spriteColor = color;
            }

            private void Start()
            {
                byte digitCount = (byte) damageValue.ToString().Length;

                for (byte i = 0; i < digitCount; i++)
                {
                    byte number = (byte) (damageValue.ToString()[i] - '0');

                    spriteObjects.Add(new GameObject(string.Format("{0}_{1}", i, number), typeof(SpriteRenderer)));

                    spriteObjects[i].layer = 5;
                    spriteObjects[i].transform.parent = this.transform;
                    SpriteRenderer image = spriteObjects[i].GetComponent<SpriteRenderer>();

                    image.sprite = sprites[number];
                    image.color = spriteColor;

                    spriteObjects[i].transform.localPosition = new Vector3(i - (digitCount / 2.0f) + 0.5f, 0.0f);
                }

                this.transform.rotation = Camera.main.transform.rotation;
            }

            /// <summary>
            /// 更新処理
            /// </summary>
            public void DamageUIUpdate()
            {
                this.transform.rotation = Camera.main.transform.rotation;

                alpha -= Time.deltaTime;

                this.transform.position -= new Vector3(0.0f, -(1.0f - alpha) * Time.deltaTime);

                foreach (GameObject sprite in spriteObjects)
                {
                    sprite.GetComponent<SpriteRenderer>().color =
                        new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
                }

                if (alpha <= 0.0f)
                {
                    Destroy = true;
                }
            }
        }
        
        private static List<GameObject> UIDatas = new List<GameObject>(0);

        private static bool initialize = false;

        private static Sprite[] sprites;

        private static void Initialize()
        {
            sprites = Resources.LoadAll<Sprite>("Sprites/UI/NumberFont");
            
            initialize = true;
        }

        /// <summary>
        /// UIの再生
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

            UIDatas.Add(new GameObject("Damage_" + damage, typeof(DamageUI)));
            UIDatas[UIDatas.Count - 1].GetComponent<DamageUI>().SetDamageUI(damage, position, color);
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        public static void Update()
        {
            for (int i = 0; i < UIDatas.Count; i++)
            {
                DamageUI damageUI = UIDatas[i].GetComponent<DamageUI>();
                
                damageUI.DamageUIUpdate();

                if (damageUI.Destroy)
                {
                    GameObject.Destroy(UIDatas[i]);
                    UIDatas.RemoveAt(i);
                }
            }
        }
    }
}