using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

    private Dictionary<ResourceTypeScriptableObject, int> _resourceAmountDictionary;

    private void Awake() {
        Instance = this;

        _resourceAmountDictionary = new Dictionary<ResourceTypeScriptableObject, int>();

        ResourceTypeListScriptableObject resourceTypeList =
            Resources.Load<ResourceTypeListScriptableObject>(Constants.ResourceTypeListPath);

        foreach (var resourceType in resourceTypeList.list) {
            _resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update() {
        ResourceTypeListScriptableObject resourceTypeList =
            Resources.Load<ResourceTypeListScriptableObject>(Constants.ResourceTypeListPath);

        if (Input.GetKeyDown(KeyCode.T)) {
            AddResource(resourceTypeList.list[0], 2);
        }

        if (Input.GetKeyDown(KeyCode.Y)) {
            AddResource(resourceTypeList.list[1], 2);
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            AddResource(resourceTypeList.list[2], 2);
        }
    }

    public void AddResource(ResourceTypeScriptableObject resourceType, int amount) {
        _resourceAmountDictionary[resourceType] += amount;
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        TestLogResourceAmountDictionary();
    }

    public int GetResourceAmount(ResourceTypeScriptableObject resourceType) {
        return _resourceAmountDictionary[resourceType];
    }

    private void TestLogResourceAmountDictionary() {
        foreach (ResourceTypeScriptableObject resourceType in _resourceAmountDictionary.Keys) {
            Debug.Log($"{resourceType.nameString}: {_resourceAmountDictionary[resourceType]}");
        }
    }
}