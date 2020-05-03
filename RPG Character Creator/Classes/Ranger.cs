﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Character_Creator
{
    class Ranger : CharacterCombat
    {
        private List<string> baseTalents = new List<string> { "1st Favored Enemy", "Track", "Wild Empathy" };
        private int hitDie = 8;
        private int lvl;
        private int bonusFeat = 0;

        public int GetBonusFeat()
        {
            return this.bonusFeat;
        }// GetBonusFeat
        public void PrintTalents()
        {
            baseTalents.ForEach(action: Console.WriteLine);
        }// PrintTalents
        public void HPInfo()
        {
            Console.WriteLine("You just entered the Hit Point manager! What would you do?");
            Console.WriteLine("1- Print HP.");
            Console.WriteLine("2- Generate HP randomly.");
            Console.WriteLine("3- Insert HP value.");

            int res = 0;
            do
            {
                try
                {
                    res = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Uh oh, something went wrong.");
                }

                if (res < 1 || res > 3)
                {
                    Console.WriteLine("Sadly, that is not a valid enter. Please, try again.");
                }
                else
                {
                    switch (res)
                    {
                        case 1:
                            Console.WriteLine("The value of your HP is: " + GetStat("hp"));
                            break;
                        case 2:
                            Console.WriteLine("As you prefer! Randomly generating HP value, stand by!");
                            DiceRoll dice = new DiceRoll();
                            int hpUpdate = 0;
                            UpdateStat(hpUpdate, "hp");
                            for (int i = 0; i < this.lvl; i++)
                            {
                                hpUpdate += dice.Roll(this.hitDie) + GetModifier("Constitution");
                                Console.WriteLine(GetModifier("Constitution"));
                                Console.WriteLine(GetStat("hp"));
                            }
                            UpdateStat(hpUpdate, "hp");
                            break;
                        case 3:
                            Console.WriteLine("Ok, insert now the value of your total HP: ");
                            UpdateStat(Convert.ToInt32(Console.ReadLine()), "hp");
                            break;
                        default:
                            break;
                    }
                }

            } while (res < 1 || res > 3);




        }
        public Ranger(int lvl)
        {
            this.lvl = lvl;
            switch (lvl)
            {
                case 1:
                    UpdateStat(2, "fortitude");
                    UpdateStat(2, "reflex");
                    UpdateStat(0, "will");
                    UpdateStat(1, "bab");
                    break;
                case 2:
                    UpdateStat(3, "fortitude");
                    UpdateStat(3, "reflex");
                    UpdateStat(0, "will");
                    UpdateStat(2, "bab");
                    this.baseTalents.Add("Combat Style");
                    break;
                case 3:
                    UpdateStat(3, "fortitude");
                    UpdateStat(3, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(3, "bab");
                    this.baseTalents.Add("Combat Style");
                    this.baseTalents.Add("Endurance");
                    this.bonusFeat++;
                    break;
                case 4:
                    UpdateStat(4, "fortitude");
                    UpdateStat(4, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(4, "bab");
                    AddSpell(0, "Level 1");
                    this.baseTalents.Add("Combat Style");
                    this.baseTalents.Add("Endurance");
                    this.baseTalents.Add("Animal Companion");
                    this.bonusFeat++;
                    break;
                case 5:
                    UpdateStat(4, "fortitude");
                    UpdateStat(1, "reflex");
                    UpdateStat(1, "will");
                    UpdateStat(5, "bab");
                    AddSpell(0, "Level 1");
                    this.baseTalents.Add("Combat Style");
                    this.baseTalents.Add("Endurance");
                    this.baseTalents.Add("Animal Companion");
                    this.baseTalents.Add("2nd Favored Enemy");
                    this.bonusFeat++;
                    break;
                default:
                    Console.WriteLine("Whoops. Something went wrong.");
                    break;
            }// Switch Case
        }// Costructor
    }// Class
}