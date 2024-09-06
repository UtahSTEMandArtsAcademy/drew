string input = @"";
List<string> letters = new();

for(int y = 0; y < 26; y++)
{
    for(int x = -1; x < 26; x++)
    {
        string pair = "";
        char firstLetter = Convert.ToChar(97+x);
        if(x != -1) pair += firstLetter;
        char secondLetter = Convert.ToChar(97+y);
        pair += secondLetter;
        letters.Add(pair);
    }
}
foreach(string cmd in input.Split("\n"))
{
    string[] parts = cmd.Split(" ");
    
}
for(int i = 0; i < 26; i++){
    Console.WriteLine(string.Join(", ", letters.Slice(i * 27, 27)));
}