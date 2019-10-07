using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//8:55pm oct.6
//9:35pm oct.6
public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject alien;
    public GameObject planet;
    public int numberOfAliens;
    public List<GameObject> aliens;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int lives;

    [SerializeField]
    private int score;

    public Text livesLabel;
    public Text scoreLabel;

    // PUBLIC PROPERTIES
    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;
            livesLabel.text = "Lives: " + lives.ToString();
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreLabel.text = "Score: " + score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneSetup();
    }

    /// <summary>
    /// this method setups up the UI and sound logic during the scenes startup
    /// </summary>
    private void SceneSetup()
    {
        activeSoundClip = SoundClip.SPACE;

        Lives = 7;
        Score = 0;

        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }

        // creates an empty container (list) of type GameObject
        aliens = new List<GameObject>();

        for (int alienNum = 0; alienNum < numberOfAliens; alienNum++)
        {
            aliens.Add(Instantiate(alien));
        }

        Instantiate(planet);
    }
}
