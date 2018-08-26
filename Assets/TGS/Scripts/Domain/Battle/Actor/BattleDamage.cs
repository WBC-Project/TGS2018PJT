using UnityEngine;

namespace TGS.Domain.Battle.Actor
{

    /// <summary>
    /// ダメージ処理のインターフェース
    /// </summary>
    public interface IBattleDamage
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
    /// ダメージ処理
    /// </summary>
}