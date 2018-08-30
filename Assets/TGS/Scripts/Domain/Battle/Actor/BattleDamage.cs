using UnityEngine;

namespace TGS.Domain.Battle.Actor
{

    /// <summary>
    /// ダメージ処理のインターフェース
    /// </summary>

    public interface IBattleActorDamage
    {
        /// <summary>
        /// ユニークID
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
        void AddDamage();
    }


    public class BattleActorDamage : MonoBehaviour, IBattleActorDamage
    {
        // 各種変数
         private BattleActor.IBattleActor actor = null;
         public IBattleActor Actor => this.actor;
            
         // DI
         public BattleActorDamage(IBattleActor actor)
         {
              this.actor = actor;
         }
            

        /// <summary> 
        /// ユニークID
        /// </summary>
        /// <value></value>
        public IBattleActor { get;}

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <value></value>
        public GameObject gameObject { get { return this.gameObject; } }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        public void AddDamage()
        {
            hitPoint-=1;
            if (hitPoint <= 0)
            {
                BattleActor.set{deathFlag = true;}
            }

        }
    }
}