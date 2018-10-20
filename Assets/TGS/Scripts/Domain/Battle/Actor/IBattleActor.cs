using UnityEngine;

namespace TGS.Domain.Battle.Actor
{
    /// <summary>
    /// アクター情報を格納するインターフェース
    /// </summary>
    public interface IBattleActor
    {
        /// <summary>
        /// ユニークID
        /// </summary>
        /// <value></value>
        string Guid { get; set; }

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <value></value>
        GameObject gameObject { get; }
        
        /// <summary>
        /// リジッドボディ
        /// </summary>
        Rigidbody rigidbody { get; }
        
        /// <summary>
        /// ヒットポイント
        /// </summary>
        /// <value></value>
        int HitPoint { get; }

        void ChangeHitPoint(int fixedHitPoint);


        /// <summary>
        /// 死亡判定
        /// </summary>
        /// <value></value>
        bool DeathFlag{ get; set; }


        /// <summary>
        /// 初期化
        /// </summary>
        void Initialize();
    }

    /// <summary>
    /// アクターコンポーネント
    /// </summary>
    public class BattleActor : MonoBehaviour, IBattleActor
    {
        /// <summary>
        /// ユニークID
        /// </summary>
        /// <value></value>
        public string Guid { get; set; }

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <value></value>
        public GameObject gameObject { get { return this.gameObject; } }
        
        /// <summary>
        /// リジッドボディ
        /// </summary>
        public Rigidbody rigidbody { get; set; }

        /// <summary>
        /// ヒットポイント
        /// </summary>
        /// <value></value>
        public int HitPoint { get; set;}
        
        /// <summary>
        /// ヒットポイントの反映
        /// </summary>
        /// <param name="fixedHitPoint"></param>
        /// <returns></returns>
        public void ChangeHitPoint(int fixedHitPoint)
        {
            this.HitPoint = fixedHitPoint;
        }

        /// <summary>
        /// 死亡判定
        /// </summary>
        /// <value></value>
        public bool DeathFlag {get; set; }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            
        }
    }
}