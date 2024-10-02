namespace Aufgabe_12;

class Program
{
    static void Main(string[] args)
    {
        doSomething();  // muss einmal vor der Schleife aufgerufen werden
        while (i >= 0) {
            doSomething(); // kann i manipulieren
        }

    }
}