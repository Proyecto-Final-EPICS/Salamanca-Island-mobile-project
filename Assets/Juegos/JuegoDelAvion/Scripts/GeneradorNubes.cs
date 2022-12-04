using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GeneradorNubes : MonoBehaviour
{

    public float tiempoMax = 12;
    public float tiempoInicial = 0;
    public GameObject nubesF1;
    public TMP_Text textoNubePregunta;
    List<TMP_Text> textoNubes = new List<TMP_Text>();
    List<Pregunta> Preguntas = new List<Pregunta>();
    private string JsonText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject nubes = Instantiate(nubesF1);
        Destroy(nubes, 18);
        StartCoroutine(GetPreguntas());

    }

    // Update is called once per frame
    void Update()
    {
        
        if (tiempoInicial > tiempoMax)
        {
            GameObject nubes = Instantiate(nubesF1);
            Destroy(nubes, 18);
            tiempoInicial = 0;
            SacarPregunta();
        }
        else
        {
            tiempoInicial += Time.deltaTime;
        }
    }

    public void SacarPregunta(){
        //JsonText = File.ReadAllText(Application.dataPath + "/Scripts/JuegoDelAvion/JsonPrueba.json");
        textoNubes.Clear();
        GetPreguntas();
    }

    IEnumerator GetPreguntas()
    {
        string json;
        UnityWebRequest request = UnityWebRequest.Get("https://epics-si-api.onrender.com/api/task/1/pregunta/2");
        yield return request.SendWebRequest();

        print(request.isNetworkError);
        if (request.isNetworkError)
        {
            //falta mostrar en pantalla
            Debug.Log(request.error);
            print(request.error);
        }
        else
        {
            string content = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
            Preguntas = JsonConvert.DeserializeObject<List<Pregunta>>(content);
            Debug.Log(Preguntas);
            print(Preguntas);

        }
    }


}

public class Pregunta{
    public int id_pregunta;
    public string pregunta;
    public Object imagen;
    public Object audio;
    public Object video;
    public string retroalimentacion;
    public string tipo;
    public bool examen;
    public int orden;
    public int id_task;
    List<respuestas> textoNubes = new List<respuestas>();
}

public class respuestas{
    public int id_respuesta;
    public string contenido;
    public bool correcta;
    public int id_pregunta;
}
