using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition; // Lưu vị trí lúc mới sinh ra

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition; // Lưu lại tọa độ tại hũ
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false; // Rất quan trọng: Để chuột "xuyên qua" bột thấy ống nghiệm
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Di chuyển mượt mà theo chuột trong không gian UI
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Nếu không thả vào ống nghiệm "Water", bay về vị trí ban đầu tại hũ
        if (eventData.pointerEnter == null || !eventData.pointerEnter.name.Contains("Water"))
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }
}