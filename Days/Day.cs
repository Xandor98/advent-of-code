using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Advent_Of_Code_2020.Days
{
    public abstract class Day
    {
        private String BASEPATH = Path.Combine(Directory.GetCurrentDirectory(), "Inputs");

        public String Name { get; private set; }

        public bool Debug { get; private set; } = false;

        public String Solution { 
            get {
                StringBuilder builder = new StringBuilder();
                #region Header
                    builder.AppendLine("---------------------------------------------------");
                    builder.AppendLine("Name: " + Name);
                    builder.AppendLine("File: " + Name + "_input.txt");
                    builder.AppendLine("Started: " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"));
                    builder.AppendLine("Debug: " + Debug);
                    builder.AppendLine("---------------------------------------------------");

                    DateTime start = DateTime.Now;
                #endregion

                builder.AppendLine("-- Solution P1 --");
                if (Debug)
                    builder.AppendLine("Solution with Debug:");
                else
                    builder.AppendLine("Solution:");

                builder.AppendLine(SolveP1(GetInput()));

                builder.AppendLine();

                builder.AppendLine("-- Solution P2 --");

                if (Debug)
                    builder.AppendLine("Solution with Debug:");
                else
                    builder.AppendLine("Solution:");

                builder.AppendLine(SolveP2(GetInput()));

                #region Footer
                    builder.AppendLine("---------------------------------------------------");
                    builder.AppendLine("Finished: " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"));
                    builder.AppendLine("Elapsed Time (ms): " + DateTime.Now.Subtract(start).TotalMilliseconds + "ms");
                    builder.AppendLine("Elapsed Time (s): " + DateTime.Now.Subtract(start).TotalSeconds + "s");
                    builder.AppendLine("---------------------------------------------------");
                #endregion

                return builder.ToString();
            }
        }

        public Day()
        {
            Name = this.GetType().Name;
#if (DEBUG)
            Debug = true;
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        protected abstract String SolveP1(String Input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        protected abstract String SolveP2(String Input);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String GetInput()
        {
            string dayname = this.GetType().Name + "_input.txt";
            string file = Path.Combine(BASEPATH, dayname);
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }

            throw new FileNotFoundException("File should be in the Directory \"" + BASEPATH + "\" and Named \"" + dayname + "\"");
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Day[] GetAllDays(bool Debug = false)
        {
            List<Day> days = new List<Day>();
            foreach (Type type in Assembly.GetAssembly(typeof(Day)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Day))))
            {
                Day d = (Day)Activator.CreateInstance(type);
                d.Debug = Debug;
                days.Add(d);
            }
            days.Sort();
            return days.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static Day GetDay(int Date, bool Debug = false)
        {
            if(Date > 25 || Date < 1)
            {
                throw new ArgumentException("Date musst be between 1 and 25 (inclusiv)");          
            }
            string name = "Day" + (Date % 10 < 0 ? "0" + Date : "" + Date);
            return GetAllDays(Debug).Where(myDate => myDate.GetType().Name.Contains(name)).FirstOrDefault();
        }
    }
}
