using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathSaver : MonoBehaviour {

    public List<Vector2> Path = new List<Vector2>();

    public PathObject SavedPath;
    public Vector2[] BufferedPositions;

    public bool Record = false;
    public bool Played = false;

    public Transform FollowObject;
    public Transform Ghost;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Record = !Record;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Play());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Path.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Path.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DataPresistance.Instance.Save(Path.ToArray());
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(Record)
            Path.Add(FollowObject.transform.position);
	}

    public IEnumerator Play()
    {
        DataPresistance.Instance.Load();
        Vector2[] newPath = DataPresistance.Instance.LoadedPath;
        Ghost.gameObject.SetActive(true);
        for (int i = 0; i < newPath.Length; i++)
        {
            Ghost.transform.position = newPath[i];
            yield return new WaitForFixedUpdate();
        }
        Ghost.gameObject.SetActive(false);
    }
}


public struct TimedMove
{
    public TimedMove(Vector2 pos, float t)
    {
        position = pos;
        time = t;
    }

    public Vector2 position;
    public float time;
}

