using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueTrigger : MonoBehaviour
{
    private PlayerControllerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {
        playerCollision = GetComponent<PlayerControllerCollision>();
    }

    public void ActivateDialogue()
    {

        if (playerCollision.GetIsInsideAnyCollider() && (playerCollision.GetLayerCurrentCollider() == playerCollision.interactiveNPCObject) && !playerCollision.GetNPCDialogue().dialogueStarted)
        {
            playerCollision.dialogueNPC.SetActive(true);
            TwistToCharacter();
            playerCollision.GetNPCDialogue().DialogueTrigger();
        }
    }

    public void TwistToCharacter()
    {
        Vector3 direction = playerCollision.GetNPCDialogue().gameObject.GetComponent<Transform>().position - GetComponent<Transform>().position;
        Debug.Log(direction);


        if (direction.y > 0.3f)
        {
            GetComponent<Animator>().SetFloat("LastVertical", 5);
            GetComponent<Animator>().SetFloat("Vertical", 0);
            GetComponent<Animator>().SetFloat("LastHorizontal", 0);
            GetComponent<Animator>().SetFloat("Horizontal", 0);
        }
        else if (direction.y < -0.3f)
        {
            GetComponent<Animator>().SetFloat("LastVertical", -5);
            GetComponent<Animator>().SetFloat("Vertical", 0);
            GetComponent<Animator>().SetFloat("LastHorizontal", 0);
            GetComponent<Animator>().SetFloat("Horizontal", 0);
        }
        else
        {
            if (direction.x < 0)
            {
                GetComponent<Animator>().SetFloat("LastVertical", 0);
                GetComponent<Animator>().SetFloat("Vertical", 0);
                GetComponent<Animator>().SetFloat("LastHorizontal", -5);
                GetComponent<Animator>().SetFloat("Horizontal", 0);
            }
            else
            {
                GetComponent<Animator>().SetFloat("LastVertical", 0);
                GetComponent<Animator>().SetFloat("Vertical", 0);
                GetComponent<Animator>().SetFloat("LastHorizontal", 5);
                GetComponent<Animator>().SetFloat("Horizontal", 0);
            }
        }
    }
}
