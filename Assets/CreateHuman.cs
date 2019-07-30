using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHuman : MonoBehaviour {
    
    void Start() {
        createHuman();
    }

    void Update() {

    }

    private void createHuman() {
        //人間を正方形に配置するために、正方形の一辺を求める
        int squareSideLength = 1;
        while (Mathf.Pow(squareSideLength, 2) < variables.humanNum)
            squareSideLength++;

        //人間を生成
        int slowlyHumanCount = 0;
        for (int i = 0; i < variables.humanNum; i++) {
            GameObject human = Instantiate(variables.humanObject);
            human.gameObject.name = "Human" + i.ToString();
            if (slowlyHumanCount < variables.slowlyHuman) {
                human.AddComponent<SlowlyHuman>();
                slowlyHumanCount++;
            } else {
                human.AddComponent<HurryHuman>();
            }
            //素直に表示
            human.transform.position = new Vector3((int)( ( i - i % squareSideLength ) / (float)squareSideLength ) * ( variables.humanRange + 1 ),
                                                   0,
                                                   i % squareSideLength * ( variables.humanRange + 1 ));
            //階段前を中心にする
            human.transform.position = new Vector3(/*-squareSideLength * ( variables.humanRange + 1 ) / 2*/ -human.transform.position.x - 10,
                                                   human.transform.position.y,
                                                   squareSideLength * ( variables.humanRange + 1 ) / 2 - human.transform.position.z);
        }
    }
}
