// AES_GatewayFirmwareEncrypt.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string.h>
#include "Crypto/myTestHandler.h"
#include <filesystem>

using namespace std;
using namespace std::filesystem;


int main(int argc, char* argv[], char* envp[])
{
    // Walk through list of strings until a NULL is encountered.
    for (int i = 1; i < argc; i++)
    {
        
        cout << argv[i] << "\n\n\n";
    }

    path pathToFirmware(argv[argc - 1]);

    cout << endl;
    cout << endl;
    cout << pathToFirmware.parent_path() << endl;
    cout << pathToFirmware.filename() << endl;
    cout << endl;

    bool flag = true;
    if (flag)
    {
        test();
        flag = false;
    }

   // system("pause");
}