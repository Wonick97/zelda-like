using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "NPC Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueSegment> dialogue_segment = new List<DialogueSegment>();
}

[System.Serializable]
public struct DialogueSegment
{
    public string speaker;
    public Sprite face;
    [TextArea(3,10)]
    public string[] sentences;
}



/*EDITOR DEL INSPECTOR - NO RELEVANTE*/
[CustomPropertyDrawer(typeof(DialogueSegment))]
public class DialogueSegmentDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // Get serialized properties
        SerializedProperty speakerProp = property.FindPropertyRelative("speaker");
        SerializedProperty faceProp = property.FindPropertyRelative("face");
        SerializedProperty sentencesProp = property.FindPropertyRelative("sentences");

        // Calculate the height for each field
        float singleLineHeight = EditorGUIUtility.singleLineHeight;
        float faceHeight = 64 + EditorGUIUtility.standardVerticalSpacing; // height for face field
        float sentencesHeight = EditorGUI.GetPropertyHeight(sentencesProp, true); // height for sentences field

        // Calculate the position for each field
        Rect speakerRect = new Rect(position.x, position.y, position.width, singleLineHeight);
        Rect faceRect = new Rect(position.x, position.y + singleLineHeight + EditorGUIUtility.standardVerticalSpacing, 64, 64);
        Rect sentencesRect = new Rect(position.x, position.y + singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing * 2 + faceHeight, position.width, sentencesHeight);

        // Draw speaker field
        EditorGUI.PropertyField(speakerRect, speakerProp);

        // Draw face field as a preview
        EditorGUI.PropertyField(faceRect, faceProp, GUIContent.none);

        // Draw the sprite preview if it's not null
        if (faceProp.objectReferenceValue != null)
        {
            Texture2D texture = AssetPreview.GetAssetPreview(faceProp.objectReferenceValue);
            if (texture != null)
            {
                GUI.DrawTexture(faceRect, texture, ScaleMode.ScaleToFit);
            }
        }

        // Draw sentences field
        EditorGUI.PropertyField(sentencesRect, sentencesProp, true);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Calculate the total height needed for the drawer
        SerializedProperty sentencesProp = property.FindPropertyRelative("sentences");
        float sentencesHeight = EditorGUI.GetPropertyHeight(sentencesProp, true);
        return EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing * 3 + 64 + sentencesHeight;
    }
}