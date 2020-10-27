#include <iostream>
#include <sys/stat.h>
#include <unistd.h>
#include <sstream>
#include <string>
#include <fstream>
#include <vector>
using namespace std;

bool DoesFileExists(string fileName)
{
    std::ifstream infile(fileName);
    return infile.good();
}


int main(int argc, char** argv) 
{
    // I need to pass the argument when when running with ./a.out
    //cout << "There are " << argc << " arguments:\n";
    if(argc != 2)
    {
        cout << "To the program start, the name of the file input must be proviveded"<<endl;
        cout <<"Run again the application indicating the name of input file name" <<endl;
        return 0; 
    }
    else
    {
        string input_file_name = argv[1];
        string output_file_name = input_file_name + ".csn";
        input_file_name += ".cav";
        if(! DoesFileExists(input_file_name))
        {
            cout <<"The file name indicated has not been found, mind to indicate the file without the format extensioon .bat"<<endl;
            return 0; 
        }
        else
        {
            cout <<"File found"<<endl;

            // Open stream file, il primo numero e' il numero di vertici nel grafo; 
            ifstream infile; 
             infile.open(input_file_name);
    
                // Read Input
                vector<int> vect;
                std::string str;
                while (getline(infile ,str)) {
                    std::stringstream ss(str);

                    for (int i; ss >> i;) {
                        vect.push_back(i);    
                        if (ss.peek() == ',')
                            ss.ignore();
                    }
                    
                    for (int i = 0; i < vect.size(); i++)
                        cout << vect[i] << " ";
                }

                // Store number of vertext; 
                unsigned long int number_caves = vect[0];

                /*
                    // Read boolean for adjency matrix
                    for(int i = number_caves*2 +1; i< vect.size(); i++);
                */

        }
    }

    return 0; 
}