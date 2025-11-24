using System;
using System.Data;
using System.Text;

public class Program
{
    static void Main()
    {
        const string MenuTitle = """              
  __  __ _____ _   _ _   _  
 |  \/  | ____| \ | | | | | 
 | |\/| |  _| |  \| | | | | 
 | |  | | |___| |\  | |_| | 
 |_|  |_|_____|_| \_|\___/  
                            
""";
        const string MenuSubtitle = "===== Welcome, {0} the {1} with level {2} =====\n";
        const string MenuOption1 = "1. Train your wizard ";
        const string MenuOption2 = "2. Increase LVL ";
        const string MenuOption3 = "3. Loot the mine ";
        const string MenuOption4 = "4. Show inventory ";
        const string MenuOption5 = "5. Buy items ";
        const string MenuOption6 = "6. Show attacks by LVL ";
        const string MenuOption7 = "7. Decode ancient Scroll ";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Try again";
        const string ExitMessage = "Exiting game. Goodbye!";
        const string Update = "(Update)";
        const string New = "(New!)";
        const string Bits = "Bit/s";

        int op = 0, wizardLvl = 1, wizardPower = 0, wizardBits = 0; ;
        string wizardName = "", wizardTitle = "", input;
        string[] wizardInventory = new string[0];
        bool[] decodedScrolls = { false, false, false };

        Random random = new Random();

        do
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MenuTitle);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(wizardName.Equals("") ? "" : string.Format(MenuSubtitle, wizardName, wizardTitle, wizardLvl));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Update);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Update);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(New);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption4);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(New);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption5);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(New);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption6);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(New);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(MenuOption7);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(New);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);
            Console.ForegroundColor = ConsoleColor.White;


            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                op = -1;
            }
            catch (Exception)
            {
                op = -1;
            }

            switch (op)
            {
                case 1: //Train your wizard

                    const string InsertNamePrompt = "Enter your wizard's name: ";
                    const string TrainingMsg = "Day {0} -> {1} has trained for a total of {2} hours and gained {3} power points.";
                    const string TrainingCompleteMsg = "Training complete! {0} has achieved a total power of {1} points and earned the title '{2}'.\n";

                    const int TotalDaysTraining = 5;
                    const int MaxHoursPerDay = 25;
                    const int MaxPowerPerDay = 11;
                    const int MinHoursPerDay = 1;
                    const int MinPowerPerDay = 1;

                    int hours, power;

                    do
                    {

                        Console.Write(InsertNamePrompt);
                        wizardName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(wizardName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(InputErrorMessage);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    } while (string.IsNullOrWhiteSpace(wizardName));

                    wizardName = wizardName.Trim();
                    wizardName = string.Concat(wizardName.Substring(0, 1).ToUpper(), wizardName.Substring(1, wizardName.Length - 1).ToLower());

                    for (int day = 1; day <= TotalDaysTraining; day++)
                    {

                        hours = random.Next(MinHoursPerDay, MaxHoursPerDay);
                        power = random.Next(MinPowerPerDay, MaxPowerPerDay);
                        wizardPower += power;

                        Console.WriteLine(TrainingMsg, day, wizardName, hours, power);

                        Thread.Sleep(1000);

                    }

                    string finalMessage = "";

                    const string MsgE = "Retake in second call.";
                    const string MsgD = "You still mix a wand with a spoon.";
                    const string MsgC = "You are a summoner of magical breezes.";
                    const string MsgB = "Wow! You can summon dragons without burning down the laboratory!";
                    const string MsgA = "You have reached the rank of Master of the Arcane!";

                    const string RankE = "Raoden el Elantrí";
                    const string RankD = "Zyn el Buguejat";
                    const string RankC = "Arka Nullpointer";
                    const string RankB = "Elarion de les Brases";
                    const string RankA = "ITB-Wizard el Gris";

                    if (wizardPower < 20)
                    {
                        finalMessage = MsgE;
                        wizardTitle = RankE;
                    }
                    else if (wizardPower >= 20 && wizardPower < 30)
                    {
                        finalMessage = MsgD;
                        wizardTitle = RankD;
                    }
                    else if (wizardPower >= 30 && wizardPower < 35)
                    {
                        finalMessage = MsgC;
                        wizardTitle = RankC;
                    }
                    else if (wizardPower >= 35 && wizardPower < 40)
                    {
                        finalMessage = MsgB;
                        wizardTitle = RankB;
                    }
                    else
                    {
                        finalMessage = MsgA;
                        wizardTitle = RankA;
                    }

                    Console.WriteLine(finalMessage);
                    Console.WriteLine(TrainingCompleteMsg, wizardName, wizardPower, wizardTitle);

                    break;
                case 2: //Increase Level

                    const int MinValue = 0;
                    const string MsgChapter2 = "\nA wild {0} appears! Rolling dice to determine the outcome of the battle...";
                    const string MonsterHP = "The {0} has {1} HP.";
                    const string PressKey = "Press any key to roll the dice...";
                    const string DiceRoll = "You rolled a {0}";
                    const string MonsterDamage = "The monster takes damage!";
                    const string MonsterDefeated = "The {0} has been defeated!";
                    const string LevelIncrease = "{0} levels up!\n";
                    const string MsgMaxLvl = "You reached the maximum level.";
                    const int MaxLvl = 5;

                    string[] DiceNumber = { """
                               .-------.
                              /       /|
                             /_______/ |
                             |       | |
                             |   ♥   | /
                             |       |/
                             '-------'
                        """, """
                               .-------.
                              /       /|
                             /_______/ |
                             |♥      | |
                             |       | /
                             |      ♥|/
                             '-------'
                        """, """
                               .-------.
                              /       /|
                             /_______/ |
                             |♥      | |
                             |   ♥   | /
                             |      ♥|/
                             '-------'
                        """, """
                               .-------.
                              /       /|
                             /_______/ |
                             |♥     ♥| |
                             |       | /
                             |♥     ♥|/
                             '-------'
                        """, """
                               .-------.
                              /       /|
                             /_______/ |
                             |♥     ♥| |
                             |   ♥   | /
                             |♥     ♥|/
                             '-------'
                        """, """
                               .-------.
                              /       /|
                             /_______/ |
                             |♥     ♥| |
                             |♥     ♥| /
                             |♥     ♥|/
                             '-------'
                        """ };
                    string[] monsters = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍♂️", "Ancient Dragon 🐉" };
                    int[] monsterHP = { 3, 5, 10, 11, 18, 15, 20, 50 };
                    int monsterTotalHP, monsterNum, diceRoll;

                    if (wizardLvl == MaxLvl)
                    {
                        Console.WriteLine(MsgMaxLvl);
                    }
                    else
                    {


                        monsterNum = random.Next(MinValue, monsters.Length);
                        monsterTotalHP = monsterHP[monsterNum];

                        Console.WriteLine(MsgChapter2, monsters[monsterNum]);
                        Console.WriteLine(MonsterHP, monsters[monsterNum], monsterTotalHP);
                        do
                        {
                            diceRoll = random.Next(MinValue, DiceNumber.Length);

                            Console.WriteLine(DiceRoll, diceRoll + 1);

                            if (monsterTotalHP < (diceRoll + 1))
                            {
                                monsterTotalHP = 0;
                            }
                            else
                            {
                                monsterTotalHP -= (diceRoll + 1);
                            }

                            Console.WriteLine(DiceNumber[diceRoll]);
                            Console.WriteLine(MonsterDamage);
                            Console.WriteLine(MonsterHP, monsters[monsterNum], monsterTotalHP);

                            if (monsterTotalHP > 0)
                            {
                                Console.WriteLine(PressKey);
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine(MonsterDefeated, monsters[monsterNum]);
                                Console.WriteLine(LevelIncrease, wizardName);

                                wizardLvl += 1;
                            }

                        } while (monsterTotalHP > 0);

                        Console.WriteLine();
                    }

                    break;

                case 3: //Loot the mine

                    const string MsgChapter3 = "You have 5 attempts to mine for bits";
                    const string XAxis = "Insert de X axis (A number between 0-4):";
                    const string YAxis = "Insert de Y axis (A number between 0-4):";
                    const string PositionMined = "You mine at position [{0}][{1}] ";
                    const string MsgNotFound = "but found nothing.";
                    const string MsgFound = "and you get";
                    const string Coin = "🪙";
                    const string NoCoin = "❌";
                    const int tries = 5, maxValue = 2, minValue = 0, MinBits = 5, MaxBits = 51;

                    int xAxis, yAxis, bits;
                    string[,] mine = new string[5, 5];
                    string[,] mineOutput = {
                        { " ", "0", "1", "2", "3", "4" },
                        { "0", "➖", "➖", "➖", "➖", "➖" },
                        { "1", "➖", "➖", "➖", "➖", "➖" },
                        { "2", "➖", "➖", "➖", "➖", "➖" },
                        { "3", "➖", "➖", "➖", "➖", "➖" },
                        { "4", "➖", "➖", "➖", "➖", "➖" }
                    };
                    ;

                    Console.WriteLine(MsgChapter3);

                    for (int i = 0; i < mine.GetLength(0); i++)
                    {
                        for (int j = 0; j < mine.GetLength(1); j++)
                        {
                            mine[i, j] = random.Next(minValue, maxValue) == 0 ? Coin : NoCoin;
                        }
                    }

                    for (int x = 0; x < mineOutput.GetLength(0); x++)
                    {
                        for (int y = 0; y < mineOutput.GetLength(1); y++)
                        {
                            Console.Write($"{mineOutput[x, y]}\t");
                        }
                        Console.WriteLine();
                    }

                    for (int i = 0; i < tries; i++)
                    {

                        do
                        {
                            Console.WriteLine(XAxis);
                            input = Console.ReadLine();

                            if (!Int32.TryParse(input, out xAxis) || xAxis < 0 || xAxis > 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(InputErrorMessage);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        } while (!Int32.TryParse(input, out xAxis) || xAxis < 0 || xAxis > 4);

                        do
                        {
                            Console.WriteLine(YAxis);
                            input = Console.ReadLine();

                            if (!Int32.TryParse(input, out yAxis) || yAxis < 0 || yAxis > 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(InputErrorMessage);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        } while (!Int32.TryParse(input, out yAxis) || yAxis < 0 || yAxis > 4);
                                                
                        if (mine[xAxis, yAxis].Equals(Coin))
                        {
                            mineOutput[xAxis + 1, yAxis + 1] = Coin;
                            mine[xAxis, yAxis] = NoCoin;

                            bits = random.Next(MinBits, MaxBits);
                            wizardBits += bits;

                            Console.Write(string.Concat(string.Format(PositionMined, xAxis, yAxis), MsgFound));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($" {bits} {Bits}");
                            Console.ForegroundColor = ConsoleColor.White;
                            
                        }
                        else
                        {
                            mineOutput[xAxis + 1, yAxis + 1] = NoCoin;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(string.Concat(string.Format(PositionMined, xAxis, yAxis), MsgNotFound));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }
                                                
                        for (int x = 0; x < mineOutput.GetLength(0); x++)
                        {
                            for (int y = 0; y < mineOutput.GetLength(1); y++)
                            {
                                Console.Write($"{mineOutput[x, y]}\t");
                            }
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine();

                    break;

                case 4:

                    const string EmptyInventory = "Your inventory is empty";
                    const string InventoryList = "Your inventory cointains:";

                    if (wizardInventory.Length == 0)
                    {
                        Console.WriteLine(EmptyInventory);
                    }
                    else
                    {
                        Console.WriteLine(InventoryList);
                        foreach (string item in wizardInventory)
                        {
                            Console.WriteLine($" 🔸{item}");
                        }
                    }
                    break;

                case 5:

                    const string MsgChapter5 = "You chose to buy items";
                    const string MsgBits = "You have";
                    const string MsgBits2 = "available.";
                    const string MsgShop = "Items available for purchase:";
                    const string MsgOptionsShop = "Select the item you wish to buy (1 - 5) (0 to exit):";
                    const string MsgPurchase = "You have purchased: {0}";
                    const string MsgExitShop = "Thank you for visiting the shop";
                    const string MsgNotEnoughBits = "You don't have enough bits for this purchase...";
                    const string Price = "Price:";

                    int shopOp;
                    string[] shopItems = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" };
                    int[] price = { 30, 10, 50, 40, 20 };

                    Console.WriteLine(MsgChapter5);

                    do
                    {
                        Console.Write(MsgBits);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {wizardBits} {Bits} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(MsgBits2);
                        Console.WriteLine(MsgShop);

                        for (int i = 0; i < shopItems.Length; i++)
                        {
                            Console.Write($"{i + 1} - {shopItems[i]} - ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{Price} {price[i]}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        do
                        {
                            Console.WriteLine(MsgOptionsShop);
                            input = Console.ReadLine();

                            if (!Int32.TryParse(input, out shopOp) || shopOp < 0 || shopOp > 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(InputErrorMessage);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        } while (!Int32.TryParse(input, out shopOp) || shopOp < 0 || shopOp > 5);

                        if (shopOp != 0 && wizardBits >= price[shopOp - 1])
                        {
                            string[] auxInventory = new string[wizardInventory.Length + 1];

                            for (int i = 0; i < wizardInventory.Length; i++)
                            {

                                auxInventory[i] = wizardInventory[i];

                            }

                            auxInventory[auxInventory.Length - 1] = shopItems[shopOp - 1];
                            wizardInventory = auxInventory;

                            wizardBits -= price[shopOp - 1];

                            Console.WriteLine(MsgPurchase, shopItems[shopOp - 1]);

                        }
                        else if (shopOp != 0 && wizardBits < price[shopOp - 1])
                        {
                            Console.WriteLine(MsgNotEnoughBits);
                        }
                        else
                        {
                            Console.WriteLine(MsgExitShop);
                        }

                    } while (shopOp != 0);

                    break;

                case 6:
                    const string MsgChapter6 = "Available attacks for level {0}";
                    const string MsgEndChapter6 = "Keep training to unlock new powers!";

                    string[][] attacksByLevel = new string[][]
                    {
                        new string [] { "Magic Spark 💫" },
                        new string [] { "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" },
                        new string [] { "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" },
                        new string [] { "Wave of Light ⚜️", "Storm of Wings 🐦" },
                        new string [] { "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" }
                    };

                    Console.WriteLine(MsgChapter6, wizardLvl);

                    for (int j = 0; j < attacksByLevel[wizardLvl - 1].Length; j++)
                    {
                        Console.WriteLine($" 🔸{attacksByLevel[wizardLvl - 1][j]}");
                    }

                    Console.WriteLine(MsgEndChapter6);

                    break;
                case 7:

                    const string MsgChapter7 = "You found an ancient scroll with encrypted messages!\n";
                    const string MsgScroll = "Scrolls to decode:";
                    const string MsgDecode = "\nChoose a decoding operation:";
                    const string Decode1 = "Decipher spell (remove spaces)";
                    const string Decode2 = "Count magical runes (vowels)";
                    const string Decode3 = "Extract secret code (numbers)";
                    const string MsgDecode1 = "Deciphered Spell: ";
                    const string MsgDecode2 = "{0} magical runes (vowels) found";
                    const string MsgDecode3 = "🔮 Decoded number: ";
                    const string Scan = "Scanning: ...";
                    const string MsgDecodingComlpete = "Congratulations! You have successfully decoded all parts of the scroll.";

                    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                    char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    string scroll1 = "\"The 🐲 sleeps in the mountain of fire 🔥\"";
                    string scroll2 = "\"Ancient magic flows through the crystal caves\"";
                    string scroll3 = "\"Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️\"";
                    int opDecode, vowelsCount = 0;

                    Console.WriteLine(MsgChapter7);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(MsgScroll);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  1. {scroll1}");
                    Console.WriteLine($"  2. {scroll2}");
                    Console.WriteLine($"  3. {scroll3}");


                    do
                    {

                        Console.WriteLine(MsgDecode);
                        Console.WriteLine($"  1. {Decode1}");
                        Console.WriteLine($"  2. {Decode2}");
                        Console.WriteLine($"  3. {Decode3}");
                        input = Console.ReadLine();

                        if (!Int32.TryParse(input, out opDecode) || opDecode < 1 || opDecode > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(InputErrorMessage);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        
                    } while (!Int32.TryParse(input, out opDecode) || opDecode < 1 || opDecode > 3);

                    switch (opDecode)
                    {
                        case 1:

                            Console.WriteLine($"{MsgDecode1}{scroll1.Replace(" ", "")}");

                            decodedScrolls[0] = true;

                            break;

                        case 2:

                            char[] vowelsCheck = scroll2.ToLower().ToCharArray();

                            foreach (char letter in vowelsCheck)
                            {
                                foreach (char vowel in vowels)
                                {
                                    if (letter.Equals(vowel))
                                    {
                                        vowelsCount++;
                                    }
                                }
                            }

                            Console.WriteLine(MsgDecode2, vowelsCount);

                            decodedScrolls[1] = true;

                            break;

                        case 3:

                            Console.WriteLine(Scan);
                            Thread.Sleep(3000);
                            Console.Write(MsgDecode3);

                            char[] numbersCheck = scroll3.ToCharArray();

                            foreach (char letter in numbersCheck)
                            {
                                foreach (char number in numbers)
                                {
                                    if (letter.Equals(number))
                                    {
                                        Console.Write(letter);
                                    }
                                }
                            }

                            Console.WriteLine();

                            decodedScrolls[2] = true;

                            break;
                    }

                    if (decodedScrolls[0] && decodedScrolls[1] && decodedScrolls[2])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(MsgDecodingComlpete);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;


                case 0:

                    Console.WriteLine(ExitMessage);

                    break;
                default:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(InputErrorMessage);
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
            }
        } while (op != 0);
    }
}
