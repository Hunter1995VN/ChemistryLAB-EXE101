using UnityEngine;
using UnityEngine.EventSystems;

public class BaOSpawner : MonoBehaviour, IPointerDownHandler
{
    public GameObject baoPrefab; // Kéo Prefab cục bột vào đây
    public Transform canvasTransform; // Kéo cái Canvas vào đây
    public AudioSource clickSound; // Kéo AudioSource của hũ vào đây
    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickSound != null) clickSound.Play(); // Phát tiếng click
        // Tạo ra cục bột tại vị trí con chuột
        GameObject newBao = Instantiate(baoPrefab, canvasTransform);
        newBao.transform.position = Input.mousePosition;

        // Kích hoạt trạng thái đang kéo cho cục bột mới sinh ra
        eventData.pointerDrag = newBao;
    }
}