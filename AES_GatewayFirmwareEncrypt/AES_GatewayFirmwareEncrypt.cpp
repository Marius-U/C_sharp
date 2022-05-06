// AES_GatewayFirmwareEncrypt.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string.h>
#include "Crypto/myTestHandler.h"


using namespace std;
int main(int argc, char* argv[], char* envp[])
{
    // Walk through list of strings until a NULL is encountered.
    for (int i = 1; i < argc; i++)
    {
        
        cout << argv[i] << "\n";
    }

    bool flag = true;
    if (flag)
    {
        test();
        flag = false;
    }
    system("pause");
}