using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager

public class TitleManager : MonoBehaviour
{
    // ���� ���� ��ư�� ������ �� ȣ��
    public void OnStartButtonPressed()
    {
        // StartScene���� �� ��ȯ
        SceneManager.LoadScene("StartScene");
    }

    // ���� ���� ��ư ������ �� ȣ��.
    public void OnExitButtonPressed()
    {
        // ���� ����
        Application.Quit();

        // �����Ϳ��� ���� �׽�Ʈ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
