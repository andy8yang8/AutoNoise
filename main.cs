using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
        //Debug.Log(width);
    }

    void Update()
    {
        ///To change Default-Material, we need to go to Mesh Renderer Component (Class) -> Materials
        Renderer render = GetComponent<Renderer>();
        render.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);//Perlin
                texture.SetPixel(x, y, color);
            }
        texture.Apply();// unity's quirk; be careful
        return texture;
    }


    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)(x / width) * scale + offsetX;
        float yCoord = (float)(y / height) * scale + offsetY;//0 to 1
        float sample = Mathf.PerlinNoise(xCoord, yCoord);// perlin repeats at whole number
        return new Color(sample, sample, sample);
    }
}
