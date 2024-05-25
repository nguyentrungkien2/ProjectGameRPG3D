using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameManager : MonoBehaviour
{
    public void LoadGame()
    {
        // Kiểm tra xem có lưu trữ scene không
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string savedScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(savedScene);

            // Tải các thông tin khác như vị trí, trạng thái nhân vật nếu cần
            // Ví dụ:
            // float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            // float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            // float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");
            // player.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
        }
    }
}
