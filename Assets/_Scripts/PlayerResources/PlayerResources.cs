using System;
using UnityEngine;


[Serializable]
public class PlayerResources
{
    public int Money { get; private set; }

    public event Action<int> OnMoneyChanged;

    public void AddMoney(int amount)
    {
        Money += amount;
        OnMoneyChanged?.Invoke(Money);
    }

    public void SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            OnMoneyChanged?.Invoke(Money);
        }
        else
        {
            Debug.LogWarning("Not enough money!");
        }
    }

    
    public PlayerResourcesData ToData() => new PlayerResourcesData { Money = Money };
    public void FromData(PlayerResourcesData data) => Money = data.Money;
}
