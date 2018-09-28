using UnityEngine;

namespace TGS.Data.Battle.Actor
{
    /// <summary>
    /// キャラクター定義インターフェース
    /// </summary>
    public interface IBattleCharacterDefinition
    {
        /// <summary>
        /// プレハブ
        /// </summary>
        GameObject Prefab { get; }
        
        /// <summary>
        /// キャラクター攻撃力
        /// </summary>
        BattleCharacterAttack Attack { get; }
        
        /// <summary>
        /// キャラクター防御力
        /// </summary>
        BattleCharacterDefense Defense { get; }
        
        /// <summary>
        /// キャラクター死亡時提供経験値量
        /// </summary>
        BattleCharacterBreakExp BreakExp { get; }
    }
    
    /// <summary>
    /// キャラクター定義
    /// </summary>
    public class BattleCharacterDefinition : ScriptableObject, IBattleCharacterDefinition
    {
        [SerializeField] // キャラクタープレハブ
        private GameObject prefab;
        public GameObject Prefab => prefab;

        [SerializeField] // 攻撃力
        private BattleCharacterAttack attack;
        public BattleCharacterAttack Attack => attack;

        [SerializeField] // 防御力
        private BattleCharacterDefense defense;
        public BattleCharacterDefense Defense => defense;

        [SerializeField] // 経験値
        private BattleCharacterBreakExp breakExp;
        public BattleCharacterBreakExp BreakExp => breakExp;
    }

    /// <summary>
    /// キャラクター攻撃力
    /// </summary>
    public struct BattleCharacterAttack
    {
        [SerializeField] // 現在攻撃力
        private int current = 13;
        public int Current => current;

        [SerializeField] // 成長攻撃力
        private int glow;
        public int Glow => glow;

        public BattleCharacterAttack(int current, int glow)
        {
            this.current = current;
            this.glow = glow;
        }
    }

    /// <summary>
    /// キャラクターディフェンス
    /// </summary>
    public struct BattleCharacterDefense
    {
        [SerializeField] // 現在
        private int current = 13;
        public int Current => current;
        
        [SerializeField] // 成長
        private int glow;
        public int Glow => glow;

        public BattleCharacterAttack(int current, int glow)
        {
            this.current = current;
            this.glow = glow;
        }
    }

    /// <summary>
    /// 破壊時提供経験値
    /// </summary>
    public struct BattleCharacterBreakExp
    {
        [SerializeField] // 現在
        private int current = 13;
        public int Current => current;
        
        [SerializeField] // 成長
        private int glow;
        public int Glow => glow;

        public BattleCharacterBreakExp(int current, int glow)
        {
            this.current = current;
            this.glow = glow;
        }
    }
}