using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeScriptableObject : ScriptableObject {
    public string nameString;
    public Transform prefab;
    public ResourceGeneratorData resourceGeneratorData;
}