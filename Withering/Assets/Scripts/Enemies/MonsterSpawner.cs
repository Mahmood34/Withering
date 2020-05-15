using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for spawning an Enemy or multiple enemies.
/// </summary>
public class MonsterSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING }
    /// A single monster Wave.
    public Wave[] waves;
    /// Integer pointing to the next Wave.
    private int nextWave = 0;
    /// Time between each Wave.
    public float timeBetweenWaves = 5f;
    /// Countdown for the next Wave to start.
    public float waveCountdown;
    /// Time for searching if any monsters are still present.
    private float searchCountdown = 1f;
    /// State of the current wave.
    private SpawnState state = SpawnState.COUNTING;
    /// Reference to the normal battle music.
    public AudioClip normalBattle;
    /// Reference to the normal battle music.
    public AudioClip bossBattle;
    /// Reference to the audio source.
    public AudioSource audioSource;

    /// <summary>
    /// Class that contains information of a Wave.
    /// </summary>
    //Change values of instance inside inspector
    [System.Serializable]
    public class Wave
    {
        /// Name of the Wave.
        public string name;
        /// A type of monster that can be spawned in.
        public Transform turtleShell;
        /// A type of monster that can be spawned in.
        public Transform slime;
        /// One of the bosses of the game.
        public Transform emeranBoss;
        /// One of the bosses of the game.
        public Transform ruboBoss;
        /// One of the bosses of the game.
        public Transform crystaBoss;
        /// Number of monsters in the Wave.
        public int count;
        /// Rate at which the monsters spawn in.
        public float rate;

    }

    void Start ()
    {
        waveCountdown = timeBetweenWaves;
        PlayerManager.instance.WarpPlayer (new Vector3 (0, 0, -10));
        audioSource = GetComponent<AudioSource> ();

    }

    /// <summary>
    /// Checks if the monsters are spawning or not.
    /// </summary>
    void Update ()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive ())
            {
                WaveCompleted ();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine (SpawnWave (waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Method for notifying the game when the Wave is complete.
    /// </summary>
    private void WaveCompleted ()
    {
        PlayerManager.instance.StopPlayerMovement();
        BattleManager.instance.ExitBattle ();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>If an enemy has been found or not.<returns>
    bool EnemyIsAlive ()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag ("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// IEnumerator for spawing a Wave and determining whether it is a boss battle or not.
    /// </summary>
    /// <param name="wave">The wave that contains the enemies to spawn.</param>
    IEnumerator SpawnWave (Wave wave)
    {
        state = SpawnState.SPAWNING;
        if (!BattleManager.isBossBattle)
        {
            wave.count = Random.Range (1, 4);
        }
        for (int i = 0; i < wave.count; i++)
        {
            switch (BattleManager.bossName)
            {
                case "EmeranBoss":
                    SpawnEnemy (wave.emeranBoss);
                    audioSource.clip = bossBattle;
                    break;
                case "RuboBoss":
                    SpawnEnemy (wave.ruboBoss);
                    audioSource.clip = bossBattle;
                    break;
                case "CrystaBoss":
                    SpawnEnemy (wave.crystaBoss);
                    audioSource.clip = bossBattle;
                    break;
                default:
                    if (Random.Range (0, 2) == 1)
                    {
                        SpawnEnemy (wave.turtleShell);
                    }
                    else
                    {
                        SpawnEnemy (wave.slime);
                    }
                    audioSource.clip = normalBattle;

                    break;
            }
            audioSource.Play ();

            yield return new WaitForSeconds (1f / wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    /// <summary>
    /// Spawn the Enemy.
    /// </summary>
    /// <param name="enemy">The enemy to spawn.</param>
    void SpawnEnemy (Transform enemy)
    {
        Debug.Log ("Spawning: " + enemy.name);
        Instantiate (enemy, new Vector3 (0, 0, 0), transform.rotation);
    }

}