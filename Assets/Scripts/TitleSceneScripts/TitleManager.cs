using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager

public class TitleManager : MonoBehaviour
{
    // 게임 시작 버튼을 눌렀을 때 호출
    public void OnStartButtonPressed()
    {
        // StartScene으로 씬 전환
        SceneManager.LoadScene("StartScene");
    }

    // 게임 종료 버튼 눌렀을 때 호출.
    public void OnExitButtonPressed()
    {
        // 게임 종료
        Application.Quit();

        // 에디터에서 종료 테스트
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
