using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{

   public void SaveGame()
    {
        PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);

        // Lưu các thông tin khác như vị trí, trạng thái nhân vật nếu cần
        // Ví dụ:
        // PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
        // PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
        // PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);

        // Đừng quên gọi hàm này để lưu các thay đổi vào hệ thống
        PlayerPrefs.Save();
    }
}
