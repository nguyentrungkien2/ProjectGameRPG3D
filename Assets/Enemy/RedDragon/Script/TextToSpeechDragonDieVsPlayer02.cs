using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EdenAI;
using System;
using System.Threading.Tasks;
using TMPro;
public class TextToSpeechDragonDieVsPlayer02 : MonoBehaviour
{
    EdenAIApi edenAI;
    public TMP_Text textToSpeech;
    public AudioSource audioSource; // Thêm một AudioSource vào để phát lại âm thanh
    private string text1 = "Ông ta pháp sư hệ chơi đá nặng ở đây sao ta không biết được ngươi thật sự có tiềm năng đấy ta có món quà cho ngươi, đây là thanh kiếm ánh sáng hãy nhận lấy";
    public async void Start()
    {
        // Khởi tạo lớp EdenAIApi với khóa API của bạn
        string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiMzNiZGIxYTMtYzNlZC00ZjU5LThjMmItODBiMmI2OTlmYWY4IiwidHlwZSI6ImFwaV90b2tlbiJ9.sv6X3FUT9vThl2d8Y7-EYUzfwNvuS4yt9FLe-UuKkvA";
        edenAI = new EdenAIApi(apiKey);

        // Gọi phương thức để chuyển đổi văn bản thành âm thanh
        await ConvertTextToSpeech();
    }

    public async Task ConvertTextToSpeech()
    {
        string provider = "google";
        textToSpeech.text = text1;
        string audioFormat = "mp3";
        TextToSpeechOption option = TextToSpeechOption.MALE;
        string language = "vi";

        // Gửi yêu cầu chuyển đổi văn bản thành âm thanh
        TextToSpeechResponse response = await edenAI.SendTextToSpeechRequest(provider, textToSpeech.text, audioFormat, option, language);

        if (response.status == "success")
        {
            // Truy cập vào âm thanh được tạo ra
            AudioClip generatedAudio = response.audio;
            // Gán âm thanh vào thành phần AudioSource để phát lại
            audioSource.clip = generatedAudio;
            // Phát lại âm thanh
            audioSource.Play();
            Debug.Log("Text to speech conversion successful!");
        }
        else
        {
            // Xử lý trường hợp chuyển đổi văn bản thành âm thanh thất bại
            Debug.LogError("Text to speech conversion failed!");
        }
    }

}
