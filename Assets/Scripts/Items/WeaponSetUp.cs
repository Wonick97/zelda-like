using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSetUp : MonoBehaviour
{
    public Weapon weapon;
    public TextMeshProUGUI textDialogue;
    public bool dialogueStarted;

    public void WeaponText()
    {
        textDialogue.text = "Has obtenido <color=red>" + weapon.weaponName.ToUpper() +"</color>";
        dialogueStarted = true;
    }
}
