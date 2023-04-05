// See https://aka.ms/new-console-template for more information
//Note that this will not work on anything *NIX-based as I'm using some things unique to windows/NTFS
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

SHA1 sha1Hash = SHA1.Create();
int fileCount = Directory.GetFiles("Files\\", "*").Length; //number of files in the folder we'll be using

WriteLine(fileCount);

List<String> plaintextFiles = new();

string hash(string str)
{
    byte[] hashBytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
    return hash;
}

string rehash(List<String> input, int count = 1)
{
    List<String> newStuff = new();

    WriteLine("Hashes from Re-hash #{0}", count);

    for (int i = 0; i < input.Count; i += 2)
    {
        string newHash = hash(input[i] + input[i + 1]);
        newStuff.Add(newHash);
    }

    if (newStuff.Count % 2 != 0 && newStuff.Count != 1)
        newStuff.Add(newStuff[newStuff.Count - 1]);

    foreach (var v in newStuff)
        WriteLine(v);

    WriteLine("");

    return (newStuff.Count == 1) ? newStuff[0] : rehash(newStuff, ++count);
}

//Driver Code

foreach (var file in Directory.GetFiles("Files\\", "*"))
{
    string st = File.ReadAllText(file);
    //WriteLine(st);
    plaintextFiles.Add(st);
}

if (plaintextFiles.Count % 2 != 0)
{
    plaintextFiles.Add(plaintextFiles[plaintextFiles.Count - 1]);
}

List<String> ctf = new();


foreach (var str in plaintextFiles)
    ctf.Add(hash(str));


WriteLine("Original Hashes for the files: ");

foreach (var b in ctf)
{
    WriteLine(b);
}

WriteLine("\n");

string output = rehash(ctf);

WriteLine("\nFinal output: ");

WriteLine(output);