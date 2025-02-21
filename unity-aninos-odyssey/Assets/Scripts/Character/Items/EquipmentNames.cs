using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AE.Items
{
    public class EquipmentNames : MonoBehaviour
    {
        static string[] _itemNames = new string[] { "Acrimony", "Agony", "Azure Lightning", "Balance", "Blessed One", "Bone", "Bonnie�s Bounty", "Brawn", "Burning Hate", "Cat�s Claw", "Cleaver", "Crimson Fury", "Darkness", "Death�s Hand", "Defiance", "Despair", "Devotion", "Disdain", "Divine Right", "Dominion", "Dragon�s Tooth", "Echo", "Eternal Damnation", "Evil Eye", "Fang", "Flame Tongue", "Forbearance", "Fortitude", "Frenzy", "Funereal Edge", "Fury", "Giant�s Bane", "Grim Reality", "Harbinger", "Harsh Lesson", "Heart of Oak", "Higher Power", "Honor", "Hope", "Ice Shard", "Icy Rage", "Insolence", "Iron Fist", "Jarod�s Fever", "Justice", "Killing Blow", "King�s Glory", "Lament", "Last Rights", "Marauder�s Mania", "Mercy", "Might & Right", "Misery", "Night�s Wind", "Oblivion", "Obsession", "Oracle", "Orc Cleaver", "Patience", "Pincer", "Pride", "Promise Keeper", "Proud Glory", "Punishment", "Queen�s Rage", "Quicksilver", "Rage", "Razor", "Reliant", "Resolve", "Revenge", "Ruination", "Scorned Woman", "Screaming Death", "Severity", "Shield Breaker", "Silent Scream", "Solemn Oath", "Splinter", "Stonebreaker", "Summer Steel", "Superior Force", "Swagger", "Talon", "Tidal Wave", "Tenacity", "Truth", "Torrent", "Unrepentant", "Usurper�s Bane", "Valor", "Vapor", "Vengeance", "Verdant Pain", "Victory", "War Bringer", "Widowmaker", "Winter�s Bane", "Yanna�s Blaze", "Zara�s Song" };

        public static string GetRandom()
        {
            return _itemNames[Random.Range(0, _itemNames.Length)];
        }
    }
}
