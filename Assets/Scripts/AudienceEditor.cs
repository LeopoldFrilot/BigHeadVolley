using ProcGen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudienceEditor : MonoBehaviour
{
    [SerializeField] Slider seedSlider;
    [SerializeField] Slider audiencePresenceMeter;
    public void Start()
    {
        seedSlider.value = Random.Range(1, 4);
        audiencePresenceMeter.value = Random.Range(.4f, 1f);
        SubmitToStatic();
    }
    public void SubmitToStatic()
    {
        Debug.Log("Changing...");
        SceneStatics.seed = (int)seedSlider.value;
        SceneStatics.threshold = audiencePresenceMeter.value;
        FindObjectOfType<NoiseTextureCreator>().Generate();
    }
}
