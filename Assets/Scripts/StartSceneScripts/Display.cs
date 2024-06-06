using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class Display : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private string[] messages = new string[]
    {
        "관리사무소에서 F동 입주민 여러분께 긴급 안내 말씀 드립니다.",
        "현재 F동 404호에서 화재가 발생하였습니다.",
        "대피시에는 추가 사고 예방을 위하여 각 세대 주방의 가스밸브를 잠궈주시고,",
        "계단을 이용하여 건물 외부로 침착하게 대피하시기 바랍니다.",
        "다시 한번 F동 입주민 여러분께 긴급 안내말씀 드립니다.",
        "현재 F동 404호에서 화재가 발생하였습니다.",
        "대피시에는 추가 사고 예방을 위하여 각 세대 주방의 가스밸브를 잠궈주시고,",
        "계단을 이용하여 건물 외부로 침착하게 대피하시기 바랍니다.",
        "이상 관리사무소에서 안내 말씀 드렸습니다."
    };

    private float[] timings = new float[]
    {
        1.5f,   // 첫 번째 메시지 시작 시간 (초)
        6.2f,   // 두 번째 메시지 시작 시간 (초)
        9.3f,  // 세 번째 메시지 시작 시간 (초)
        13.5f,  // 네 번째 메시지 시작 시간 (초)
        17.5f,  // 다섯 번째 메시지 시작 시간 (초)
        21.2f,  // 여섯 번째 메시지 시작 시간 (초)
        25.0f,  // 일곱 번째 메시지 시작 시간 (초)
        29.8f,  // 여덟 번째 메시지 시작 시간 (초)
        34.0f   // 아홉 번째 메시지 시작 시간 (초)
    };

    void Start()
    {
        audioSource.clip = audioClip;
        StartCoroutine(PlayAudioAndDisplayText());
    }

    IEnumerator PlayAudioAndDisplayText()
    {
        audioSource.Play();
        for (int i = 0; i < messages.Length; i++)
        {
            textMeshPro.text = messages[i];
            yield return new WaitForSeconds((i == messages.Length - 1) ? 3.0f : timings[i + 1] - timings[i]);
        }
        textMeshPro.text = ""; // 마지막 메시지 제거(잔존 대비)
        SceneManager.LoadScene("SampleScene"); // 씬 전환
    }
}
