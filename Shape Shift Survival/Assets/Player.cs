using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] shapes;
    private int currentShapeIndex = 0;
    public float speed = 1f; // Initial speed
    public float acceleration = 0.01f; // How much the speed increases each second

    void Start()
    {
        // Set the initial shape
        ChangeShape(0);
    }

    void Update()
    {
          // Move the player forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Increase the speed
        speed += acceleration * Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Cycle to the next shape
            currentShapeIndex = (currentShapeIndex + 1) % shapes.Length;
            ChangeShape(currentShapeIndex);
        }
    }

    void ChangeShape(int shapeIndex)
    {
        // Deactivate all shapes
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }

        // Activate the selected shape
        shapes[shapeIndex].SetActive(true);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != shapes[currentShapeIndex].tag)
        {
            // Game over
        }
    }
}