using UnityEngine;
using System.Collections;

namespace ProcGen
{
    public class DisplayAudience : MonoBehaviour
    {
        [SerializeField] GameObject[] audienceMembers;
        [SerializeField] float horizontalSpacing;
        [SerializeField] float verticalSpacing;
        
        [SerializeField] bool autoUpdate;
        [SerializeField] float updateTime;
        float time = 0;
        public void Start()
        {
            StartCoroutine(IniDelay());
        }
        public void Update()
        {
            if (time >= updateTime && autoUpdate == true)
            {
                ShowAudience();
                time = 0;
            }
            time += Time.deltaTime; 
        }
        public void ShowAudience()
        {
            DestroyAudience();

            System.Random seededRNG = new System.Random(GetComponent<NoiseTextureCreator>().GetSeed());

            int width = SceneStatics.audiencePresence.GetLength(0);
            int height = SceneStatics.audiencePresence.GetLength(1);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (SceneStatics.audiencePresence[i,j] == 1)
                    {
                        GameObject newAudienceMember = Instantiate(audienceMembers[seededRNG.Next(0, audienceMembers.Length)], transform);
                        float xWiggleRoom = seededRNG.Next(-10000, 10000) / 50000f;
                        float xOffset = (i - (width / 2f)) * horizontalSpacing + xWiggleRoom + horizontalSpacing/2f;
                        float yOffset = verticalSpacing * j;
                        if (j % 2 == 1) xOffset += .5f;
                        newAudienceMember.transform.position += new Vector3(xOffset, yOffset, j);
                    }
                }
            }
        }

        void DestroyAudience()
        {
            Debug.Log("DESTROY");
            var audience = FindObjectsOfType<AudienceMember>();
            foreach (AudienceMember member in audience)
            {
                Destroy(member.gameObject);
            }
        }

        IEnumerator IniDelay()
        {
            yield return new WaitForSeconds(1f);
            ShowAudience();
        }
    }
}

