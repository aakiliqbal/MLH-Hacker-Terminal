﻿using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    const string menuHint = "You may type 'main menu', 'menu', 'quit' at any  time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronaut" };
    string[] level4Passwords = { "mike", "jonathan", "2013", "hacking", "league", "major" };

    // Game state
    int level;
    enum Screen { MainMenu, Menu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(@"
      `smmmmmmmmmmmmmmmmmmmmms.       
     `ymmmmy/..+dmmmmmmmmmmmmmd:      
    `ommmh:`    -dmmmmmmmmmmmmmm-     
    -dmmy.       +mmmmmy+/odmmmmy`    
   `ommy`        :mmm+`    .dmmmm`    
   `hmm+        `smd-      `ommmm.    
   `hmmmyo/-..-/ymms        /mmmy`    
    -shdmmmmmmmmmmmd.       /mmm:     
      ```.:dmmmmmmmmmo.    `ommo      
          `smmmmmmmmmmmdo/-+mmo`      
          :mmmmmmmmmmsoshmmmh/        
         `smmmmmmmmm");
        Terminal.WriteLine("*** Welcome to hacker terminal ***");
        Terminal.WriteLine("Type 'start', to start hacking.");
        Terminal.WriteLine("Type 'quit' to exit terminal anytime.");

    }

    void ShowMenu()
    {
        currentScreen = Screen.Menu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA!");
        Terminal.WriteLine("Press 4 for MLH!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMenu();
        }
        else if (input == "start")
        {
            ShowMenu();
        }
        else if (input == "quit")
        {
            Application.Quit();
            Debug.Log("quit");
        }
        else if (input == "main menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Menu)
        {
            RunMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
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
            case 4:
                password = level4Passwords[Random.Range(0, level4Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
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
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                Terminal.WriteLine("Play again for a greater challenge.");
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            case 4:
                Terminal.WriteLine(@"
            _ _
           | | |    
  _ __ ___ | | |__     
 | '_ ` _ \| | '_ \ 
 | | | | | | | | | |
 |_| |_| |_|_|_| |_|
"               );
                Terminal.WriteLine("Welcome to Snake And Hackers!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}