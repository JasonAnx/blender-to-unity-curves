using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
struct BlenderCurvesCollection
{
    public Spline curves;
}

struct Spline
{
    [Newtonsoft.Json.JsonExtensionData]
    public Newtonsoft.Json.Linq.JObject _data;
}

public class BlenderSplineToDollyTrack : MonoBehaviour
{

    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void doJob(string path) {

        Dictionary<string, int[][]> curves = readJson();
        Debug.Log("all keys found: " + string.Join(',', curves.Keys));

        foreach (var curve in curves) { 
            CreateDollyTrack(curve.Value, curve.Key);
        }
    }

    private void CreateDollyTrack( int[][] points, string name) {
        var obj = new GameObject(name);
        var path = obj.AddComponent<Cinemachine.CinemachineSmoothPath>();
        path.m_Appearance.width = 5;
        path.m_Waypoints = new Cinemachine.CinemachineSmoothPath.Waypoint[points.Length];
        for (int i = 0; i < points.Length; i++) {
            path.m_Waypoints[i] = new Cinemachine.CinemachineSmoothPath.Waypoint();
            // blender's Z is unity's Y
            path.m_Waypoints[i].position = new Vector3( points[i][0], points[i][2], points[i][1]);
        }
    }

    private Dictionary<string, int[][]> readJson() {
        BlenderCurvesCollection res;

        Dictionary<string, int[][]> curves = new Dictionary<string, int[][]>();
        try {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            using (MemoryStream memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonFile.text)))
            using (StreamReader streamReader = new StreamReader(memoryStream))
            using (Newtonsoft.Json.JsonReader jsonReader = new Newtonsoft.Json.JsonTextReader(streamReader))
            res = serializer.Deserialize<BlenderCurvesCollection>(jsonReader);

            foreach (var curveData in res.curves._data.Properties()) {
                Debug.Log("== found data for curve " + curveData.Name);
                Debug.Log(curveData.Value);
                int[][] curvePoints = curveData.Value.ToObject<int[][]>();

                curves.Add(curveData.Name, curvePoints);
            }

        } catch (System.Exception e) {
            Debug.LogWarning(e);
            return null;
        }

        return curves;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
