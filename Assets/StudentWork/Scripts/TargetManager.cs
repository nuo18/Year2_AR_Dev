using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class TargetManager : MonoBehaviour
{
    // Variables to change
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private int targetCount = 5;
    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float maxDistance = 3.0f;
    [SerializeField] private float minHeight = 1.0f;
    [SerializeField] private float maxHeight = 3.0f;
    [SerializeField] private float horizontalSpread = 1.5f;
    [SerializeField] private float verticalSpread = 1.5f;

    private List<GameObject> spawnedTargets = new List<GameObject>();

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI remainingText;

    // targets remaining
    private int _remaining;

    private void Start()
    {
        // UI
        _remaining = targetCount;
        UpdateUI();

        SpawnTargets();
    }

    private void SpawnTargets()
    {
        Camera cam = Camera.main;
        for (int i = 0; i < targetCount; i++)
        {
            // horizontal: left/right spread 
            float xOff = Random.Range(-horizontalSpread, horizontalSpread);
            // vertical: always above the ground by between minHeight and maxHeight
            float yOff = Random.Range(minHeight, maxHeight);
            // depth: in front of camera between minDistance and maxDistance
            float zOff = Random.Range(minDistance, maxDistance);

            // build the local?space offset and convert to world?space
            Vector3 localOffset = new Vector3(xOff, yOff, zOff);
            Vector3 worldPos = cam.transform.TransformPoint(localOffset);

            // spawn with no rotation
            Instantiate(targetPrefab, worldPos, Quaternion.identity);
        }
    }

    private void UpdateUI()
    {
        remainingText.text = $"Targets Remaining: {_remaining}";
    }

    // Called by each Target when it’s destroyed
    public void NotifyTargetDestroyed()
    {
        _remaining = Mathf.Max(0, _remaining - 1);
        UpdateUI();
    }
}
