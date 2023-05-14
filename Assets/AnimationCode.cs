using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;

public class AnimationCode : MonoBehaviour
{

    public GameObject[] Body;
    List<string> lines;
    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        // lines = System.IO.File.ReadLines("Assets/AnimationFile.txt").ToList();
        // lines = System.IO.File.ReadLines("Assets/AnimationFileCrime2.txt").ToList();
        lines = System.IO.File.ReadLines("Assets/AnimationFileCrimePerson1.txt").ToList();


    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(lines[counter]))
        {
            print(lines[counter]);
            string[] points = lines[counter].Split(',');

            for (int i =0; i<=32;i++)
            {
                float x = float.Parse(points[0 + (i * 3)]) / 100;
                float y = float.Parse(points[1 + (i * 3)]) / 100;
                float z = float.Parse(points[2 + (i * 3)]) / 300;
                Body[i].transform.localPosition = new Vector3(x, y, z);
            }
        }
        else
        {
            for (int i =0; i<=32;i++)
            {
                Body[i].transform.localPosition = new Vector3(-1000, 0, -1000);
            }
        }

  
        counter += 1;
        if (counter == lines.Count) { counter = 0; }
        // Thread.Sleep(30);
    }
}
