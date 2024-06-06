using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    private void Start()
    {
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    private void OnYesButtonClicked()
    {
        GameManager.instance.OnYesButton();
    }

    private void OnNoButtonClicked()
    {
        GameManager.instance.OnNoButton();
    }
}
