using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    private void Start()
    {
        var resources = ServiceLocator.Get<PlayerResources>();
        resources.OnMoneyChanged += UpdateUI;
        UpdateUI(resources.Money);
    }

    private void UpdateUI(int newValue)
    {
        moneyText.text = $"$ {newValue}";
    }
}
