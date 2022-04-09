﻿using System;
using System.Collections.Generic;
using System.Text;
using Text_Based_Adventure.Engine.GameStates;
using Text_Based_Adventure.Engine.Levels;
using Text_Based_Adventure.Engine.Games;

namespace Text_Based_Adventure.Engine
{
    public class GameController
    {
        public RoomController roomController;
        public LevelController levelController;
        public GameState gameState;
        public string displayText;
        public UserInput userInput;
        public Game game;


        List<string> actionLog = new List<string>();

        public GameController(GameState initialState, Game game)
        {
            roomController = new RoomController();
            levelController = new LevelController();
            gameState = initialState;
            userInput = new UserInput();
            this.game = game;
        }

        public void StartGame()
        {
            this.roomController.currentRoom = game.Levels[0].StartingRoom.Enter();
        }

        public void TakeUserInputAndRespond()
        {
            string input = Util.rl();
            userInput.AcceptStringInput(input, this);
        }

        public void DisplayLoggedText()
        {
            string logAsText = string.Join("\n", actionLog.ToArray());

            displayText = logAsText;


        }

        public void LogString(string stringToAdd)
        {
            actionLog.Add(stringToAdd);
        }

        public void ExitGame()
        {
            gameState.Exit();
        }
    }
}