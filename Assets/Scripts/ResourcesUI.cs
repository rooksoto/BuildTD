using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour {
    private ResourceTypeListScriptableObject _resourceTypeList;
    private Dictionary<ResourceTypeScriptableObject, Transform> _resourceTypeTransformDictionary;

    private void Awake() {
        _resourceTypeList = Resources.Load<ResourceTypeListScriptableObject>(Constants.ResourceTypeListPath);
        _resourceTypeTransformDictionary = new Dictionary<ResourceTypeScriptableObject, Transform>();

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;

        foreach (ResourceTypeScriptableObject resourceType in _resourceTypeList.list) {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);
            const float offsetAmount = -160;

            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            _resourceTypeTransformDictionary[resourceType] = resourceTransform;

            index++;
        }
    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManagerOnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManagerOnResourceAmountChanged(object sender, EventArgs e) {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount() {
        foreach (ResourceTypeScriptableObject resourceType in _resourceTypeList.list) {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            Transform resourceTransform = _resourceTypeTransformDictionary[resourceType];
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}