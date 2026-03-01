using UnityEngine;
using UnityEngine.SceneManagement; // Thư viện để quản lý chuyển cảnh

public class MenuController : MonoBehaviour
{
    // Hàm này sẽ gọi khi bấm nút Bài 1a
    public void LoadLesson1a()
    {
        SceneManager.LoadScene("Less1a");
        // Lưu ý: "ThiNghiem1a" phải khớp y hệt tên Scene thí nghiệm của bạn
    }
}