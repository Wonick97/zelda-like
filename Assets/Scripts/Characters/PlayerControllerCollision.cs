using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControllerCollision : MonoBehaviour
{
    [Layer]
    public int interactiveNPCObject, interactiveItem;

    public GameObject dialogueNPC, dialogueItem;

    private DialogueSetUp npc;
    private WeaponSetUp weapon;
    private bool isInside;
    private int currentLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public DialogueSetUp GetNPCDialogue()
    {
        return npc;
    }
    public WeaponSetUp GetWeaponDialogue()
    {
        return weapon;
    }
    
    public bool GetIsInsideAnyCollider()
    {
        return isInside;
    }

    public int GetLayerCurrentCollider()
    {
        return currentLayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentLayer = collision.gameObject.layer;
        if (collision.gameObject.layer == interactiveNPCObject)
        {

            npc = collision.gameObject.GetComponentInParent<DialogueSetUp>();
            isInside = true;
        }
        else if(collision.gameObject.layer == interactiveItem)
        {
            weapon = collision.gameObject.GetComponentInParent<WeaponSetUp>();
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentLayer = -1;
        if (collision.gameObject.layer == interactiveNPCObject)
        {
            npc = null;
            isInside = false;
        }
        else if (collision.gameObject.layer == interactiveItem)
        {
            weapon = null;
            isInside = false;
        }
    }


}

