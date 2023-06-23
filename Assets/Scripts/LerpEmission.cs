using UnityEngine;

public class LerpEmission : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;

    public Color startColor; // Starting color
    public Color endColor = new Color(0, 0.7490f, 0.7490f, 1); // Ending color

    private Renderer gameObjectRenderer; // Renderer component to apply color


    public bool isHighlighted = false;

    void Start()
    {
        gameObjectRenderer = GetComponent<Renderer>(); // Get renderer component
        startColor = gameObjectRenderer.material.color; // Set start color
    }

    void Update()
    {
        // Calculate the normalized time based on sine wave oscillation
        float normalizedT = Mathf.Sin(Time.time / speed * Mathf.PI);

        float pingPong = Mathf.PingPong(Time.time * speed, 1);

        float sine = Mathf.Sin(Time.time / speed);

        // Remap the normalizedT from -1 to 1 to a range of 0 to 1
        normalizedT = (normalizedT + 1f) / 2f;

        if (isHighlighted)
        {
            Color lerpedColor = Color.Lerp(startColor, endColor, sine);

            gameObjectRenderer.material.color = lerpedColor;
        }
        else
        {
            gameObjectRenderer.material.color = startColor;
        }
    }
}

