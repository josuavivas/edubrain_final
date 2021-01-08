using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    [SerializeField]
    private Sprite bgImage;
   


    public List<Button> btns = new List<Button>();
    public List<Sprite> game_imgs = new List<Sprite>();
    

    public Sprite[] imgs;
    public int firs,rando,count_correct,imx,ind;
    public bool result;
    private int countg=0;
    private string fir, seco;
    private bool state_game,esta;
    
    public int nivel=1;

    public GameObject menu_fin;
    public GameObject menu_pausa;
    public GameObject btn_pausa1;
    public Text txt_tiempo;

    public float tiempo=10f;
    

    void Awake()
    {
        
        imgs = Resources.LoadAll<Sprite>("Sprites/numeros");
    }

    
    // Use this for initialization
    void Start()
    {
        tiempo=5;
        getButtons();
        AddLIsteners();
        Shuffle(btns);
        show();
        
        rando=22;
        

        btns[rando].image.sprite = imgs[imx];
        seco=btns[rando].name;
    }

    public void Update() 
    {
        
        tiempo -=Time.deltaTime;
        reloj(tiempo);
        
        if(esta==true)
        {
            estado();
        }
    }

    public void reloj(float tiem)
    {
        txt_tiempo.text = "Tiempo: "+tiem.ToString("f0");
        Time.timeScale= 1f;
        if(tiem<=0)
        {
            tiem=0;
            menu_fin.SetActive(true);
            menu_pausa.SetActive(false);
            txt_tiempo.text = "Tiempo: 0";
        }
    }
    
    public void estado()
    {
        state_game = !state_game;

        if(state_game)
        {
            Time.timeScale= 1f;
        }
        else
        {
           Time.timeScale= 0.0001f; 
        }
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu_pausa.SetActive(false);
        menu_fin.SetActive(false);
        btn_pausa1.gameObject.SetActive(true);
        esta=false;
    }


    public void PausarJuego()
    {
        menu_pausa.SetActive(true);
        btn_pausa1.gameObject.SetActive(false);
        menu_fin.SetActive(false);
        esta=true;
    }

    public void PasarNivelJuego(int nivel)
    {
        
        if(nivel==2)
        {
            SceneManager.LoadScene("Scene2_niv2");
        }
        else if(nivel==3)
        {
            SceneManager.LoadScene("Scene2_niv3");
        }
    }

    void getButtons()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameButton");
        for(int i = 0; i < objs.Length; i++)
        {
            btns.Add(objs[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

        
    }

    public void AddLIsteners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => ClickButton());
        }

    }

    public void ClickButton()
    {
   
        fir = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("firs! " + fir);
        //fir = btns[firs].name;
        
        
        Debug.Log("seco! " + seco);
        //Debug.Log("fir! " + fir);
        countg++;

        Text txt = GameObject.FindGameObjectWithTag("Score").GetComponent <Text>() ;
        txt.text = "Intentos: " + countg; 
        
        result = fir.Equals(seco);

        if (result != true) {
            
           checkIfFinished(); 
        }
        else
        {
            count_correct ++;
            checkIfFinished();
        }

        
    }
    
    
    
    void checkIfFinished()
    {
        
        if (count_correct == 1)
        {
            Debug.Log("Game Finished");
            Debug.Log("Tardaste " + countg + " Intentos");
            btn_pausa1.gameObject.SetActive(false);
            

            nivel++;
            if(nivel==3)
            {
                menu_fin.SetActive(true);
            }
            
            PasarNivelJuego(nivel);
        }
    }

    void AddImages()
    {
        int count = btns.Count;
        int index = 0;

        for(int i = 0; i < count; i++)
        {
            game_imgs.Add(imgs[index]);
            index++;
        }

    }

    public void show()
    { 
        int contador = btns.Count;
        int index = 0;

        for(int j = 0; j < contador; j++)
        {           
            btns[j].image.sprite = imgs[ind];
            index++;
        }
    }

    void Shuffle(List<Button> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Button temp = list[i];
            int random = Random.Range(0, list.Count);
            list[i] = list[random];
            list[random] = temp;
            
        }
        
    }
}
