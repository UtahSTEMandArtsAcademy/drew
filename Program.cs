using System.Security.Cryptography;
using System.Text;


string input = "1";
int output = 0;
string hash;

do{
    output++;
    byte[] bytes = Encoding.ASCII.GetBytes(input + output);
    bytes = MD5.Create().ComputeHash(bytes);
    hash = string.Join("", bytes.Select(a => a.ToString("x2")));
    
}while(!hash.StartsWith("000000"));
Console.WriteLine(input + " " + output + " " + hash);
