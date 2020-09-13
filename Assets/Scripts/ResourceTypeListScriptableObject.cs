using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceTypeList")]
public class ResourceTypeListScriptableObject : ScriptableObject {
    public List<ResourceTypeScriptableObject> list;
}