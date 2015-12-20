using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;
    private int licznik1, licznik2, licznik3, licznik4;
    private bool szafa_P, szafa_L, licznikTV;
    private bool szafka2, szafka3, szafka4, drzwi1, drzwi2, wanna, kran;
    private Shader shader;
    public Material Lights, Lights_off;
    private CharacterController characterController;
	private string pomieszczenie;

    public Vector3 velocity;
    public Text Answer;
    public InputField field;
	public GameObject Woda_kran, Woda, koldra_t, koldra_n, woda_kran_lazienka, tv, lamp1, bath, Wardrobe_p, Wardrobe_l, tap, pokoj_dzienny, lazienka_wejscie, lazienka_wyjscie, sypialnia_wejscie, sypialnia_wyjscie, fridge, Bed;
	public Button button;


    void Start()
    {
		pomieszczenie = "korytarz";
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
        licznik1 = 1;
        licznik2 = 1;
        licznik3 = 1;
        licznik4 = 1;
        szafa_P = true;
        szafa_L = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        move();
    }

    void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("Lampa1"))
        {

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
        }

        if (other.gameObject.CompareTag("Lampa2"))
        {
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
        }
        if (other.gameObject.CompareTag("Lampa3"))
        {
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
        }
        if (other.gameObject.CompareTag("Lampa4"))
        {
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
            if ( kran == false)
            {
                woda_kran_lazienka.gameObject.SetActive(true);
                kran = true;
            }
            else if (kran == true)
            {
                woda_kran_lazienka.gameObject.SetActive(false);
                kran = false;
            }
        }

		/*if(other.gameObject.CompareTag("Dayili Room"))
		   {
			if(field.text.Equals("tv") || field.text.Equals("lodówka"))
			{
			pomieszczenie = "pokoj dzienny";

			}
			else
			{
				//pomieszczenie = "korytarz";
			}
		} */

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Ups"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You Win!";
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
			//Vector3 direction = trigger1.transform.position - transform.position;
				//rb.AddReleviantForce(direction, transform.position);
				//rb.AddRelativeForce(trigger1.transform.position);
				//rb.AddForceAtPosition(trigger1.transform.position, transform.position);
			//rb.AddForceAtPosition(direction, trigger1.transform.position);

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
				//if (licznikTV == true)
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
}