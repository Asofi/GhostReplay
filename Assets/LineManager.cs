using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

    public GameObject linePrefab;
    Line activeLine;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject LineGO =  Instantiate(linePrefab);
            activeLine = LineGO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
            activeLine = null;

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }

	}
}
