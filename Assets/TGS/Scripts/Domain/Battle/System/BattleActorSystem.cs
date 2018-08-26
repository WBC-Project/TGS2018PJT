using System.Collections.Generic;
using TGS.Domain.Battle.System;
using TGS.Domain.Battle.Actor;

namespace TGS.Domain.Battle.System
{
    public class BattleActorSystem : IUpdatable
    {
        private IList<IBattleActor> list;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            BattleMainLoop.Instance().Register(this);
        }

        /// <summary>
        /// 毎フレーム更新
        /// </summary>
        public void UpdateByFrame()
        {
            // ここに毎フレーム更新する内容を記載する
        }

        /// <summary>
        /// Systemに登録する
        /// </summary>
        public void Register(IBattleActor actor)
        {
            if (!this.list.Contains(actor))
            {
                this.list.Add(actor);
            }
        }
    }
}