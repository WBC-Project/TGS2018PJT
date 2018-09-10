using TGS.Presenter.UI;
using UnityEngine;

namespace TGS.Domain.Battle.Actor
{
    public interface IBattleActorController
    {
        /// <summary>
        /// 操作対象
        /// </summary>
        IBattleActor ControlBattleActor { get; }

        /// <summary>
        /// バーチャルパッド
        /// </summary>
        VirtualPad VPad { get; }

        /// <summary>
        /// 移動処理
        /// </summary>
        void Move();
    }

    public class BattleActorController : MonoBehaviour, IBattleActorController
    {
        /// <summary>
        /// バーチャルパッド
        /// </summary>
        public VirtualPad VPad { get; set; }

        /// <summary>
        /// 操作対象
        /// </summary>
        public IBattleActor ControlBattleActor { get; set; } = null;

        /// <summary>
        /// 移動処理
        /// </summary>
        public void Move()
        {
            Vector2 value = VPad.GetVector();
            Vector3 newValue = Vector3.zero;

            newValue.x = value.x;
            newValue.z = value.y;

            ControlBattleActor.gameObject.transform.position += newValue;
        }
    }
}