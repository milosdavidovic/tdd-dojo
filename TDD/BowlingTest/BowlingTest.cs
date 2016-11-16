using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.BowlingTest
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void ForGutterGame_Score_ReturnsZero()
        {
            var g = new Game();
            for (int i = 0; i < 20; i++)
                g.Roll(0);
            Assert.AreEqual(0, g.Score());
        }

        //testAllOnes
        [TestMethod]
        public void ForAllOnes_Score_ReturnsScore()
        {
            var g = new Game();
            for (int i = 0; i < 20; i++)
            {
                g.Roll(1);
            }
            Assert.AreEqual(20, g.Score());
        }
        //testOneSpare
        [TestMethod]
        public void ForOneSpare_Score_ReturnsScore()
        {
            var g = new Game();
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            for (int i = 0; i < 17; i++)
            {
                g.Roll(0);
            }
            Assert.AreEqual(16, g.Score());
        }

        //testOneStrike

        //testPerfectGame
    }

    public class Game
    {
        private int[] rolls = new int[21];
        private int rollsPlayed = 0;
        public Game()
        {

        }

        public void Roll(int pins)
        {
            rolls[rollsPlayed] = pins;
            rollsPlayed++;
        }

        public int Score()
        {
            int score = 0;
            bool foundSpare = false;
            for (int i = 0; i < 21; i++)
            {
                score += rolls[i];
            }
            return rolls.Sum();
        }
    }
}
