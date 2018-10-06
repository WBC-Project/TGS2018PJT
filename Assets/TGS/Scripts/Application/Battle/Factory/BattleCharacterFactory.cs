using TGS.Data.Battle.Actor;
using UnityEngine;

namespace TGS.Application.Battle.Factory
{
    /// <summary>
    /// キャラクターファクトリー
    /// </summary>
    public class BattleCharacterFactory
    {
        [HideInInspector] // キャラクター設定情報
        private BattleCharacterDefinition characterDefinition = null;

        public BattleCharacterFactory(BattleCharacterDefinition characterDefinition)
        {
            this.characterDefinition = characterDefinition;
        }
        
        
    }
}