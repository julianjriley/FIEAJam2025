using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownManager : MonoBehaviour
{
    public Transform[] playerTransforms;
    public StageTimer timer;
    private int lastFrameIndex = -1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if (timer.GetTime() <= 50) {
            int highestIndex = ScoreManager.instance.GetHighestScoreIndex();
            Vector2 _temp = new Vector2(playerTransforms[highestIndex].position.x, playerTransforms[highestIndex].position.y + 1f);
            transform.position = _temp;
            //change in crown
            if (highestIndex != lastFrameIndex) {
                anim.SetTrigger("CrownSwitch");
            }
            lastFrameIndex = highestIndex;
        }
        if (timer.GetTime() <= 10) {
            this.gameObject.SetActive(false);
        }
    }
}
