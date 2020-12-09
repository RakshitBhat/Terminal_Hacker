
using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "borrow", "circulation", "renewal", "recall", "books" };
    string[] level2Passwords = { "compress", "administration", "articulate", "erotic", "analytical" };
    string[] level3Passwords = { "onomatopoeia", "paraphernalia", "conscientious", "acquiesce", "gubernatorial" };
    //game state
    int level;

    enum Screen { MainMenu,Password,Win};
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    //use this for initialization
    void Start()
    {
        
        ShowMainMenu();
    }
   /* void Update()
    {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);
        int index1 = Random.Range(0, level2Passwords.Length);
        print(index1);
        int index2 = Random.Range(0, level3Passwords.Length);
        print(index2);
    }*/
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        //Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the High School");
        Terminal.WriteLine("Press 3 for the International College");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if(input=="menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen==Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelnumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelnumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007") //easter egg
        {
            Terminal.WriteLine("Please Select the level Mr.Bond");
        }
        else
        {
            Terminal.WriteLine("Please chose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }  
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        //Terminal.WriteLine("You have selected level "+level);
        Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    { 
        if(input==password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowlevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowlevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Welldone! Have a book");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /_____//
(_____(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("Welldone! You got the Key");
                Terminal.WriteLine(@"
  __
 /0 \_______
 \__/-=' = '
"
                );
                break;
            case 3:
                Terminal.WriteLine("Welldone!");
                Terminal.WriteLine(@"
  ▒▒▄▀▀▀▀▀▄▒▒▒▒▒▄▄▄▄▄▒▒▒
  ▒▐░▄░░░▄░▌▒▒▄█▄█▄█▄█▄▒
  ▒▐░▀▀░▀▀░▌▒▒▒▒▒░░░▒▒▒▒
  ▒▒▀▄░═░▄▀▒▒▒▒▒▒░░░▒▒▒▒
  ▒▒▐░▀▄▀░▌▒▒▒▒▒▒░░░▒▒▒▒
"
                );
                break;
                Terminal.WriteLine("Play again for greater challenge");
                break;
            default: 
                Debug.LogError("Invalid level reached");
                break;
        }
        
    }
}
