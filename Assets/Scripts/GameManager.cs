using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
using UnityEditor.Animations;
using System;
using Unity.Mathematics;

public class GameManager : BaseSingle<GameManager>
{
    // Start is called before the first frame update
    //public static GameManager gameManager;
    //public static GameManager Instance;
    public GameObject role,monster,swordeffort;
    public int test;
    public GameObject effect_playerfab;
    //public GameObject cube1, cube2,cube3,cube4;
    public  int base_idle ;//��hash����ʽ�洢״̬�����state������
    public int base_sub ;
    public int sub_attack ;
    public Dictionary<string, Monster> dict;
    /*��������*/
    private GameObject bg;
    public float scrollspeed;
    float offset;
    /*�������޹���*/
    private GameObject Monster;
    float offset_monster;
    Vector2 init;
    /*��ʼ������λ��*/
    public Vector2 position1, position2;
    public string monster1_controller_path;
    public string monster2_controller_path;
    public string monster1_sprite_path;
    public string monster2_sprite_path;
    public int monster1_id;
    public int monster2_id;
    GameObject monster_common; //��ʼ�������޷���
    /*����ع���*/
    GameObjectPool pool;
    /*��ʱ��*/
    double timer;
    int timestamp;
    private GameManager()
    {
        
        test = 10;
        //role = GameObject.Find("Role");
        //Debug.Log("this is  public Gamemanager ()!!");
        /*Debug.Log(role.GetComponent<Animator>().speed);*/
    }
    /*void OnGUI()
    {
        GUI.Label(new Rect(25, 25, 100, 30), timer.ToString());
    }*/
    private void InitJson() //��ʼ��Json
    {
        TextAsset jsonText = Resources.Load<TextAsset>("Monsters");
        dict = JsonMapper.ToObject<Dictionary<string, Monster>>(jsonText.text); //��ȡjson����
        /*foreach (var pair in dict)
        {
            Debug.Log(pair.Key);
            Debug.Log(pair.Value);
            
        }*/
    }
    private void TestOutPutTxt()
    {
        string json = "it is a test!!";
        string path = Application.dataPath + "\\Resources\\new.txt";
        FileStream file = new FileStream(path, FileMode.Create);
        byte[] bytes =System.Text.Encoding.UTF8.GetBytes(json);
        // ȫ��д���ļ�
        file.Write(bytes, 0, bytes.Length);
        if (file != null)
        {
            //��ջ���
            file.Flush();
            // �ر���
            file.Close();
            //������Դ
            file.Dispose();
        }


    }
    /*��������*/
    private void bgroll()
    {
        offset += (Time.deltaTime * scrollspeed) / 10f;
        bg.GetComponent<Image>().material.SetTextureOffset("_MainTex",new Vector2(0,offset));
    }

    /*�����ýű�����monster����sprite�ĸ���*/
    public void changesprite()
    {
        AnimatorController controller = Resources.Load<AnimatorController>("enemys/8/attack/8"); 
        Sprite sprite = Resources.Load<Sprite>("enemys/8/attack/00200");
        GameManager.Instance.monster.GetComponent<SpriteRenderer>().sprite = sprite; //Assets / Resources / enemys / 8 / attack / 00200.PNG) Assets/Resources/enemys/8/attack/8.controller
        GameManager.Instance.monster.GetComponent<Animator>().runtimeAnimatorController = controller;
    }
    public void InitMonster()
    {
        if (pool.UsePools)
        {
            pool.Create();
        }
        else
        {
            Instantiate(monster_common, position1, Quaternion.identity);
        }
        
    }
    public void InitMonster(int monsterid)
    {
        Instantiate(monster_common, position1, Quaternion.identity);
    }
    public void InitMonster(int monsterid1, int monsterid2)
    {
        monster1_sprite_path = dict[monsterid1.ToString()].sprite;
        monster2_sprite_path = dict[monsterid2.ToString()].sprite;
        monster1_controller_path = dict[monsterid1.ToString()].controller;
        monster2_controller_path = dict[monsterid2.ToString()].controller;
        GameObject temp1 = Instantiate(monster_common, position1, Quaternion.identity);
        GameObject temp2 = Instantiate(monster_common, position2, Quaternion.identity);
        temp1.GetComponent<MonsterController>().init(monsterid1, monster1_sprite_path, monster1_controller_path);
        temp2.GetComponent<MonsterController>().init(monsterid2, monster2_sprite_path, monster2_controller_path);
    }
    private void Awake()
    {
        Monster = GameObject.Find("monster");
        init = Monster.transform.position;
        bg = GameObject.Find("Background");
        scrollspeed = 0.5f;
        InitJson();
        TestOutPutTxt();
        base_idle = Animator.StringToHash("Base Layer.idle");
        base_sub = Animator.StringToHash("Base Layer.sub");
        sub_attack = Animator.StringToHash("Base Layer.sub.sub_attack");
        DOTween.Init();
        effect_playerfab = Resources.Load("swordeffect") as GameObject;
        /*cube1 = GameObject.Find("/Cube1");
        cube2 = GameObject.Find("/Cube1/Cube2");
        cube3 = GameObject.Find("/Cube1/Cube3");
        cube4 = GameObject.Find("Cube4");*/
        role = GameObject.Find("Role");
        monster = GameObject.Find("monster");
        swordeffort = GameObject.Find("swordeffect");
        Debug.Log("this is  Gamemanager awake()");
        /*��ʼ������λ��*/
        position1 = new Vector2(-1, 6);
        position2 = new Vector2(1, 6);
        monster_common = Resources.Load<GameObject>("monster");
        /*����س�ʼ��*/
        pool = gameObject.GetComponent<GameObjectPool>();
        InitMonster();    
        /*��ʱ��*/
        timer = timer+Time.deltaTime;
        timestamp = 0;

    }
    private void Start()
    {
        /*Debug.Log(GameManager.Instance.test);
        Debug.Log("this is  Gamemanager start()");*/
    }
    
    private void Update()
    {
        
        bgroll();
        timer = timer + Time.deltaTime;
        //offset_monster = scrollspeed * Time.deltaTime;
        /*�����ƶ�*/
        //monster.transform.Translate(new Vector2(0, -offset_monster));
        if (init.y-monster.transform.position.y > 1)
        {
            //Time.timeScale = 0;
            //Debug.Log(monster.transform.position);
        }
        System.Random ran = new System.Random();
        int random1 = ran.Next(1,5);
        int random2 = ran.Next(5, 11);
        /*��ʼ������*/
        if (Convert.ToInt32(timer)!=timestamp && Convert.ToInt32(timer) % 3 == 0)
        {
            timestamp = Convert.ToInt32(timer);
            InitMonster(random1,random2);
        }
    }



}
