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
            //表示
            human.transform.position = new Vector3(-( i / variables.squareSideLength * variables.humanRange + 3 ),
                                                   0,
                                                   ( variables.squareSideLength / 2f - i % variables.squareSideLength ) * variables.humanRange);
        }
    }
}
