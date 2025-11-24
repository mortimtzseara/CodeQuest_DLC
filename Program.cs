using System;
using System.Data;
using System.Text;

public class Program
{
    static void Main()
    {
        const string MenuTitle = "\t===== MAIN MENU - CODEQUEST =====";
        const string MenuSubtitle = "===== Welcome, {0} the {1} with level {2} =====\n";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL (Update)";
        const string MenuOption3 = "3. Loot the mine (Update)";
        const string MenuOption4 = "4. Show inventory (New!)";
        const string MenuOption5 = "5. Buy items (New!)";
        const string MenuOption6 = "6. Show attacks by LVL (New!)";
        const string MenuOption7 = "7. Decode ancient Scroll (New!)";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 7.";
        const string ExitMessage = "Exiting game. Goodbye!";

        int op = 0, wizardLvl = 1, wizardPower = 0, totalPower = 0, wizardBits = 0; ;
        string wizardName = "", wizardTitle = "", wizardInventory = "";

        Random random = new Random();

        do
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(MenuTitle);
            Console.Write(wizardName.Equals("") ? "" : string.Format(MenuSubtitle, wizardName, wizardTitle, wizardLvl));
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);


            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                op = -1;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
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

                    Console.Write(InsertNamePrompt);
                    wizardName = Console.ReadLine();

                    wizardName = wizardName.Trim();
                    wizardName = string.Concat(wizardName.Substring(0, 1).ToUpper(), wizardName.Substring(1, wizardName.Length - 1).ToLower());

                    for (int day = 1; day <= TotalDaysTraining; day++)
                    {

                        hours = random.Next(MinHoursPerDay, MaxHoursPerDay);
                        power = random.Next(MinPowerPerDay, MaxPowerPerDay);
                        totalPower += power;

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

                    if (totalPower < 20)
                    {
                        finalMessage = MsgE;
                        wizardTitle = RankE;
                    }
                    else if (totalPower >= 20 && totalPower < 30)
                    {
                        finalMessage = MsgD;
                        wizardTitle = RankD;
                    }
                    else if (totalPower >= 30 && totalPower < 35)
                    {
                        finalMessage = MsgC;
                        wizardTitle = RankC;
                    }
                    else if (totalPower >= 35 && totalPower < 40)
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
                    Console.WriteLine(TrainingCompleteMsg, wizardName, totalPower, wizardTitle);

                    break;