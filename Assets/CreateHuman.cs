using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHuman : MonoBehaviour {

    //人間全体の数
    int humanNum;
    //全体におけるゆっくりの人の確率　1以下
    int slowlyHuman;
    int hurryHuman;
    //人のオブジェクトなど共通部分一式
    [SerializeField]
    GameObject humanObject;
    //整列時の人間間の距離
    float humanRange;

    void Start() {
        slowlyHuman = variables.slowlyHuman;
        hurryHuman = variables.hurryHuman;
        humanNum = variables.humanNum;
        humanRange = variables.humanRange;
        createHuman();
    }

    void Update() {

    }

    private void createHuman() {
        //人間を正方形に配置するために、正方形の一辺を求める
        int squareSideLength = 1;
        while (Mathf.Pow(squareSideLength, 2) < humanNum)
            squareSideLength++;

        //人間を生成
        int slowlyHumanCount = 0;
        for (int i = 0; i < humanNum; i++) {
            GameObject human = Instantiate(humanObject);
            human.gameObject.name = "Human" + i.ToString();
            if (slowlyHumanCount < slowlyHuman) {
                human.AddComponent<SlowlyHuman>();
                slowlyHumanCount++;
            } else {
                human.AddComponent<HurryHuman>();
            }
            //素直に表示
            human.transform.position = new Vector3((int)( ( i - i % squareSideLength ) / (float)squareSideLength ) * ( humanRange + 1 ),
                                                   0,
                                                   i % squareSideLength * ( humanRange + 1 ));
            //階段前を中心にする
            human.transform.position = new Vector3(/*-squareSideLength * ( humanRange + 1 ) / 2*/ -human.transform.position.x - 10,
                                                   human.transform.position.y,
                                                   squareSideLength * ( humanRange + 1 ) / 2 - human.transform.position.z);
        }
    }
}
