using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLife.GameCoreLib;

namespace GameOfLife
{
    class Program
    {
        private const string INVALIDINPUTMESSAGE = "Invalid user input. Program will stop...\n";
        private const string EXITMESSAGE = "Press the Escape (Esc) key to quit: \n";
        private const string RETURNMAINMESSAGE = "For Returning to Main\t\t\t\t\t\t\t\t Type B\n";

        /// <summary>
        /// Main - Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        
            PrintWelcomeAndInstructions();
           
            Console.ReadKey();            
        }

        /// <summary>
        /// Print Main Screen
        /// </summary>
        private static void PrintWelcomeAndInstructions()
        {
            Console.WriteLine("\t\tConways Game Of Life -- Main \n");

            Console.WriteLine("For simulating Known Patterns.\t\t\t Type P");
            Console.WriteLine("For simulating user defined life patterns.\t Type U");
            Console.WriteLine(EXITMESSAGE);

            char key = Console.ReadKey(false).KeyChar;
            
            if (key.ToString().ToUpper() == "P") { PrintKnownPatternsOptions(); return; }
            else if (key.ToString().ToUpper() == "U") { PrintUserDefinedPatternsOptions(); return;}

        }

        /// <summary>
        /// Print Known Patterns Screen
        /// </summary>
        private static void PrintKnownPatternsOptions()
        {

            Console.Clear();
            Console.WriteLine("\t\tConways Game Of Life -- Known Patterns \n");
            Console.WriteLine("Available Known Patterns are <(Pattern Name)#(GridSize)#(Generations)#(Live Cells Coordinates)>:\n");
            Console.WriteLine("Simple#4,4#4#1,1|1,2|2,1|2,2|2,3|3,3\t\t\t\t\t Type S\n");
            Console.WriteLine("Toad H#2,4#20#0,1|0,2|0,3|1,0|1,1|1,2\t\t\t\t\t Type H\n");
            Console.WriteLine("Toad V#4,4#100#0,0|1,0|1,1|2,0|2,1|3,1\t\t\t\t\t Type V\n");
            Console.WriteLine("Queen Bee Shuttle#7,4#100#0,0|0,1|1,2|2,3|3,3|4,3|5,2|6,0|6,1\t\t Type Q\n");
            Console.WriteLine("Period 3 Oscillator#5,3#50#0,1|1,0|1,1|1,2|2,0|2,2|3,0|3,1|3,2|4,1\t Type O\n");

            Console.WriteLine(RETURNMAINMESSAGE);
            Console.WriteLine(EXITMESSAGE);

            char key = Console.ReadKey(false).KeyChar;

            string userchoice = string.Empty;
            
            switch (key.ToString().ToUpper())
            {
                case "S":
                    userchoice = "Simple#4,4#4#1,1|1,2|2,1|2,2|2,3|3,3";
                    break;
                case "H":
                    userchoice = "Toad H#2,4#20#0,1|0,2|0,3|1,0|1,1|1,2";
                    break;
                case "V":
                    userchoice = "Toad V#4,4#100#0,0|1,0|1,1|2,0|2,1|3,1";
                    break;
                case "Q":
                    userchoice = "Queen Bee Shuttle#7,4#100#0,0|0,1|1,2|2,3|3,3|4,3|5,2|6,0|6,1";
                    break;
                case "O":
                    userchoice = "Period 3 Oscillator#5,3#50#0,1|1,0|1,1|1,2|2,0|2,2|3,0|3,1|3,2|4,1";
                    break;
                case "B":
                    Console.Clear(); PrintWelcomeAndInstructions(); 
                    return;
                default:
                    Console.WriteLine(INVALIDINPUTMESSAGE);
                    return;
            }

            ConfigStruct knownconfig = ValidateInput(userchoice);

            ProcessSimultion(knownconfig);

        }

