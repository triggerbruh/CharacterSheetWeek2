using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    // Character stats that can be set in the Unity Editor
    public string characterName;
    public int proficiencyBonus;
    public bool usingFinesseWeapon;
    public int strModifier; // Strength modifier (-5 to +5)
    public int dexModifier; // Dexterity modifier (-5 to +5)

    void Start()
    {
        // Calculate the hit modifier
        int hitModifier = CalculateHitModifier();

        // Print the hit modifier
        Debug.Log($"Hit Modifier for {characterName}: {FormatModifier(hitModifier)}");

        // Simulate enemy AC and D20 roll
        int enemyAC = Random.Range(10, 21); // Random enemy AC between 10 and 20
        int d20Roll = Random.Range(1, 21); // Simulate rolling a D20

        // Calculate total roll
        int totalRoll = d20Roll + hitModifier;

        // Determine if the attack hits
        bool isHit = totalRoll >= enemyAC;

        // Print the results
        Debug.Log($"Enemy AC: {enemyAC}");
        Debug.Log($"D20 Roll: {d20Roll}");
        Debug.Log(isHit ? $"{characterName} hits the enemy!" : $"{characterName} misses the enemy!");
    }

    // Method to calculate the hit modifier
    private int CalculateHitModifier()
    {
        int effectiveModifier = usingFinesseWeapon ? Mathf.Max(strModifier, dexModifier) : strModifier;
        return effectiveModifier + proficiencyBonus;
    }

    // Method to format the modifier for display
    private string FormatModifier(int modifier)
    {
        return modifier >= 0 ? $"+{modifier}" : modifier.ToString();
    }
}