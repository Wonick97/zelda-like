using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    public AudioClip weaponObtained;
    private PlayerControllerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {
        playerCollision = GetComponent<PlayerControllerCollision>();
    }

    public void WeaponObtained()
    {

        if (playerCollision.GetIsInsideAnyCollider() && (playerCollision.GetLayerCurrentCollider() == playerCollision.interactiveItem) && !playerCollision.GetWeaponDialogue().dialogueStarted)
        {
            playerCollision.dialogueItem.SetActive(true);
            playerCollision.GetWeaponDialogue().WeaponText();
            AddItemToUI();
            GetComponent<Animator>().SetTrigger("WeaponObtained");
            AudioSource.PlayClipAtPoint(weaponObtained, Vector3.zero, 0.5f);
            DestroyItem();
        }

    }

    public void AddItemToUI()
    {
        SlotUI[] slots = GetComponentsInChildren<SlotUI>(true);
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetIsActive())
            {
                slots[i].weapon = playerCollision.GetWeaponDialogue().weapon;
                slots[i].SetIsOccupiedTrue();
                slots[i].GetComponentInChildren<SpriteRenderer>().sprite = playerCollision.GetWeaponDialogue().weapon.sprite;
                break;
            }

        }

    }

    public void DestroyItem()
    {
        playerCollision.GetWeaponDialogue().gameObject.GetComponent<BasicAnimation>().KillAnimation();
        Destroy(playerCollision.GetWeaponDialogue().gameObject);
    }
}
