using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotUI : MonoBehaviour
{

    public Weapon weapon;
    private bool isOccupied;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool GetIsOccupied()
    {
        return isOccupied;
    }
    public void SetIsOccupiedFalse()
    {
        isOccupied = false;
    }
    public void SetIsOccupiedTrue()
    {
        isOccupied = true;
    }
    public bool GetIsActive()
    {
        return isActive;
    }
}
