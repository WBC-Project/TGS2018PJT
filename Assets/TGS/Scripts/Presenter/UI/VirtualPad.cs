using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TGS.Presenter.UI
{
    public class VirtualPad : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {    
        [SerializeField]
        private Image baseImage;
        [SerializeField]
        private Image stickImage;
        [SerializeField]
        private float baseRadius = 50.0f;

        private Camera currentCamera = null;

        private RectTransform baseTransform;
        private RectTransform stickTransform;

        private float axisReflectionRate;

        private bool isInitialized = false;
        private bool isExecuted = false;

        private void Awake()
        {
             // レイキャストに干渉しないように変更
             this.baseImage.raycastTarget = false;
             this.stickImage.raycastTarget = false;

             // RectTransformを割り当てる
             this.baseTransform = this.baseImage.rectTransform;
             this.stickTransform = this.stickImage.rectTransform;

             this.axisReflectionRate = 1.0f / this.baseRadius;

             this.isInitialized = true;
        }

        /// <summary>
        /// ドラッグ時処理
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                this.NotifyError("failed Initialized()");
                return;
            }

            // stickImageをタッチしていなければ実行しない
            if(!this.isExecuted)
            {
                return;
            }

            Vector2 difference = eventData.position - eventData.pressPosition;

            Vector3 newPosition = this.baseTransform.position + (Vector3)difference;

            if (difference.sqrMagnitude >= Mathf.Pow(this.baseRadius, 2))
            {
                newPosition = this.baseTransform.position + (Vector3)difference.normalized * this.baseRadius;
            }

            this.stickTransform.position = newPosition;
        }

        /// <summary>
        /// 画面から指が離れたら
        /// </summary>
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                this.NotifyError("failed Initialized()");
                return;
            }

            this.stickTransform.position = this.baseTransform.position;
            this.isExecuted = false;
        }

        /// <summary>
        /// 画面に指が触れたら
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                this.NotifyError("failed Initialized()");
                return;
            }

            this.currentCamera = (this.currentCamera == null) ? eventData.enterEventCamera : this.currentCamera;

            // stickImageをタッチしている時のみ実行するように設定
            this.isExecuted = this.stickTransform.rect.Contains((Vector3)eventData.pressPosition - this.stickTransform.position);
        }

        /// <summary>
        /// Get Virtual Axises Vector
        /// </summary>
        /// <returns>Vector2(Axis.Horizontal, Axis.Vertical)</returns>
        public Vector2 GetVector()
        {
            Vector2 difference = this.stickTransform.position - this.baseTransform.position;
            Vector2 axises = Vector2.zero;

            axises.x = Mathf.Clamp(difference.x * this.axisReflectionRate, -1.0f, 1.0f);
            axises.y = Mathf.Clamp(difference.y * this.axisReflectionRate, -1.0f, 1.0f);

            return axises;
        }

        /// <summary>
        /// 現在入力されているポインターのワールド座標を返します。
        /// </summary>
        /// <param name="eventData">EventSystems.PointerEventData</param>
        /// <return>Vector3.WorldPoint</return>
        private Vector3 GetPointerWorldPoint(PointerEventData eventData)
        {
            Vector3 pointerPosition = Vector3.zero;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(this.stickTransform, eventData.position, this.currentCamera, out pointerPosition);
            return pointerPosition;
        }

        /// <summary>
        /// [Debug Only] エラーを出力する
        /// </summary>
        private void NotifyError(string errorMessage)
        {
            #if UNITY_EDITOR
            UnityEngine.Debug.LogError($"[Virtual Pad Exception Error] {errorMessage}");
            #endif
        }
    }
}