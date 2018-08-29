using System.Runtime.CompilerServices;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TGS.Presenter.Input
{
    public class VirtualPad : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {    
        [SerializeField] private Image baseImage;
        [SerializeField] private Image stickImage;
        [SerializeField] private float baseRadius = 50.0f;
    
        private Camera currentCamera = null;
    
        private RectTransform baseTransform;
        private RectTransform stickTransform;
        
        private bool isInitialized = false;

		private bool isShow = true;
        private bool execute = false;
        
        private void Awake()
        {
            // レイキャストに干渉しないように変更
            this.baseImage.raycastTarget = false;
            this.stickImage.raycastTarget = false;
            
            this.isInitialized = true;

			baseTransform = baseImage.rectTransform;
			stickTransform = stickImage.rectTransform;
        }
        
        /// <summary>
        /// 起動時処理
        /// </summary>
        private void OnEnable()
        {
            if (!this.isInitialized)
            {
                Debug.LogError("[VPad] 初期化エラー");
                return;
            }
        }
    
        /// <summary>
        /// VPad 非表示時処理
        /// </summary>
        private void OnDisable()
        {
            if (!this.isInitialized)
            {
                Debug.LogError("[VPad] 初期化エラー");
                return;
            }
        }
    
        /// <summary>
        /// ドラッグ時処理
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                Debug.LogError("[VPad] 初期化エラー");
                return;
            }

			if(!isShow || !execute)
			    return;

			stickImage.rectTransform.position = (Vector2)baseTransform.position + eventData.position - eventData.pressPosition;

            baseTransform = baseImage.rectTransform;
			stickTransform = stickImage.rectTransform;

			if (Vector3.Distance(stickTransform.position, baseTransform.position) >= baseRadius)
			{
				Vector3 tmp = eventData.position - eventData.pressPosition;

				stickImage.transform.position = baseTransform.position + tmp.normalized * baseRadius;
			}
        }
    
        /// <summary>
        /// 画面から指が離れたら
        /// </summary>
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                Debug.LogError("[VPad] 初期化エラー");
                return;
            }

			stickTransform.position = baseTransform.position;
            execute = false;
        }
    
        /// <summary>
        /// 画面に指が触れたら
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!this.isInitialized)
            {
                Debug.LogError("[VPad] 初期化エラー");
                return;
            }
            
            if(stickTransform.rect.Contains((Vector3)eventData.pressPosition - stickTransform.position))
                execute = true;
        }
    
        /// <summary>
        /// Get Virtual Axises Vector
        /// </summary>
        /// <returns>Vector2(Axis.Horizontal, Axis.Vertical)</returns>
        public Vector2 GetVector()
        {
			Vector2 stickPos = stickTransform.position;
			Vector2 basePos = baseTransform.position;
			Vector2 difference = stickPos - basePos;

            float distance = Vector2.Distance(stickPos, basePos);

			return difference.normalized * (distance / baseRadius);
        }
    
	    /// <summary>
        /// 非表示にする
        /// </summary>
        public void Hide()
        {
            this.baseImage.gameObject.SetActive(false);
            this.stickImage.gameObject.SetActive(false);

			isShow = false;
        }
    
	    /// <summary>
        /// 表示する
        /// </summary>
        public void Show()
        {
            this.baseImage.gameObject.SetActive(true);
            this.stickImage.gameObject.SetActive(true);

			isShow = true;
        }
    }
}