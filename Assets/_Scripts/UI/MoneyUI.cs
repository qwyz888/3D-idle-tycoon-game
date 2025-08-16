using TMPro;
using UnityEngine;
using _Scripts.PlayerResources;
using _Scripts.Infrastracture;

namespace _Scripts.UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;

        private void Start()
        {
            var resources = ServiceLocator.Get<PlayerResourcesSystem>();
            resources.OnMoneyChanged += UpdateUI;
            UpdateUI(resources.Money);
        }

        private void UpdateUI(int newValue)
        {
            moneyText.text = $"$ {newValue}";
        }
    }
}
