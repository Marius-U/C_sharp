// AES_GatewayFirmwareEncrypt.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <fstream>
#include <string.h>
#include "Crypto/myTestHandler.h"
#include <filesystem>

using namespace std;
using namespace std::filesystem;

void encrypt(BlockCipher* cipher, uint8_t* plainData);
void decrypt(BlockCipher* cipher, uint8_t* encryptedData);

ifstream plainFirmwareFile;
fstream cypheredFirmwareFile;

const uint8_t key[16] = {(uint8_t)0x00, (uint8_t)0x01, (uint8_t)0x02, (uint8_t)0x03,
                         (uint8_t)0x04, (uint8_t)0x05, (uint8_t)0x06, (uint8_t)0x07,
                         (uint8_t)0x08, (uint8_t)0x09, (uint8_t)0x0A, (uint8_t)0x0B,
                         (uint8_t)0x0C, (uint8_t)0x0D, (uint8_t)0x0E, (uint8_t)0x0F };
uint8_t encryptBuffer[16];
AES128 myAES128;


int main(int argc, char* argv[], char* envp[])
{
    //Create the PATH object from the first passed argument
    path pathToFirmware(argv[argc - 1]);

    string inPath = pathToFirmware.root_path().string().append(pathToFirmware.relative_path().string());
    string outPath = pathToFirmware.parent_path().string().append("\\cyphered_").append(pathToFirmware.filename().string());


    unsigned char data[16] = {0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u,
                              0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u, 0x00u};

    plainFirmwareFile.open(inPath, ios::in| ios::binary);
    cypheredFirmwareFile.open(outPath, ios::out| ios::binary);


    if (plainFirmwareFile)
    {
        plainFirmwareFile.seekg(ios::beg);
        plainFirmwareFile.read(reinterpret_cast<char*>(data), 16 * sizeof(unsigned char));

        //encrypt data and lace it in the buffer
        encrypt(&myAES128, data);

        plainFirmwareFile.close();
    }
    else
    {
        cout << "Input file could not be opened!" << endl;
    }   

    if (cypheredFirmwareFile)
    {
        cypheredFirmwareFile.seekp(ios::beg);
        cypheredFirmwareFile.write(reinterpret_cast<char*>(encryptBuffer), 16 * sizeof(unsigned char));

        decrypt(&myAES128, encryptBuffer);
        cypheredFirmwareFile.write(reinterpret_cast<char*>(encryptBuffer), 16 * sizeof(unsigned char));

        cypheredFirmwareFile.close();
    }
    else
    {
        cout << "Out file could not be opened!" << endl;
    }
    

    bool flag = false;
    if (flag)
    {
        test();
        flag = false;
    }

   // system("pause");
}

void encrypt(BlockCipher* cipher, uint8_t* plainData)
{
    crypto_feed_watchdog();

    cipher->setKey(key, cipher->keySize());

    cipher->encryptBlock(encryptBuffer, plainData);
}

void decrypt(BlockCipher* cipher, uint8_t* encryptedData)
{
    crypto_feed_watchdog();

    cipher->setKey(key, cipher->keySize());

    cipher->decryptBlock(encryptBuffer, encryptedData);
}