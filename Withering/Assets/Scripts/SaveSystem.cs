using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Class for handling saving and loading of PlayerData
/// </summary>
public static class SaveSystem
{

    /// <summary>
    /// Serialize PlayerData into a binary file and save it to a file in a persistent data path.
    /// </summary>
    /// <param name="player">The player holding the player data to save.</param> 
    public static void SavePlayer (Player player)
    {
        string path = Application.persistentDataPath + "/player.save";
        BinaryFormatter formatter = new BinaryFormatter ();
        FileStream stream = new FileStream (path, FileMode.Create);

        PlayerData data = new PlayerData (player);

        formatter.Serialize (stream, data);
        stream.Close ();
    }

    /// <summary>
    /// Returns a PlayerData object to be loaded into the game.
    /// </summary>
    /// <returns> 
    /// PlayerData.
    /// </returns>
    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists (path))
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream (path, FileMode.Open);

            PlayerData data = formatter.Deserialize (stream) as PlayerData;
            stream.Close ();

            return data;
        }
        else
        {
            Debug.LogError ("Save file not found in" + path);
            return null;
        }
    }

    /// <summary>
    /// Checks if a save exists.
    /// </summary>
    /// <returns> 
    /// True if file exists.
    /// </returns>
    public static bool checkIfSaveExists ()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists (path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}