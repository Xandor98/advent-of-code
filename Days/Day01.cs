using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_Of_Code_2020.Days
{
    public class Day01 : Day
    {

        protected override string SolveP1(string Input)
        {
            StringBuilder solution = new StringBuilder();
            List<int> list = (from s in Input.Split("\n") select int.Parse(s)).ToList();

            bool found = false;

            for(int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (Debug)
                    {
                        solution.AppendLine(list[i] + " + " + list[j] + " = " + (list[i] + list[j]));
                    }

                    if(list[i] + list[j] == 2020)
                    {
                        solution.AppendLine();
                        solution.AppendLine("Raw Solution: " + list[i] + "+" + list[j] + "=" + "2020");
                        solution.AppendLine("Code        : " + (list[i] * list[j]));
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            return solution.ToString();
        }

        protected override string SolveP2(string Input)
        {
            StringBuilder solution = new StringBuilder();
            List<int> list = (from s in Input.Split("\n") select int.Parse(s)).ToList();

            bool found = false;

            for (int i = 0; i < list.Count - 2; i++)
            {
                for (int j = i + 1; j < list.Count - 1; j++)
                {
                    for (int k = j + 1; k < list.Count; k++)
                    {
                        if (Debug)
                        {
                            solution.AppendLine(list[i] + " + " + list[j] + " + " + list[k] + " = " + (list[i] + list[j] + list[k]));
                        }

                        if (list[i] + list[j] + list[k] == 2020)
                        {
                            solution.AppendLine();
                            solution.AppendLine("Raw Solution: " + list[i] + "+" + list[j] + "+" + list[k] + "=" + "2020");
                            solution.AppendLine("Code        : " + (list[i] * list[j] * list[k]));
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (found) break;
            }

            return solution.ToString();
        }
    }
}
