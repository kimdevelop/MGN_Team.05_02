using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro�� ����ϱ� ���� �߰�

public class Ending : MonoBehaviour
{

   [SerializeField]
    private Button mainMenuButton; // ���� �޴��� ���ư��� ��ư*/
    [SerializeField]
    private Button restartButton; // ����ŸƮ ��ư

    private void Start()
    {
     
        // ���� �޴� ��ư Ŭ�� �̺�Ʈ ����
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        // ����ŸƮ ��ư Ŭ�� �̺�Ʈ ����
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
    }

    // ���� �޴� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
   private void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("TitleScene"); // ���� �޴� ������ ��ȯ.
    }

    // ����ŸƮ ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene"); // SampleScene���� ��ȯ
    }
}
