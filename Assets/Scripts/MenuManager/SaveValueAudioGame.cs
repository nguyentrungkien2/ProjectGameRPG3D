using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveValueAudioGame : MonoBehaviour
{
    //private float previousVolume;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject); // Giữ AudioManager tồn tại qua các scene
    //    SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký delegate
    //}

    //private void OnDestroy()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded; // Hủy đăng ký delegate khi script bị hủy
    //}

    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    RestoreAudioState(); // Khôi phục giá trị âm lượng sau khi chuyển scene
    //}

    //public void SaveAudioState()
    //{
    //    previousVolume = AudioListener.volume; // Lưu giá trị âm lượng trước khi chuyển scene
    //}

    //public void RestoreAudioState()
    //{
    //    AudioListener.volume = previousVolume; // Khôi phục giá trị âm lượng sau khi chuyển scene
    //}

    // Gọi hàm SaveAudioState trước khi chuyển scene
    public void LoadScene(int sceneId)
    {
        //SaveAudioState();
        SceneManager.LoadScene(sceneId);
    }
}
