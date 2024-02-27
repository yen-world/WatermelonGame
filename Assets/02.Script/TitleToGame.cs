using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToGame : MonoBehaviour
{
    // TitleToGameBackground에 붙어있는 Animator
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 애니메이션이 종료되면 메인씬으로 전환
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
