using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BottleClass))]
public class BottleClassEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BottleClass bottle = (BottleClass)target;

        bottle.drinkType = (BottleClass.DrinkType)EditorGUILayout.EnumPopup("Drink Type", bottle.drinkType);

        if (bottle.drinkType == BottleClass.DrinkType.Soda)
        {
            bottle.sodaType = (BottleClass.SodaType)EditorGUILayout.EnumPopup("Soda Type", bottle.sodaType);
        }
        else if (bottle.drinkType == BottleClass.DrinkType.Alcohol)
        {
            bottle.alcoholType = (BottleClass.AlcoholType)EditorGUILayout.EnumPopup("Alcohol Type", bottle.alcoholType);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(bottle);
        }
    }
}
