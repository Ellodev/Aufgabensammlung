Console.Write("Please enter a decimal number to be converted: ");


bool validInput = false;
int decimalNumber = 0;
int[] binary = new int[64];
int i = 0;

while (!validInput)
{
    string input = Console.ReadLine();
    if (int.TryParse(input, out decimalNumber)) {
        validInput = true;
    }

}

while (decimalNumber > 0)
{
    binary[i] = decimalNumber % 2;
    decimalNumber = decimalNumber / 2;
    i++;
}

Console.Write("Binary representation: ");
for (int j = i - 1; j >= 0; j--)
{
    Console.Write(binary[j]);
}