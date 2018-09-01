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
        /// ヒットポイント
        /// </summary>
        /// <value></value>
        int HitPoint { get; }

        /// <summary>
        /// ダメージ処理
        /// </summary>
        void AddDamage();
        int ChangeHitPoint(int fixedHitPoint);


        /// <summary>
        /// 死亡判定
        /// </summary>
        /// <value></value>
        bool DeathFlag{ get; }


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
        /// ヒットポイント
        /// </summary>
        /// <value></value>
        public int HitPoint { get; set;}
        
        /// <summary>
        /// ダメージ処理
        /// </summary>
        /// <param name="fixedHitPoint"></param>
        /// <returns></returns>
        
        public void AddDamage()
        {
            
        }
        public int ChangeHitPoint(int fixedHitPoint)
        {
            this.HitPoint = fixedHitPoint;
        }

        /// <summary>
        /// 死亡判定
        /// </summary>
        /// <value></value>
        public bool DeathFlag {get;}

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            
        }
    }
}