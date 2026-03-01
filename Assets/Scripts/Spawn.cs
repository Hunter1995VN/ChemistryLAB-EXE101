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

        // 1. Tạo ra cục bột bên trong Canvas
        GameObject newBao = Instantiate(baoPrefab, canvasTransform);

        // 2. Lấy vị trí của hũ và dịch sang trái (ví dụ: lùi 100 đơn vị)
        // transform.position là vị trí của cái hũ đang được click
        Vector3 spawnPosition = transform.position + new Vector3(-100f, 0, 0);
        newBao.transform.position = spawnPosition;

        // 3. Kích hoạt trạng thái đang kéo cho cục bột mới
        eventData.pointerDrag = newBao;

        // MẸO: Nếu muốn cục bột bắt đầu bị kéo NGAY LẬP TỨC khi click hũ, hãy thêm dòng này:
        // ExecuteEvents.Execute(newBao, eventData, ExecuteEvents.beginDragHandler);
    }
}