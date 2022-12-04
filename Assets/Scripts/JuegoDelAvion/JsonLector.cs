using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonLector : MonoBehaviour
{
    QuizData data;
    string jsonPath = "Assets/JsonPrueba.json"; //

    private void Start()
    {
        //Lee el archivo Json
        string jsonString = File.ReadAllText(jsonPath);
        data = JsonUtility.FromJson<QuizData>(jsonString);
        Debug.Log(data.clientP[0].name); //Test
    }
}

[System.Serializable]
public class QuizPregunta
{
    public string preg;
    public string tipoP;
    public int idP;
    public int orden;
    public bool examen;
    public int idtask;
    public Quiz(string _preg, string _tipoP, int _idP, int _orden, bool _examen, int _idtask)
    {
        preg = _preg;
        tipoP = _tipoP;
        idP = _idP;
        orden = _orden;
        examen = _examen;
        idtask = _idtask;
    }
}

[System.Serializable]
public class QuizData
{
    public List<QuizPregunta> clientP;
}
