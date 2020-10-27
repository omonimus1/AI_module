
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace coursework_40401270
{
    class PathFinding
    {
        private static String ALGO = "ASTAR";

    public static void main(String[] args)
        {

            List<String> file;
            String content;
            Cave[] caves;

            if (args.Length != 1)
            {
                Console.WriteLine("Use: PathFinding file (must be a .cav file");
                return;
            }

            String fileName = args[0];
            Path path = FileSystems.getDefault().getPath("./", fileName + ".cav");

            try
            {
                file = Files.readAllLines(path);
                content = file.[0];
            }
            catch (IOException e)
            {
                Console.WriteLine("Use: PathFinding file (must be a .cav file");
                
                return;
            }

            String[] values = content.Split(",");
            int cavesNumber = Convert.ToInt32(values[0]);
            caves = new Cave[cavesNumber];

            int offset = 1; // we jump the first number which indicates the cave's number
            for (int i = 0; i < cavesNumber; i++)
            {
                
                caves[i] = new Cave(Convert.ToDouble(values[i * 2 + offset]), Double.parseDouble(values[i * 2 + offset + 1]), "" + (i + 1));
            }

            offset = 1 + 2 * cavesNumber; // we jump the cave's number and the cave's locations
            for (int i = offset; i < values.Length; i++)
            { // creating the connections between caves from the matrix
                int startingCaveIndex = (i - 1) % cavesNumber;
                int endingCaveIndex = (i - offset) / cavesNumber;
                if (values[i].Equals("1"))
                {
                    caves[startingCaveIndex].addLink(caves[endingCaveIndex]); // add connection
                }
            }

            Cave startingCave = caves[0];
            Cave endingCave = caves[cavesNumber - 1];
            
            ArrayList toExplore = new ArrayList();
            ArrayList explored = new ArrayList();
            toExplore.Add(startingCave); // we start the exploration, from the start...
            startingCave.setDistanceFromStart(0);
            Cave currentCave;

            do
            {
                currentCave = (Cave)toExplore[0];

                for (Cave link : currentCave.getLinks())
                { // we explore each links in the current cave
                  // if the cave we discover hasn't been explored, we add it to the exploration list
                    if (!explored.Contains(link) && link != currentCave)
                    {


                        if (!toExplore.Contains(link))
                        {
                            toExplore.Add(link);
                        }

                        double distanceToThatLink = currentCave.getDistance(link) +
                                                    currentCave.getDistanceFromStart();

                        if (distanceToThatLink < link.getDistanceFromStart())
                        {
                            link.setDistanceFromStart(distanceToThatLink);
                            link.setClosestCave(currentCave);
                        }
                    }
                }
                toExplore.Remove(currentCave); // the current node has been explored, we don't care about it anymore
                explored.Add(currentCave); // so that we don't work on that node again
                                           // We sort the exploration list by their distance from the starting point
                                           // We can pass from A* to Dijkstra by removing the heuristic
                                           // The heuristic is the distance from the current cave to the end cave

                if (ALGO == "DIJKSTRA")
                {
                    // DIJKSTRA
                    Collections.sort(toExplore, (o1, o2)-> (int)((o1.getDistanceFromStart() - o2.getDistanceFromStart())));
                }
                else
                {
                    // ASTAR
                    Collections.sort(toExplore, (o1, o2)-> (Int)((o1.getDistanceFromStart() - o2.getDistanceFromStart()) +
                                                                   (o1.getDistance(endingCave) - o2.getDistance(endingCave))));
                }

            } while (currentCave != endingCave && toExplore.size() > 0);

            String solution = "";
            double distance = 0.0;
            if (explored.Contains(endingCave))
            { // print the shortest path backward
                do
                {
                    solution = currentCave.getId() + " " + solution;
                    if (currentCave.getClosestCave() != null)
                    {
                        distance += currentCave.getDistance(currentCave.getClosestCave());
                    }
                } while ((currentCave = currentCave.getClosestCave()) != null);
            }
            else
            {
                solution = "0";
            }


            writeUsingOutputStream(solution.Trim(), fileName + ".csn");
        }

        private static void writeUsingOutputStream(String data, String fileName)
        {
            FileStream os = null;
            try
            {
                os = new FileStream(fileName, FileMode.OpenOrCreate,
       FileAccess.Write);
                os.Write(Encoding.ASCII.GetString(data), 0, data.Length);
            }
            catch (IOException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            finally
            {
                try
                {
                    os.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
    }
}
