using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変数管理専用

public class variables : MonoBehaviour {

    //急ぎたい人の列
    public static int[] hurryColumn { get; set; }

    //ゆっくりの人の列
    public static int[] slowlyColumn { get; set; }

    //人間全体の数
    public static int humanNum { get; set; }

    //全体におけるゆっくりの人の確率　1以下
    public static float slowlyProbability { get; set; }

    //各陣営の人数
    public static int slowlyHuman { get; set; }
    public static int hurryHuman{ get; set; }
    
    //人のオブジェクトなど共通部分一式
    public static GameObject humanObject { get; set; }
    
    //整列時の人間間の距離
    public static float humanRange { get; set; }
    
    //エスカレーターのステップ数
    private int stepSum;
    
    //エスカレーターのステップ一段あたりに乗れる人数
    private int stepLimite = 2;
    
    //このオブジェクトの下にエスカレーターのオブジェクトをすべて配置
    public GameObject stepParent;

    //全シーンで有効にする
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}
