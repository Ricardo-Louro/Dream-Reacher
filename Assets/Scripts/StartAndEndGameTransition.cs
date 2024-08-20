using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartAndEndGameTransition : MonoBehaviour
{
    [SerializeField] private Image image;
    private Vector4 imageColor;
    [SerializeField] private TextMeshProUGUI tmp;

    private bool startGame = false;
    private bool endGame = false;
    private bool endGameText = false;

    [SerializeField] private float alphaChange;

    // Start is called before the first frame update
    private void Start()
    {
        imageColor = image.color;

        startGame = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (startGame)
        {
            imageColor.w = Mathf.Clamp(imageColor.w - (alphaChange * Time.deltaTime), 0, 1);

            if (imageColor.w <= 0)
            {
                startGame = false;
            }
        }

        if (endGame)
        {
            imageColor.w = Mathf.Clamp(imageColor.w + (alphaChange * Time.deltaTime), 0, 1);

            if (imageColor.w >= 1)
            {
                endGame = false;
                endGameText = true;
            }
        }

        if (endGameText)
        {
            tmp.alpha = Mathf.Clamp(tmp.alpha + (alphaChange * Time.deltaTime), 0, 1.5f);
            Debug.Log(tmp.alpha);
        }
        image.color = imageColor;

        if(tmp.alpha >= 1.5)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ActivateEndGame()
    {
        endGame = true;
    }
}