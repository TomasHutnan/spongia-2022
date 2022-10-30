using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using AE.CharacterStats;
using AE.Items;
using AE.GameSave;
using Abilities;
public class Character : InventoryHolder
{
    public CharacterStat Damage;
    public CharacterStat CritChance;

    public List<Ability> Ability = new List<Ability>();

    public CharacterStat HealthPoints;
    public CharacterStat DamageReduction;
    public CharacterStat DodgeChance;

    public CharacterStat Stamina;
    public CharacterStat StaminaRegen;
    public CharacterStat Mana;

    public CharacterStat Weight;

    public LevelUpSystem LevelUpSystem;

    public Dictionary<ItemType, Item> EquippedItems;
    public event Action EquipmentUpdateEvent;

    public int Money;
    public event Action MoneyUpdateEvent;

    public bool EquipItem(Item item)
    {
        Item equippedItem;
        bool isEquipped = EquippedItems.TryGetValue(item.Type, out equippedItem);
        if (isEquipped && equippedItem is not null)
        {
            AddItem(equippedItem);
            equippedItem.Unequip(this);
        }

        EquippedItems[item.Type] = item;
        item.Equip(this);
        RemoveItem(item);

        EquipmentUpdateEvent?.Invoke();
        return true;
    }
    public bool UnequipItem(Item item)
    {
        Item equippedItem;
        bool isEquipped = EquippedItems.TryGetValue(item.Type, out equippedItem);

        if (!isEquipped || equippedItem != item)
            return false;

        AddItem(item);
        EquippedItems[item.Type] = null;
        equippedItem.Unequip(this);

        EquipmentUpdateEvent?.Invoke();
        return true;
    }

    public bool SellItem(Item item)
    {
        if (!RemoveItem(item))
            return false;

        Money += item.value;

        MoneyUpdateEvent?.Invoke();
        return true;
    }
    public bool BuyItem(Item item, int cost)
    {
        if (Money < cost)
            return false;

        AddItem(item);
        Money -= cost;

        MoneyUpdateEvent?.Invoke();
        return true;
    }

    void Awake()
    {
        if (transform.name == "GameManager")
        {
            Money = SaveData.Money;
            Inventory = SaveData.Inventory;
            EquippedItems = SaveData.EquippedItems;
        }
        else
        {
            Money = 0;
            Inventory = new List<Item> { };
            EquippedItems = new Dictionary<ItemType, Item> { };
        }
        defaultStats();
        
        Damage.Label = "Damage";
        CritChance.Label = "Crit Chance";
        CritChance.IsPercentual = true;

        HealthPoints.Label = "Health";
        DamageReduction.Label = "Resistance";
        DamageReduction.IsPercentual = true;
        DodgeChance.Label = "Dodge Chance";
        DodgeChance.IsPercentual = true;

        Stamina.Label = "Stamina";
        StaminaRegen.Label = "Stamina Regen";
        Mana.Label = "Mana";

        Weight.Label = "Weight";

        if (LevelUpSystem is null)
        {
            if (transform.name == "GameManager")
            {
                LevelUpSystem = SaveData.LevelUpSystem;
                LevelUpSystem.UpdateActiveCharacter(this);
                // LevelUpSystem.addExp(300); // Level Up Panel Test
            }
            else
            {
                LevelUpSystem = new LevelUpSystem(this);
            }
        }
    }

    private void defaultStats()
    {


        Damage = new CharacterStat(1);
        CritChance = new CharacterStat(0);

        HealthPoints = new CharacterStat(20);
        DamageReduction = new CharacterStat(0);
        DodgeChance = new CharacterStat(0);

        Stamina = new CharacterStat(100);
        StaminaRegen = new CharacterStat(0);
        Mana = new CharacterStat(100);

        Weight = new CharacterStat(80);
    }
}
