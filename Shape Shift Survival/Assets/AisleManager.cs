using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AisleManager : MonoBehaviour
{
    public GameObject segmentPrefab;
    public int initialSegments = 10;
    public float segmentLength = 10f;
    public int visibleSegments = 10; // Add this line

    private Vector3 nextSegmentPosition;
    private Player player; // Reference to the Player script
    private Queue<GameObject> segments = new Queue<GameObject>(); // Queue to hold the segments

    void Start()
    {
        nextSegmentPosition = Vector3.zero;
        for (int i = 0; i < initialSegments; i++)
        {
            AddSegment();
        }
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.z > nextSegmentPosition.z - (visibleSegments * segmentLength))
        {
            AddSegment();
            RemoveSegment();
        }
    }

    void AddSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab, nextSegmentPosition, Quaternion.identity);
        nextSegmentPosition.z += segmentLength;
        segments.Enqueue(newSegment);
    }

    void RemoveSegment()
    {
        if (segments.Count > visibleSegments)
        {
            GameObject oldSegment = segments.Dequeue();
            Destroy(oldSegment);
        }
    }
}

