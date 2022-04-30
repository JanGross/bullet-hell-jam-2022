using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] tracks;
    public AudioClip highTensionClip;
    public int currentTrack = 0;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        //if track is finished play next track
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = tracks[currentTrack];
            GetComponent<AudioSource>().Play();
            currentTrack = (currentTrack + 1) % tracks.Length -1;
        }

        if (player.health <= 15 && GetComponent<AudioSource>().clip != highTensionClip)
        {
            GetComponent<AudioSource>().clip = highTensionClip;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }
    }
}
