﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変数管理・初期化専用

public class variables : MonoBehaviour {

    //急ぎたい人の列
    [SerializeField] private int[] hurryColumn { get; set; }

    //ゆっくりの人の列
    [SerializeField] private int[] slowlyColumn { get; set; }

    //人間全体の数
    [SerializeField] private int humanNum { get; set; }

    //全体におけるゆっくりの人の確率　1以下
    [SerializeField] private float slowlyProbability { get; set; }

    //各陣営の人数
    [SerializeField] private int slowlyHuman { get; set; }
    [SerializeField] private int hurryHuman { get; set; }

    //人のオブジェクトなど共通部分一式
    [SerializeField] private GameObject humanObject { get; set; }

    //整列時の人間間の距離
    [SerializeField] private float humanRange { get; set; }

    //エスカレーターのステップ数
    [SerializeField] private int stepSum { get; set; }

    //エスカレーターのステップ一段あたりに乗れる人数
    [SerializeField] private int stepLimite { get; set; }

    //このオブジェクトの下にエスカレーターのオブジェクトをすべて配置
    [SerializeField] private GameObject stepParent { get; set; }

    //人間を正方形に配置する際の、正方形の一辺を求める
    [SerializeField] private int squareSideLength { get; set; }

    //シミュレータを回す速度　 1 / 値 倍速　（Unityは基本的に50FPS）
    [SerializeField] private int simulationSpeed { get; set; }

    //ゆっくりの人用のエスカレータ
    [SerializeField] private int[] slowlyEscalator { get; set; }

    //急ぐ人用のエスカレータ
    [SerializeField] private int[] hurryEscalator { get; set; }

    //ゆっくりの人同士がステップを空ける段数
    [SerializeField] private int slowlyRange { get; set; }

    //ゆっくりの人が1回に進む段数
    [SerializeField] private int slowlyAdvance { get; set; }

    //急ぐ人同士がステップを空ける段数
    [SerializeField] private int hurryRange { get; set; }

    //急ぐ人が1回に進む段数
    [SerializeField] private int hurryAdvance { get; set; }

    //targetにいる人
    [SerializeField] private int[] endHuman { get; set; }

    /* Inspectorからの参照用 */
    [SerializeField] private GameObject stepParentImport;
    [SerializeField] private GameObject humanObjectImport;

    //全シーンで有効にする
    private void Awake() {
        DontDestroyOnLoad(this);

        /* 単純な変数初期化 */
        humanNum = 10;
        slowlyProbability = 1;
        humanObject = humanObjectImport;
        humanRange = 2;
        stepSum = 10;
        stepLimite = 2;
        stepParent = this.gameObject;
        // simulationSpeed = 20;
        simulationSpeed = 1;
        slowlyRange = 0;
        slowlyAdvance = 2;
        hurryRange = 2;
        hurryAdvance = 2;

        /* 以下計算を伴う変数の初期化 */
        slowlyHuman = (int)( humanNum * slowlyProbability );
        hurryHuman = humanNum - slowlyHuman;

        hurryColumn = new int[hurryHuman];
        for (int i = 0; i < hurryHuman; i++)
            hurryColumn[i] = -1;

        slowlyColumn = new int[slowlyHuman];
        for (int i = 0; i < slowlyHuman; i++)
            slowlyColumn[i] = -1;

        slowlyEscalator = new int[stepSum];
        for (int i = 0; i < stepSum; i++)
            slowlyEscalator[i] = -1;

        hurryEscalator = new int[stepSum];
        for (int i = 0; i < stepSum; i++)
            hurryEscalator[i] = -1;

        endHuman = new int[humanNum];
        for (int i = 0; i < humanNum; i++)
            endHuman[i] = -1;

        squareSideLength = 1;
        while (Mathf.Pow(squareSideLength, 2) < humanNum)
            squareSideLength++;
    }
}
