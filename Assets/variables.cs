using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変数管理専用

public class variables : MonoBehaviour {

    //急ぎたい人の列
    protected static int[] hurryColumn;
    //ゆっくりの人の列
    public static int[] slowlyColumn;
    //人間全体の数
    protected static int humanNum = 100;
    //全体におけるゆっくりの人の確率　1以下
    public static float slowlyProbability = 1;
    //各陣営の人数
    public static int slowlyHuman;
    public static int hurryHuman;
    //人のオブジェクトなど共通部分一式
    public static GameObject humanObject;
    //整列時の人間間の距離
    public static float humanRange = 1;

    public static int[] HurryColumn {
        get { return hurryColumn; }
        set { hurryColumn = value; }
    }

    public static int[] SlowlyColumn {
        get { return slowlyColumn; }
        set { slowlyColumn = value; }
    }

    public static int HumanNum {
        get { return humanNum; }
        set { humanNum = value; }
    }

    public static float SlowlyProbability {
        get { return slowlyProbability; }
        set { slowlyProbability = value; }
    }

    //全シーンで有効にする
    void Start() {
        DontDestroyOnLoad(this);
    }
}
