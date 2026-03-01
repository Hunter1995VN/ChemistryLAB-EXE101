using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LabLogic : MonoBehaviour, IDropHandler
{
    public Image waterImage;
    public Sprite bubblingSprite, changeColorSprite, almostDoneSprite, finalResultSprite;
    public GameObject notePanel;

    [Header("Cài đặt Âm thanh")]
    public AudioSource audioSource;
    public AudioClip dropSound;       // 1. Tiếng bỏ bột vào (Kêu ngay lập tức)
    public AudioClip bubblingSound;   // 2. Tiếng sủi bọt (Kêu ở bước 3)
    public AudioClip noteSound;       // 3. Tiếng hiện bảng Note (Kêu cuối cùng)

    private bool isReacted = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null && droppedObject.name.Contains("Chat1Pice") && !isReacted)
        {
            isReacted = true;

            // PHÁT ÂM THANH 1: Tiếng bỏ bột vào nước
            if (audioSource != null && dropSound != null)
            {
                audioSource.PlayOneShot(dropSound);
            }

            Destroy(droppedObject);
            StartCoroutine(RunReactionProcess());
        }
    }

    IEnumerator RunReactionProcess()
    {
        // BƯỚC 1: Sủi bọt (Im lặng)
        waterImage.sprite = bubblingSprite;
        yield return new WaitForSeconds(1f);

        // BƯỚC 2: Đang chuyển hóa (Im lặng)
        waterImage.sprite = changeColorSprite;
        yield return new WaitForSeconds(1f);

        // BƯỚC 3: PHÁT ÂM THANH 2: Tiếng sủi bọt bắt đầu từ đây
        waterImage.sprite = almostDoneSprite;
        if (audioSource != null && bubblingSound != null)
        {
            audioSource.clip = bubblingSound;
            audioSource.loop = true; // Sủi bọt liên tục
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f);

        // BƯỚC 4: Kết quả cuối và DỪNG tiếng sủi
        waterImage.sprite = finalResultSprite;
        if (audioSource != null) audioSource.Stop();

        // PHÁT ÂM THANH 3: Hiện bảng Note và tiếng "Ting"
        if (notePanel != null)
        {
            notePanel.SetActive(true);
            if (audioSource != null && noteSound != null)
            {
                audioSource.PlayOneShot(noteSound);
            }
        }
    }
}