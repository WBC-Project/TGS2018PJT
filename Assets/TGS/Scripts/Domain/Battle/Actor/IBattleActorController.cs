using System;
using System.Collections.Generic;
using TGS.Presenter.UI;
using UnityEngine;

namespace TGS.Domain.Battle.Actor
{
    public interface IBattleActorController
    {
        /// <summary>
        /// バーチャルパッド
        /// </summary>
        VirtualPad VPad { set; }
        
        /// <summary>
        /// タイヤ用コライダー
        /// </summary>
        List<TireData> Tires { set; }

        /// <summary>
        /// ハンドリング
        /// </summary>
        float Handling { get; }

        /// <summary>
        /// 速度
        /// </summary>
        float Speed { get; }

        /// <summary>
        /// 移動処理
        /// </summary>
        void Move();
    }

    [Serializable]
    public struct TireData
    {
        public bool Power;
        public bool Operation;

        public WheelCollider LeftCollider;
        public WheelCollider RightCollider;

        public Transform LeftTire;
        public Transform RightTire;
    }

    public class BattleActorController : MonoBehaviour, IBattleActorController
    {
        /// <summary>
        /// バーチャルパッド
        /// </summary>
        public VirtualPad VPad { private get; set; }

        /// <summary>
        /// タイヤ用コライダー
        /// </summary>
        public List<TireData> Tires { private get; set; }

        /// <summary>
        /// ハンドリング
        /// </summary>
        public float Handling { get; set; } = 30.0f;

        /// <summary>
        /// 速度
        /// </summary>
        public float Speed { get; set; } = 400.0f;

        /// <summary>
        /// 移動処理
        /// </summary>
        public virtual void Move()
        {
            Vector2 inputValue = VPad.GetVector();

            foreach (var tire in Tires)
            {
                if (tire.Operation)
                {
                    tire.LeftCollider.steerAngle = inputValue.x * Handling;
                    tire.RightCollider.steerAngle = inputValue.x * Handling;
                }

                if (tire.Power)
                {
                    tire.LeftCollider.motorTorque = inputValue.y * Speed;
                    tire.RightCollider.motorTorque = inputValue.y * Speed;
                }

                if (tire.LeftTire == null || tire.RightTire == null)
                {
                    continue;
                }
                
                Vector3 tirePos;
                Quaternion tireRot;
                
                tire.RightCollider.GetWorldPose(out tirePos,out tireRot);
                tire.RightTire.transform.position = tirePos;
                tire.RightTire.transform.rotation = tireRot;
                
                tire.LeftCollider.GetWorldPose(out tirePos,out tireRot);
                tire.LeftTire.transform.position = tirePos;
                tire.LeftTire.transform.rotation = tireRot;
            }
        }
    }
}