using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private GameObject[] postProcessingVolumes;

    private void Start()
    {
        for (int i = 0; i < postProcessingVolumes.Length; i++)
        {
            postProcessingVolumes[i].SetActive(true);
        }
    }


}
