using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Canvas { get; private set; }
    [SerializeField] private TextMeshProUGUI currentLevel, nextLevel;
    [SerializeField] private List<Image> sections;

    private int _sectionNumber;
    public int currentLevelNumber;

    private void Awake()
    {
        //Singleton Design Pattern
        if (Canvas == null)
        {
            Canvas = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Initializations();
    }

    private void OnEnable()
    {
        DetectObjectCollision.SectionPassed += SectionPassed;
    }

    private void OnDisable()
    {
        DetectObjectCollision.SectionPassed -= SectionPassed;
    }

    void LevelPassed()
    {
        currentLevelNumber++;
        currentLevel.text = currentLevelNumber + "";
        nextLevel.text = (currentLevelNumber + 1) + "";
    }

    void SectionPassed()
    {
        _sectionNumber++;
        if (_sectionNumber == 4)
        {
            _sectionNumber -= 3;
            LevelPassed();
        }

        switch (_sectionNumber)
        {
            case 1:
                ChangeSectionColors(Color.yellow, Color.white, Color.white);
                break;
            case 2:
                ChangeSectionColors(Color.yellow, Color.yellow, Color.white);
                break;
            case 3:
                ChangeSectionColors(Color.yellow, Color.yellow, Color.yellow);
                break;
        }
    }

    void ChangeSectionColors(Color first, Color second, Color third)
    {
        sections[0].color = first;
        sections[1].color = second;
        sections[2].color = third;
    }

    void Initializations()
    {
        _sectionNumber = 1;
        currentLevelNumber = 1;

        ChangeSectionColors(Color.yellow, Color.white, Color.white);

        currentLevel.text = currentLevelNumber + "";
        nextLevel.text = (currentLevelNumber + 1) + "";
    }
}