        /// <summary>
        /// Print User Defined Patterns
        /// </summary>
        private static void PrintUserDefinedPatternsOptions()
        {
            Console.Clear();
            Console.WriteLine("\t\tConways Game Of Life -- User Defined Patterns \n");
            Console.WriteLine("For User Defined Patterns Enter configuration parameters in following format:\n");
            Console.WriteLine("<(Custom Pattern Name)#(GridSize)#(Generations)#(LiveCell Coordinates)>:\n");
            Console.WriteLine("Example: Blinker#3,3#2#0,1|1,1|2,1 :\n");
            Console.WriteLine(EXITMESSAGE);

            string userinput = Console.ReadLine();

            // Get proper initial state from the user
            ConfigStruct customconfig = ValidateInput(userinput);
            if (customconfig.pattern != null)
            ProcessSimultion(customconfig);

        }
        /// <summary>
        /// Validate input string and format
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        private static ConfigStruct ValidateInput(string userInput)
        {
            
            ConfigStruct config = new ConfigStruct();

            string[] configinstringformat = userInput.Split('#');
            string[] gridconfiguration;

            Exception exception = new Exception(INVALIDINPUTMESSAGE);

            try
            {
                config.pattern = configinstringformat[0];

                if (configinstringformat.Length != 4) throw exception;

                gridconfiguration = configinstringformat[1].Split(',');

                bool result = Int32.TryParse(configinstringformat[2], out config.maxgenerations);

                // Validate null and int type
                if (gridconfiguration.Length != 2 || int.Parse(gridconfiguration[0]) <= 0 || int.Parse(gridconfiguration[1]) <= 0 || (!result) || (string.IsNullOrWhiteSpace(userInput)))
                {
                    throw exception;
                }
                else
                {
                    config.gridrowcount = int.Parse(gridconfiguration[0]);
                    config.gridcolcount = int.Parse(gridconfiguration[1]);
                }


                // Validate coordinate string
                string[] coordinstring = configinstringformat[3].Split('|');
                for (int i = 0; i < coordinstring.Length; i++)
                {
                    string[] coordinatepair = coordinstring[i].Split(',');

                    int rownum;
                    int colnum;
                    if ((!Int32.TryParse(coordinatepair[0], out rownum)) || (!Int32.TryParse(coordinatepair[1], out colnum)))
                    {
                        throw exception;
                    }
                }
                config.CoOrds = coordinstring;
            }
            catch
            {
                // Can do cleanup work here.
                Console.WriteLine(exception.Message);
            }
            finally
            {
                config.pattern = null;
            }

            return config;

        }
        /// <summary>
        /// Process Simulation
        /// </summary>
        /// <param name="configparams"></param>
        private static void ProcessSimultion(ConfigStruct configparams)
        {
            Game objLifeGame = new Game(configparams.gridrowcount , configparams.gridcolcount);

            objLifeGame.MaxGenerations = configparams.maxgenerations;

            Console.BufferHeight = (Console.BufferHeight > objLifeGame.MaxGenerations * 20) ? Console.BufferHeight : objLifeGame.MaxGenerations * 20;

            Console.Clear();
            
            Console.WriteLine("Simulating Pattern: " + configparams.pattern + "\n");

            for (int i = 0; i < configparams.CoOrds.Length; i++)
            {
                string[] coordinstring = configparams.CoOrds[i].Split(',');
                objLifeGame.ToggleGridCell(int.Parse(coordinstring[0]), int.Parse(coordinstring[1]));
            }
            
            objLifeGame.Init();

            Console.WriteLine(RETURNMAINMESSAGE);
            Console.WriteLine(EXITMESSAGE);
            
            char key = Console.ReadKey(false).KeyChar;
            if (key.ToString().ToUpper() == "B") { Console.Clear(); PrintWelcomeAndInstructions(); return; }

        }
    }

    /// <summary>
    /// Structure to store configuration
    /// </summary>
    public struct ConfigStruct
    {
        public string pattern;
        public int gridrowcount;
        public int gridcolcount;
        public int maxgenerations;
        public string[] CoOrds;
    }

}
