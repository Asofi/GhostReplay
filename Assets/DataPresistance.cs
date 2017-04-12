using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataPresistance : MonoBehaviour
{
    public static DataPresistance Instance;
    public Vector2[] LoadedPath;

    private void Awake()
    {
        Instance = this;
    }

    public void Save(Vector2[] Path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/FileName.dat", FileMode.Create);
        PlayerClass newData = new PlayerClass();
        newData.positions = Vector2ToSerializable(Path);
        bf.Serialize(file, newData);
        file.Close();
        print("Path saved to " + Application.persistentDataPath + "/FileName.dat");
    }

    public void Load()
    {

        if (File.Exists(Application.persistentDataPath + "/FileName.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/FileName.dat", FileMode.Open);
            PlayerClass newData = (PlayerClass)bf.Deserialize(file);
            file.Close();
            LoadedPath = SerializableToVector2(newData.positions);
        }
    }

    private Vector2Serializer[] Vector2ToSerializable(Vector2[] v2)
    {
        Vector2Serializer[] Serializer = new Vector2Serializer[v2.Length];
        for(int i = 0; i < v2.Length; i++)
        {
            Serializer[i].Fill(v2[i]);
        }
        return Serializer;
    }

    private Vector2[] SerializableToVector2(Vector2Serializer[] vs2)
    {
        Vector2[] v2 = new Vector2[vs2.Length];
        for (int i = 0; i < vs2.Length; i++)
        {
            v2[i] = vs2[i].V2;
        }
        return v2;
    }
}

[Serializable]
class PlayerClass
{
    public Vector2Serializer[] positions;
}

[Serializable]
public struct Vector2Serializer
{
    public float x;
    public float y;

    public void Fill(Vector2 v2)
    {
        x = v2.x;
        y = v2.y;
    }

    public Vector2 V2
    { get { return new Vector2(x, y); } }
}
