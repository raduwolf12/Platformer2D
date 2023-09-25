using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public string levelName;
    public float duration = 2f;
    public AudioClip WinAudioRepeating;
    public int Repeats;
    private int repeatCount;
    private float maxDuration;

    private void Start()
    {
        repeatCount = Repeats - 1;
        maxDuration = duration;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            StartCoroutine(WinFanfare());
        }
    }

    public IEnumerator WinFanfare()
    {
        while (duration > 0)
        {
            if (duration < maxDuration * repeatCount / Repeats)
            {
                AudioSource.PlayClipAtPoint(WinAudioRepeating, this.transform.position);
                repeatCount--;
            }
            
            duration -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(levelName);
    }
}
