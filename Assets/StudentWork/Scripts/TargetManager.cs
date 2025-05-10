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

        // Spawn and hook each target
        Camera cam = Camera.main;
        for (int i = 0; i < targetCount; i++)
        {
            float xOff = Random.Range(-horizontalSpread, horizontalSpread);
            float yOff = Random.Range(minHeight, maxHeight);
            float zOff = Random.Range(minDistance, maxDistance);

            Vector3 localOffset = new Vector3(xOff, yOff, zOff);
            Vector3 worldPos = cam.transform.TransformPoint(localOffset);
            GameObject t = Instantiate(targetPrefab, worldPos, Quaternion.identity);

            // Let each Target know where to report itself
            t.GetComponent<Target>().Initialize(this);
        }
    }

    private void UpdateUI()
    {
        remainingText.text = $"Targets Remaining: {_remaining}";
        
        if (_remaining <= 0)
        {
            remainingText.text = $"Targets Remaining: {_remaining} \n YOU WIN!!!";
        }
    }

    // Called by each Target when it’s destroyed
    public void NotifyTargetDestroyed()
    {
        _remaining = Mathf.Max(0, _remaining - 1);
        UpdateUI();
    }
}
