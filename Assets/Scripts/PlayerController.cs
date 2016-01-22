using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text CountText;
    public Text WinText;
    
    private static PlayerController instance = null;
    public static PlayerController SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerController();
            }
            return instance;
        }
    }
    public Vector3 dir;
    private Rigidbody rb;
    private int licznik1, licznik2, licznik3, licznik4,licznik5;
    private bool szafa_P, szafa_L, licznikTV;
    private bool szafka2, szafka3, szafka4, drzwi1, drzwi2, wanna, kran;
    private Shader shader;
    public Material Lights, Lights_off;
    private CharacterController characterController;
	private string pomieszczenie;
    int action, place;
    public Vector3 velocity;
    public string turn;
    public Text Answer;
    public InputField field;
	public GameObject sound,sound2,sound3,sound4,sound5,sound6,stereo,
        Woda_kran, Woda, koldra_t, koldra_n, woda_kran_lazienka, tv, Stereo,
        lamp1, bath, Wardrobe_p, Wardrobe_l, tap, pokoj_dzienny, lazienka_wejscie, 
        lazienka_wyjscie, sypialnia_wejscie, sypialnia_wyjscie, fridge, Bed;
    public Button button;
    public Dictionary<string, string> dictionary, type ;
    public List<string> lista;
    string[] array = { "Kuchnia", "Salon", "Łazienka", "Sypialnia" };
    string[] array2 = { "kitchen", "dinnerroom", "bathroom", "bedroom", "corridor" };
    string[] diary;
    ArrayList True;
    ArrayList False;
    int i;
    public string destination;

    private bool active,KnowWhatToDo;

    void toDiary()
    {
        diary = new string[] { };
        string input = field.text;
        string[] delimiters = new string[] { " i ", ", ", "oraz",". " };
        diary = input.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
        //diary = input.Split(',');
        System.Array.Reverse(diary);
        i = diary.Length;
    }
    void LoadDictionary()
    {

        dictionary.Add("idź", "move"); type.Add("idź", "action");
        dictionary.Add("idz", "move"); type.Add("idz", "action");
        dictionary.Add("podejdź", "move"); type.Add("podejdź", "action");
        dictionary.Add("podjedź", "move"); type.Add("podjedź", "action");
        dictionary.Add("włącz", "on"); type.Add("włącz", "action");
        dictionary.Add("wyłącz", "off"); type.Add("wyłącz", "action");
        dictionary.Add("puść", "on"); type.Add("puść", "action");
        dictionary.Add("muzykę", "Stereo"); type.Add("muzykę", "object");
        dictionary.Add("zapal", "on"); type.Add("zapal", "action");
        dictionary.Add("zgaś", "off"); type.Add("zgaś", "action");
        dictionary.Add("kuchni", "kitchen"); type.Add("kuchni", "place");
        dictionary.Add("sypialni", "bedroom"); type.Add("sypialni", "place");
        dictionary.Add("łazienki", "bathroom"); type.Add("łazienki", "place");
        dictionary.Add("korytarz", "corridor"); type.Add("korytarz", "place");
        dictionary.Add("łazience", "bathroom"); type.Add("łazience", "place");
        dictionary.Add("salonu", "dinnerroom"); type.Add("salonu", "place");
        dictionary.Add("wanny", "Bath"); type.Add("wanny", "object");
        dictionary.Add("wanne", "Bath"); type.Add("wanne", "object");
        dictionary.Add("napełnij", "on"); type.Add("napełnij", "action");
        dictionary.Add("opróźnij", "off"); type.Add("opróźnij", "action");
        dictionary.Add("umywalkę", "Washbasin"); type.Add("umywalkę", "object");
        dictionary.Add("telewizor", "TV"); type.Add("telewizor", "object");
        dictionary.Add("tv", "TV"); type.Add("tv", "object");
        dictionary.Add("lampę", "Lampa"); type.Add("lampę", "object");
        dictionary.Add("lampe w salonie", "Lampa3"); type.Add("lampe w salonie", "object");
        dictionary.Add("lampe w łazience", "Lampa2"); type.Add("lampe w łazience", "object");
        dictionary.Add("lampe w sypialni", "Lampa4"); type.Add("lampe w sypialni", "object");
        dictionary.Add("lampe na korytarzu", "Lampa1"); type.Add("lampe na korytarzu", "object");
        dictionary.Add("lampa", "lamp"); type.Add("lampa", "object");
        dictionary.Add("wieże", "Stereo"); type.Add("wieże", "object");
        dictionary.Add("wieży", "Stereo"); type.Add("wieży", "object");
        dictionary.Add("drugą", "second"); type.Add("drugą", "number");
        dictionary.Add("trzecią", "third"); type.Add("trzecią", "number");
        dictionary.Add("czwartą", "fourth"); type.Add("czwartą", "number");
        dictionary.Add("otwórz", "open"); type.Add("otwórz", "action");
        dictionary.Add("zamknij", "close"); type.Add("zamknij", "action");
        dictionary.Add("lodówki", "Fridge"); type.Add("lodówki", "object");
        dictionary.Add("lodówke", "Fridge"); type.Add("lodówke", "object");
        dictionary.Add("lampy", "lamp"); type.Add("lampy", "object");
        dictionary.Add("światło", "light"); type.Add("światło", "object");
        dictionary.Add("drzwi", "doors"); type.Add("drzwi", "object");
        dictionary.Add("stołu", "table"); type.Add("stołu", "object");
        dictionary.Add("stół", "table"); type.Add("stół", "object");
        dictionary.Add("szafy", "wardrobe"); type.Add("szafy", "object");
        dictionary.Add("szafe", "wardrobe"); type.Add("szafe", "object");
        dictionary.Add("sprawdź", "check"); type.Add("sprawdź", "action");
        dictionary.Add("pogodę", "weather"); type.Add("pogodę", "object");
        dictionary.Add("wróć", "go back"); type.Add("wróć", "action");
        // dictionary.Add("stereo", "Stereo"); type.Add("stereo", "object");
    }
    void Start()
    {
        pomieszczenie = "Korytarz";
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        WinText.text = "";
        licznik1 = 0;
        licznik2 = 0;
        licznik3 = 0;
        licznik4 = 0;
        licznik5 = 0;
        turn = "";
        szafa_P = true;
        szafa_L = true;
        KnowWhatToDo = false;
        dir = new Vector3();
        dictionary = new Dictionary<string, string>();
        type = new Dictionary<string, string>();
        False = new ArrayList();
        True = new ArrayList();
        FalseAdd();

        LoadDictionary();

    }

    void FalseAdd()
    {
        False.Add("Bath");
        //False.Add("Lampa1");
        False.Add("Washbasin");
        False.Add("TV");
        False.Add("Stereo");
        False.Add("Lampa-Korytarz");
        False.Add("Lampa-Salon");
        False.Add("Lampa-Kuchnia");
        False.Add("Lampa-Łazienka");
        False.Add("Lampa-Sypialnia");
    }  
    void WhatToDo()
    {
        // w tej funkcji rozklada zdanie na wyrazy które rozumie, zlicza ilość czasowników, i do listy dodaje rozpoznane obiekty
        action = 0;
        lista = new List<string>();

        string s = diary[i-1];
        
        string[] words = s.Split(' ');
        foreach (string word in words)
        {
            string LowerWord = word.ToLower();
            if (dictionary.ContainsKey(LowerWord))
            {
                //WinText.text += dictionary[LowerWord];
                if (type[LowerWord] == "action")
                {
                    action += 1;
                    if (dictionary[LowerWord] == "on")
                    {
                        turn = "on";
                    }
                    else
                    {
                        if (dictionary[LowerWord] == "off")
                        {
                            turn = "off";
                        }
                    }
                }
                else
                {
                    if(dictionary[LowerWord] == "Lampa")
                    {
                        lista.Add("Lampa-" + pomieszczenie);
                    }
                    else
                    {
                        lista.Add(dictionary[LowerWord]);
                    }
                    
                }
            }
        }
        if(action >=1 && lista.Count > 0)
        {
            if (turn == "")
            {
                KnowWhatToDo = true;
                sound6.GetComponent<AudioSource>().Play();
            } 
            if (turn == "on")
            {
                if (False.Contains(lista.First()))
                {
                    KnowWhatToDo = true;
                    sound6.GetComponent<AudioSource>().Play();
                }
                else
                {
                    WinText.text = "Sir, już włączone.";
                    i = i - 1;
                    turn = "";
                }
            }
            if (turn == "off")
            {
                if (True.Contains(lista.First()))
                {
                    KnowWhatToDo = true;
                    sound6.GetComponent<AudioSource>().Play();
                }
                else
                {
                    WinText.text = "Sir, już wyłączone.";
                    i = i - 1;
                    turn = "";
                }
            }
            //KnowWhatToDo = true;
            //sound6.GetComponent<AudioSource>().Play();
            //active = true;
        }
        else
        {
            HaveNoIdea();
            i = i - 1;
        }
        
        field.text = "";
    }
    void Change()
    {
        if (False.Contains(lista.First()))
        {

            True.Add(lista.First());
            False.Remove(lista.First());
        }

        else
        {
            if (True.Contains(lista.First()))
            {
                False.Add(lista.First());
                True.Remove(lista.First());
            }
        }
    }
    void Do()
    {
               move2(lista.First());                 
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
      
        if(i>0 && KnowWhatToDo)
        {
                Do();
        }
        else
        {
            if (i > 0)
            {
                WhatToDo();
            }
            else
            {            
             if (Input.GetKeyUp(KeyCode.Return))
                {
                    //wprowadza do dziennika wszystkie zadania do wykonania
                    toDiary();
                }
            }
        }

        // Tu są dodatkowe ficzery - kamera z pierwszej osoby i latarka pod F1 i F2
        if (Input.GetKeyUp(KeyCode.F2))
        {
            if (GameObject.FindGameObjectWithTag("Eye2").GetComponent<Light>().enabled.Equals(true))
            {
                WinText.text = "";
                GameObject.FindGameObjectWithTag("Eye2").GetComponent<Light>().enabled = false;
            }
            else
            {
                WinText.text = "";
                GameObject.FindGameObjectWithTag("Eye2").GetComponent<Light>().enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (GameObject.FindGameObjectWithTag("Eye").GetComponent<Camera>().enabled.Equals(true))
            {
                WinText.text = "";
                GameObject.FindGameObjectWithTag("Eye").GetComponent<Camera>().enabled = false;
            }
            else
            {
                WinText.text = "";
                GameObject.FindGameObjectWithTag("Eye").GetComponent<Camera>().enabled = true;
            }
        }
    }
    void RandomSound()
    {
        int number = Random.Range(1, 5);
        if (number == 1)
        {
            sound.GetComponent<AudioSource>().Play();
        }
        else
        {
            if (number == 2)
            {
                sound2.GetComponent<AudioSource>().Play();
            }
            else
            {
                if (number == 3)
                {
                    sound3.GetComponent<AudioSource>().Play();
                }
                else
                {
                    if (number == 4)
                    {
                        sound4.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        sound5.GetComponent<AudioSource>().Play();
                    }
                }
            }
        }

    }
    void HaveNoIdea()
    {
        sound5.GetComponent<AudioSource>().Play();
    }
    void OnCollisionEnter(Collision other)
    {

        if (KnowWhatToDo)
        {
            if (other.gameObject.CompareTag("Lampa-Łazienka"))
            {
                RandomSound();
                if (licznik1 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik1 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik1 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Lampa-Korytarz"))
            {
                RandomSound();
                if (licznik2 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik2 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik2 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Lampa-Salon"))
            {
                RandomSound();
                if (licznik3 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik3 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik3 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Lampa-Sypialnia"))
            {
                RandomSound();
                if (licznik4 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik4 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik4 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Lampa-Kuchnia"))
            {
                RandomSound();
                if (licznik5 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik5 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik5 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Lampa1"))
            {
                RandomSound();
                if (licznik1 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik1 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik1 = 0;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }

            if (other.gameObject.CompareTag("Lampa2"))
            {
                RandomSound();
                if (licznik2 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik2 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik2 = 0;
                }
                active = false;
                KnowWhatToDo = false;
            }
            if (other.gameObject.CompareTag("Lampa3"))
            {
                RandomSound();
                if (licznik3 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik3 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik3 = 0;
                }
                active = false;
                KnowWhatToDo = false;
            }
            if (other.gameObject.CompareTag("Lampa4"))
            {
                RandomSound();
                if (licznik4 == 0)
                {
                    // shader = Shader.Find("Unlit/Transparent");
                    // other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights;
                    //other.transform.GetComponent<Renderer>().material.color = Color.yellow;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznik4 = 1;
                }
                else
                {
                    //shader = Shader.Find("Standard");
                    //other.transform.GetComponent<Renderer>().material.shader = shader;
                    other.transform.GetComponent<Renderer>().material = Lights_off;
                    //other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznik4 = 0;
                }
                active = false;
                KnowWhatToDo = false;
            }
            if (other.gameObject.CompareTag("Wardrobe_R"))
            {
                if (szafa_P == false)
                {
                    other.transform.Rotate(0, 90, 0);
                    other.transform.Translate(+0.6f, 0f, -0.6f);
                    szafa_P = true;
                }
                else if (szafa_P == true)
                {
                    other.transform.Rotate(0, 270, 0);
                    other.transform.Translate(+0.6f, 0f, +0.6f);
                    szafa_P = false;
                }
            }
            if (other.gameObject.CompareTag("Wardrobe_L"))
            {
                if (szafa_L == false)
                {
                    other.transform.Rotate(0, 90, 0);
                    other.transform.Translate(+0.6f, 0f, +0.6f);
                    szafa_L = true;
                }
                else if (szafa_L == true)
                {
                    other.transform.Rotate(0, 270, 0);
                    other.transform.Translate(-0.6f, 0f, +0.6f);
                    szafa_L = false;
                }
            }
            if (other.gameObject.CompareTag("TV"))
            {
                if (licznikTV == false)
                {
                    other.transform.GetComponent<Renderer>().material.color = Color.white;
                    other.gameObject.GetComponent<Light>().enabled = true;
                    licznikTV = true;
                }
                else if (licznikTV == true)
                {
                    other.transform.GetComponent<Renderer>().material.color = Color.black;
                    other.gameObject.GetComponent<Light>().enabled = false;
                    licznikTV = false;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Stereo"))
            {
                if (False.Contains("Stereo"))
                {
                    stereo.GetComponent<AudioSource>().Play();
                }
                else
                {
                    stereo.GetComponent<AudioSource>().Stop();
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Cupboard2"))
            {

                if (szafka2 == false)
                {
                    other.transform.Translate(0, 0, -0.4f);
                    szafka2 = true;
                }
                else
                {
                    other.transform.Translate(0, 0, 0.4f);
                    szafka2 = false;
                }
            }
            if (other.gameObject.CompareTag("Cupboard3"))
            {

                if (szafka3 == false)
                {
                    other.transform.Translate(0, 0, -0.4f);
                    szafka3 = true;
                }
                else
                {
                    other.transform.Translate(0, 0, 0.4f);
                    szafka3 = false;
                }
            }
            if (other.gameObject.CompareTag("Cupboard4"))
            {

                if (szafka4 == false)
                {
                    other.transform.Translate(0, 0, -0.4f);
                    szafka4 = true;
                }
                else
                {
                    other.transform.Translate(0, 0, 0.4f);
                    szafka4 = false;
                }
            }
            if (other.gameObject.CompareTag("Bath"))
            {
                if (wanna == false)
                {
                    Woda_kran.gameObject.SetActive(true);
                    Woda.gameObject.SetActive(true);
                    Woda.transform.Translate(0, +0.3f, 0);
                    wanna = true;
                }
                else if (wanna == true)
                {
                    Woda_kran.gameObject.SetActive(false);
                    Woda.gameObject.SetActive(false);
                    Woda.transform.Translate(0, -0.3f, 0);
                    wanna = false;
                }
                active = false;
                KnowWhatToDo = false;

                turn = "";
                i = i - 1;
                Change();
            }
            if (other.gameObject.CompareTag("Door1"))
            {
                Debug.Log("dotknelem drzwi");
                if (drzwi1 == false)
                {
                    other.transform.Rotate(0, 90, 0);
                    other.transform.Translate(-0.8f, 0f, +0.85f);
                    drzwi1 = true;
                }
                else if (drzwi1 == true)
                {
                    other.transform.Rotate(0, 270, 0);
                    other.transform.Translate(-0.85f, 0f, -0.8f);
                    drzwi1 = false;
                }
            }
            if (other.gameObject.CompareTag("Door2"))
            {
                Debug.Log("dotknelem drzwi");
                if (drzwi2 == false)
                {
                    other.transform.Rotate(0, 90, 0);
                    other.transform.Translate(-0.8f, 0f, +0.85f);
                    drzwi2 = true;
                }
                else if (drzwi2 == true)
                {
                    other.transform.Rotate(0, 270, 0);
                    other.transform.Translate(-0.85f, 0f, -0.8f);
                    drzwi2 = false;
                }
            }
            /*
            if (other.gameObject.CompareTag("Coverlet on"))
            {
                other.gameObject.SetActive(false);
                koldra_n.gameObject.SetActive(true);
            }
            if (other.gameObject.CompareTag("Coverlet off"))
            {
                other.gameObject.SetActive(false);
                koldra_t.gameObject.SetActive(true);
            } */
            if (other.gameObject.CompareTag("Washbasin"))
            {
                Debug.Log("to kran");
                if (kran == false)
                {
                    woda_kran_lazienka.gameObject.SetActive(true);
                    kran = true;
                }
                else if (kran == true)
                {
                    woda_kran_lazienka.gameObject.SetActive(false);
                    kran = false;
                }
                active = false;
                KnowWhatToDo = false;
                turn = "";
                Change();
            }
            if (other.gameObject.CompareTag("kitchen") && destination.Equals("kitchen"))
            {
                RandomSound();
                active = false;
                KnowWhatToDo = false;
                destination = "";
                i = i - 1;
            }
            if (other.gameObject.CompareTag("corridor") && destination.Equals("corridor"))
            {
                RandomSound();
                active = false;
                KnowWhatToDo = false;
                destination = "";
                i = i - 1;
            }
            if (other.gameObject.CompareTag("bedroom") && destination.Equals("bedroom"))
            {
                RandomSound();
                active = false;
                KnowWhatToDo = false;
                destination = "";
                i = i - 1;
            }
            if (other.gameObject.CompareTag("bathroom") && destination.Equals("bathroom"))
            {
                RandomSound();
                active = false;
                KnowWhatToDo = false;
                destination = "";
                i = i - 1;
            }
            if (other.gameObject.CompareTag("dinnerroom") && destination.Equals("dinnerroom"))
            {
                RandomSound();
                active = false;
                KnowWhatToDo = false;
                destination = "";
                i = i - 1;
            }
        }
    }
    void move()
    {
		/*
        if (field.text != "witam")
        {
            Answer.text = "";
        }
        if (field.text == "witam")
        {
            Answer.text = "Witaj";
        }
        if (field.text == "naprzód")
        {
            //transform.position += Vector3.forward * Time.deltaTime;
            characterController.Move(Vector3.forward * Time.deltaTime * 5);
        }

        if (field.text == "wstecz")
        {
            //transform.position += Vector3.back * Time.deltaTime;
            characterController.Move(Vector3.back * Time.deltaTime * 5);
        }

        if (field.text == "prawo")
        {
            //transform.position += Vector3.right * Time.deltaTime;
            characterController.Move(Vector3.right * Time.deltaTime * 5);
        }

        if (field.text == "lewo")
        {
            //transform.position += Vector3.left * Time.deltaTime;
            characterController.Move(Vector3.left * Time.deltaTime * 5);

        } */

		if (field.text.Equals("lamp1"))
        {
			Vector3 direction2 = lamp1.transform.position - transform.position;
			if(Vector3.Magnitude(direction2) > 1)
			{
			rb.AddForceAtPosition(direction2*3, lamp1.transform.position);
			}
		} 

		if (field.text.Equals("tv"))
		{
			if(pomieszczenie.Equals("korytarz"))
			   {
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
				rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}

				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "pokoj dzienny";
					WinText.text = pomieszczenie;
				}


			}
		
			if(pomieszczenie.Equals("pokoj dzienny"))
				{
					Vector3 direction2 = tv.transform.position - transform.position;
					if(Vector3.Magnitude(direction2) > 1)
			   		{
						rb.AddForceAtPosition(direction2*3, tv.transform.position);
					}

					if(Vector3.Magnitude(direction2) < 2)
				   	{
						tv.transform.GetComponent<Renderer>().material.color = Color.white;
						tv.gameObject.GetComponent<Light>().enabled = true;
						licznikTV = true;
						
					}
					else 
					{
					tv.transform.GetComponent<Renderer>().material.color = Color.black;
					tv.gameObject.GetComponent<Light>().enabled = false;
					licznikTV = false;
					}
			}

			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction = lazienka_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("sypialnia"))
			{
				Vector3 direction = sypialnia_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4, sypialnia_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
			}

		
		}

		if (field.text.Equals("lodówka"))
		{
			if(pomieszczenie.Equals("korytarz"))
			   {
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
				rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}

				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "pokoj dzienny";
					WinText.text = pomieszczenie;
				}


			}
		
			if(pomieszczenie.Equals("pokoj dzienny"))
				{
					Vector3 direction2 = fridge.transform.position - transform.position;
					if(Vector3.Magnitude(direction2) > 1)
			   		{
						rb.AddForceAtPosition(direction2*3, fridge.transform.position);
					}
				}

			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction = lazienka_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("sypialnia"))
			{
				Vector3 direction = sypialnia_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4, sypialnia_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
			}

		
		}

		if (field.text.Equals("wanna"))
		{
			if(pomieszczenie.Equals("korytarz"))
			{
				Vector3 direction = lazienka_wejscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wejscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "lazienka";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction2 = bath.transform.position - transform.position;
				if(Vector3.Magnitude(direction2) > 1)
				{
					rb.AddForceAtPosition(direction2*3, bath.transform.position);
				}
			}

			if(pomieszczenie.Equals("pokoj dzienny"))
			{
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("sypialnia"))
			{
				Vector3 direction = sypialnia_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4, sypialnia_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 2)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
			}

		}

		if (field.text.Equals("kran"))
		{
			if(pomieszczenie.Equals("korytarz"))
			{
				Vector3 direction = lazienka_wejscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wejscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "lazienka";
					WinText.text = pomieszczenie;
				}
				
				
			}
			
			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction2 = tap.transform.position - transform.position;
				if(Vector3.Magnitude(direction2) > 1)
				{
					rb.AddForceAtPosition(direction2*3, tap.transform.position);
				}
			}
			
			if(pomieszczenie.Equals("pokoj dzienny"))
			{
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 2)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("sypialnia"))
			{
				Vector3 direction = sypialnia_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4, sypialnia_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 1)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}

			}
			
		}

		if (field.text.Equals ("szafa")) {
			if (pomieszczenie.Equals ("korytarz")) {
				Vector3 direction = sypialnia_wejscie.transform.position - transform.position;
				if (Vector3.SqrMagnitude (direction) > 1) {
					rb.AddForceAtPosition (direction * 4, sypialnia_wejscie.transform.position);
				}
				
				if (Vector3.SqrMagnitude (direction) < 2) {
					pomieszczenie = "sypialnia";
					WinText.text = pomieszczenie;
				}
			}

			if (pomieszczenie.Equals ("sypialnia")) {
				Vector3 direction2 = Wardrobe_p.transform.position - transform.position;

				if (Vector3.Magnitude (direction2) > 1) {
					rb.AddForceAtPosition (direction2 * 3, Wardrobe_p.transform.position);
				}
			}

			if(pomieszczenie.Equals("pokoj dzienny"))
			{
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}

			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction = lazienka_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 2)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}
		}

		if (field.text.Equals ("łóżko")) {
			if (pomieszczenie.Equals ("korytarz")) {
				Vector3 direction = sypialnia_wejscie.transform.position - transform.position;
				if (Vector3.SqrMagnitude (direction) > 1) {
					rb.AddForceAtPosition (direction * 4, sypialnia_wejscie.transform.position);
				}
				
				if (Vector3.SqrMagnitude (direction) < 2) {
					pomieszczenie = "sypialnia";
					WinText.text = pomieszczenie;
				}
			}


			if (pomieszczenie.Equals ("sypialnia")) {
				Vector3 direction2 = Bed.transform.position - transform.position;
				
				if (Vector3.Magnitude (direction2) > 1) {
					rb.AddForceAtPosition (direction2 * 3, Bed.transform.position);
				}

				if(Vector3.Magnitude (direction2) < 2)
				{
					koldra_n.gameObject.SetActive(true);
					koldra_t.gameObject.SetActive(false);
				}
				else
				{
					koldra_n.gameObject.SetActive(false);
					koldra_t.gameObject.SetActive(true);
				}
			}
			else
			{
				koldra_n.gameObject.SetActive(false);
				koldra_t.gameObject.SetActive(true);
			}
			
			if(pomieszczenie.Equals("pokoj dzienny"))
			{
				Vector3 direction = pokoj_dzienny.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,pokoj_dzienny.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 3)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}
				
				
			}
			
			if(pomieszczenie.Equals("lazienka"))
			{
				Vector3 direction = lazienka_wyjscie.transform.position - transform.position;
				if(Vector3.SqrMagnitude(direction) > 1)
				{
					rb.AddForceAtPosition(direction * 4,lazienka_wyjscie.transform.position);
				}
				
				if(Vector3.SqrMagnitude(direction) < 2)
				{
					pomieszczenie = "korytarz";
					WinText.text = pomieszczenie;
				}							
			}
		}
    }
    void move2(string where)
    {
        if (array2.Contains(where)) { destination = where;  }

        if (pomieszczenie.Equals(GameObject.FindGameObjectWithTag(where).transform.parent.tag))
        {
            Vector3 direction = GameObject.FindGameObjectWithTag(where).transform.position - transform.position;
            if (Vector3.Magnitude(direction) > 1)
            {
                rb.AddForceAtPosition(direction * 5, GameObject.FindGameObjectWithTag(where).transform.position);
            }
            dir = direction;
        }
        else {
            if (array.Contains(pomieszczenie) && array.Contains(GameObject.FindGameObjectWithTag(where).transform.parent.tag))
            {
                Vector3 direction = GameObject.FindGameObjectWithTag("Korytarz-"
                    + pomieszczenie).transform.position - transform.position;
                if (Vector3.Magnitude(direction) > 1)
                {
                    rb.AddForceAtPosition(direction * 5,
                   GameObject.FindGameObjectWithTag("Korytarz-"
                    + pomieszczenie).transform.position);
                }
                if (Vector3.SqrMagnitude(direction) < 3)
                {
                    pomieszczenie = "Korytarz";
                }
                dir = direction;
            }
            else
            {
                Vector3 direction = GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag(where).transform.parent.tag +
                  "-" + pomieszczenie).transform.position - transform.position;
                if (Vector3.Magnitude(direction) > 1)
                {
                    rb.AddForceAtPosition(direction * 5,
                   GameObject.FindGameObjectWithTag(GameObject.FindGameObjectWithTag(where).transform.parent.tag +
                   "-" + pomieszczenie).transform.position);
                }
                if (Vector3.SqrMagnitude(direction) < 3)
                {
                    pomieszczenie = GameObject.FindGameObjectWithTag(where).transform.parent.tag;
                }
                dir = direction;
            }
        }
    }   
    }
