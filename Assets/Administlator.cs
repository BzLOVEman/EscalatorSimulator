using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Administlator : MonoBehaviour {

    //急ぎたい人の列
    private int[] HurryColumn;
    //ゆっくりの人の列
    private int[] SlowlyColumn;
    //人間全体の数
    private int humanNum = 100;
    //全体におけるゆっくりの人の確率　1以下
    private float slowlyProbability = 1;
    //各陣営の人数
    private int slowlyHuman;
    private int hurryHuman;
    //人のオブジェクトなど共通部分一式
    [SerializeField]
    private GameObject humanObject;
    //整列時の人間間の距離
    private float humanRange = 1;

    void Start() {
        slowlyHuman = (int)( humanNum * slowlyProbability );
        hurryHuman = humanNum - slowlyHuman;
        HurryColumn = new int[hurryHuman];
        SlowlyColumn = new int[slowlyHuman];
    }

    void Update() {

    }

    /*********************以下ゲッター及びセッター************************/
    public int HurryHumanNum {
        get { return hurryHuman; }
    }

    public int SlowlyHumanNum {
        get { return slowlyHuman; }
    }

    public float HumanRange {
        get { return humanRange; }
    }

    public int HumanNum {
        get { return humanNum; }
    }
}
