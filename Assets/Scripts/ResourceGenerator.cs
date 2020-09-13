using UnityEngine;

public class ResourceGenerator : MonoBehaviour {
    private BuildingTypeScriptableObject _buildingType;
    private float _timer;
    private float _timerMax;

    private void Awake() {
        _buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        _timerMax = _buildingType.resourceGeneratorData.timerMax;
        _timer = _timerMax;
    }

    private void Update() {
        _timer -= Time.deltaTime;
        if (_timer <= 0f) {
            _timer += _timerMax;
            ResourceManager.Instance.AddResource(_buildingType.resourceGeneratorData.resourceType, 1);
        }
    }
}