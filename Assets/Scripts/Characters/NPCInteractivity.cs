using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPCInteractivity : MonoBehaviour
{

    [Layer]
    public int mainCharacterObject;

    public UnityEvent dialogueCall;

    private bool isInside;
    Animator textAnimation;

    // Start is called before the first frame update
    void Start()
    {
        textAnimation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInside)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
                dialogueCall.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == mainCharacterObject)
        {

            textAnimation.SetBool("IsInRange", true);
            isInside = true;

            /*
             * FALTA METER ANIMACIÓN A LA CAJA DE DIÁLOGO
             https://www.youtube.com/watch?v=Zb5GxSz5mSI&ab_channel=TheCodeAnvil
             https://www.youtube.com/watch?v=8e8S8JfIy-M&ab_channel=Outrage
             https://www.youtube.com/watch?v=ta_L_qoMaqc&ab_channel=MixandJam
             */
            Debug.Log("NPC ejecutable");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == mainCharacterObject)
        {

            textAnimation.SetBool("IsInRange", false);
            isInside = false;

            //Debug.Log("NPC ejecutado");

        }
    }

}


/*EDITOR DEL INSPECTOR - NO RELEVANTE*/
[AttributeUsage(AttributeTargets.Field)]
public class LayerAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(LayerAttribute))]
public class LayerAttributeDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.Integer)
        {
            EditorGUI.LabelField(position, "The property has to be a layer for LayerAttribute to work!");
            return;
        }

        property.intValue = EditorGUI.LayerField(position, label, property.intValue);
    }
}