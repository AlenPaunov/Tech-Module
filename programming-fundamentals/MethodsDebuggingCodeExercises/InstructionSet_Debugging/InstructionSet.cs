
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionSet_Debugging
{
    class InstructionSet_broken
    {
        static void Main()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArg = command.Split(' ');

                long result = 0;
                switch (commandArg[0])
                {
                    case "INC":
                        {
                            int operand = int.Parse(commandArg[1]);
                            result = (long)operand + 1;
                            break;
                        }
                    case "DEC":
                        {
                            int operand = int.Parse(commandArg[1]);
                            result = (long)operand - 1;
                            break;
                        }
                    case "ADD":
                        {
                            int operandOne = int.Parse(commandArg[1]);
                            int operandTwo = int.Parse(commandArg[2]);
                            result = operandOne + (long)operandTwo;
                            break;
                        }
                    case "MLA":
                        {
                            int operandOne = int.Parse(commandArg[1]);
                            int operandTwo = int.Parse(commandArg[2]);
                            result = operandOne * (long)operandTwo;
                            break;
                        }

                }
   
                Console.WriteLine(result);
                command = Console.ReadLine();
            }
        }
    }
}

