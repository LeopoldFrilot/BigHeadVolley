using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ProcGen
{
    public class NoiseTextureCreator : MonoBehaviour
    {
        [Header("Texture")]
        [SerializeField] Renderer textureRenderer;
        [SerializeField] float autoUpdateTimer;
        [Header("Size")]
        [SerializeField] [Range(5,20)] int squaresPerRow;
        [SerializeField] int textureHeight;
        [SerializeField] int textureWidth;
        [Header("Design Tools")]
        [SerializeField] [Range(0, 1000)] int RNGSeed;
        [SerializeField] Vector2 offset;
        [SerializeField] bool autoUpdate;
        [SerializeField] float scale;
        [SerializeField] [Range(0,1f)] float audiencePresenceThreshold;

        float maxNoiseHeight = float.MaxValue;
        float minNoiseHeight = float.MinValue;

        float timer = 0;
        public void Start()
        {
            GenerateNewAudience();
        }
        public void Update()
        {
            if (autoUpdate == true)
            {
                if (timer >= autoUpdateTimer)
                {
                    //GenerateNewAudience();
                    timer = 0;
                }
                timer += Time.deltaTime;
            }
        }
        void FixWidthAndHeight()
        {
            textureWidth -=  textureWidth % squaresPerRow; // Makes sure the width of the noise map is a multiple of squaresPerRow
            int blockSize = textureWidth / squaresPerRow;
            textureHeight -=  textureHeight % blockSize;
        }
        void GenerateNewAudience()
        {
            if (SceneStatics.seed != 0)
            {
                RNGSeed = SceneStatics.seed;
                audiencePresenceThreshold = SceneStatics.threshold;
            }
            FixWidthAndHeight();
            float[,] audienceMap = GenerateNoiseMap(textureWidth, textureHeight, RNGSeed, scale);
            
            int numColumns = squaresPerRow;
            int pixelsPerSquare = textureWidth / numColumns;
            int numRows = textureHeight / pixelsPerSquare;
            int[,] audiencePresenceMap = new int[numColumns, numRows];

            int blockCount = 0;
            for (int j = 0; j < numRows; j++)
            {
                for (int i = 0; i < numColumns; i++)
                {
                    blockCount++;
                    float sum = 0;
                    float count = 0;
                    for (int y = j * pixelsPerSquare; y < pixelsPerSquare + j * pixelsPerSquare; y++)
                    {
                        for (int x = i * pixelsPerSquare; x < pixelsPerSquare + i * pixelsPerSquare; x++)
                        {
                            sum += audienceMap[x, y];
                            count++;
                        }
                    }
                    float average = (sum / count) * 10 - 4;
                    if (average <= audiencePresenceThreshold)
                    {
                        audiencePresenceMap[i, j] = 1;
                    }
                    else
                    {
                        audiencePresenceMap[i, j] = 0;
                    }
                }
            }
            DrawTexture(TextureGenerator.TextureFromNoiseMap(audienceMap));
            SceneStatics.audiencePresence = audiencePresenceMap;
            GetComponent<DisplayAudience>().ShowAudience();
        }
        void DrawTexture(Texture2D texture)
        {
            textureRenderer.sharedMaterial.mainTexture = texture;
            textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        }

        public float[,] GenerateNoiseMap(int w, int h, int seed, float scale)
        {
            float[,] noiseMap = new float[w, h];

            System.Random seededRNG = new System.Random(seed);

            if (scale <= Mathf.Epsilon) scale = 0.001f;
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    float x = (i + seededRNG.Next(-100000, 100000)) / scale + offset.x;
                    float y = (j + seededRNG.Next(-100000, 100000)) / scale + offset.y;
                    float perlinValue = Mathf.PerlinNoise(x, y); // Can't use integers
                    perlinValue = Mathf.Clamp(perlinValue, minNoiseHeight, maxNoiseHeight);
                    noiseMap[i, j] = perlinValue;
                }
            }
            
            return noiseMap;
        }
        public int GetSeed()
        {
            return RNGSeed;
        }
        public void OnValidate()
        {
            audiencePresenceThreshold = Mathf.Clamp(audiencePresenceThreshold, 0, 1f);
            RNGSeed = Mathf.Clamp(RNGSeed, 0, 1000);
            squaresPerRow = Mathf.Clamp(squaresPerRow, 5, 20);
            if (textureWidth < squaresPerRow)
            {
                textureWidth = squaresPerRow;
            }
            if (textureHeight <= 2 * textureWidth/squaresPerRow)
            {
                textureHeight = 2 * textureWidth / squaresPerRow;
            }
        }
        public void Generate()
        {
            Debug.Log("Generating...");
            GenerateNewAudience();
        }
    }
}

