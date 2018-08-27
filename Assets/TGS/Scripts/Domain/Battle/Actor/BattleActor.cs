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
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            
        }
    }
}