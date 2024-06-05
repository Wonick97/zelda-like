using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// Define the Weapon ScriptableObject
[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public string weaponDescription;
    public int weaponDamage;
    public Sprite sprite; // Use AssetReference for Addressables
}
