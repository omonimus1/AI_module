#include <iostream>
#include <sys/stat.h>
#include <unistd.h>
#include <string>
#include <fstream>
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
        input_file_name += ".bat";
        if(! DoesFileExists(input_file_name))
        {
            cout <<"The file name indicated has not been found, mind to indicate the file without the format extensioon .bat"<<endl;
            return 0; 
        }
        else
        {
            cout <<"File found"<<endl;
        }
    }
    
    /*
    // Loop through each argument and print its number and value
    for (int count{ 0 }; count < argc; ++count)
    {
        cout << count << ' ' << argv[count] << '\n';
    }
    */


    return 0; 
}