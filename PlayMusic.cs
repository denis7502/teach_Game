using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources;
    int index;
    int temp;
    bool Playing = true;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, 7);
        audioSources[index].Play();
        audioSources[index].volume = 0.12f;
        temp = index;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSources[index].isPlaying)
        {
            index = Random.Range(0, 7);
            if (index != temp)
            {
                audioSources[index].Play();
                audioSources[index].volume = 0.12f;
            }

            else
            {
                index = Random.Range(0, 7);
                audioSources[index].Play();
                audioSources[index].volume = 0.12f;

            }
        }
        if (Playing == false)
        {
            audioSources[index].Stop();
        }

    }
    public void StopPlay()
    {

        audioSources[index].Stop();
        Playing = false;
    }
}
