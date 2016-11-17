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
        // Spare is when all pins are nocked down in two tries
        // Bonus is number of pins nocked down in next roll
        // testOneSpare
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
        // Strike is when all pins are nocked down in a single roll
        // Bonus is number of pins nocked doen in next two rolls
        // testOneStrike

        // testPerfectGame
    }

    public class Game
    {
        private Round[] rounds = new Round[10];
        private int roundNumber = 0;
        private int rollNumber = 0;
        private bool isSpareBonusActive = false;
        private bool isStrikeBonusActive = false;

        public Game()
        {

        }

        public void Roll(int nockedPins)
        {
            if (rollNumber == 0)
            {
                rounds[roundNumber] = new Round();
            }
            rounds[roundNumber].Rolls.Add(nockedPins);
            var sumNockedPins = rounds[roundNumber].Rolls.Sum();
            if (sumNockedPins == 10 || rollNumber == 1)
            {
                rollNumber = 0;
                roundNumber++;
                return;
            }
            rollNumber++;
        }

        public int Score()
        {
            int score = 0;
            foreach (var round in rounds)
            {
                score += round.Rolls.Sum();
                if (isSpareBonusActive)
                {
                    score += round.Rolls.First();
                }
                if (round.Rolls.Sum() == 10)
                {
                    isSpareBonusActive = true;
                }
            }
            return score;
        }

        internal class Round
        {
            public List<int> Rolls { get; set; }

            public Round()
            {
                Rolls = new List<int>();
            }
        }
    }
}
