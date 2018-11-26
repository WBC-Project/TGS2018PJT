using UnityEngine;

namespace TGS.Domain.Battle.Actor
{
    /// <summary>
    /// ダメージ処理のインターフェース
    /// </summary>
    public interface IBattleActorDamage
    {
        /// <summary>
        /// アクターの取得
        /// </summary>
        /// <value></value>
        IBattleActor Actor { get; }

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <value></value>
        GameObject gameObject { get; }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        void AddDamage(int additionalPoint);
    }
    
        public class BattleActorDamage : MonoBehaviour, IBattleActorDamage
    {
        // 各種変数
         private IBattleActor actor = null;
            
         /// <summary>
         /// 初期化処理としての依存性の注入
         /// </summary>
         /// <param name="actor"></param>
         public BattleActorDamage(IBattleActor actor)
         {
             this.actor = actor;
         }

        /// <summary> 
        /// ユニークID
        /// </summary>
        /// <value></value>

        public IBattleActor Actor { get { return actor; } }

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <value></value>
        public GameObject gameObject { get { return this.gameObject; } }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        public void AddDamage(int additionalPoint)
        {
            int currentHitPoint = this.actor.HitPoint;
            currentHitPoint -= additionalPoint;
            this.actor.ChangeHitPoint(currentHitPoint);

            if (this.actor.HitPoint <= 0)
            {
                this.actor.DeathFlag = true;
            }

        }
    }
}