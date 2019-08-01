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
        int debugNum = 0;
        //人間を生成
        int slowlyHumanCount = 0;
        GameObject[] human = new GameObject[variables.humanNum];
        for (int i = 0; i < variables.humanNum; i++) {
            human[i] = Instantiate(variables.humanObject);
            human[i].gameObject.name = "Human" + i.ToString();
            Destroy(human[i].GetComponent<BoxCollider>());

            /* デバッグ用　名前表示 */
            GameObject Name = new GameObject("Name");
            TextMesh TM = Name.AddComponent<TextMesh>();
            TM.text = human[i].gameObject.name;
            TM.anchor = TextAnchor.MiddleRight;
            TM.alignment = TextAlignment.Center;
            TM.fontSize = 40;
            Name.transform.position = human[i].transform.position + Vector3.up;
            Name.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Name.transform.parent = human[i].transform;
            /* デバッグ用　名前表示　終わり */

            if (slowlyHumanCount < variables.slowlyHuman) {
                //ゆっくり行く人にする
                human[i].AddComponent<SlowlyHuman>();
                //ゆっくり行きたい人を配列に保存
                int j = 0;
                while (variables.slowlyColumn[j] != -1)
                    j++;
                variables.slowlyColumn[j] = i;
                slowlyHumanCount++;
            } else {
                //急ぐ人にする
                human[i].AddComponent<HurryHuman>();
                //急ぐ人を配列に保存
                int j = 0;
                while (variables.hurryColumn[j] != -1)
                    j++;
                variables.hurryColumn[j] = i;
            }
            //表示
            human[i].transform.position = new Vector3(-( i / variables.squareSideLength * variables.humanRange + 3 ),
                                                   0,
                                                   ( variables.squareSideLength / 2f - i % variables.squareSideLength ) * variables.humanRange);
        }
    }
}
