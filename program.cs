using System;

class Program
{
    static void Main()
    {
        int totalJugador;
        int compun;
        string mensaje = "";
        string switchControl = "menu";
        string nombre = "El";
        int puntosJugador = 0;
        int puntosComputadora = 0;
        int coinsJugador = 0; // Coins iniciales del jugador (se asignarán al inicio)
        int coinsComputadora; // Coins iniciales de la computadora (asignados aleatoriamente)
        int apuesta; // Cantidad apostada
        Random random = new Random();

        // La computadora inicia con una cantidad aleatoria de coins
        coinsComputadora = random.Next(1, 30); // Rango entre º1 y 30 coins

        while (true)
        {
            switch (switchControl)
            {
                case "menu":
                    if (coinsJugador == 0)
                    {
                        Console.WriteLine("Bienvenido al juego de 21");
                        Console.WriteLine("¿Con cuántos coins deseas iniciar?");
                        coinsJugador = int.Parse(Console.ReadLine());
                        Console.WriteLine($"{nombre} tiene {coinsComputadora} coins.");
                        Console.WriteLine("¿Como se llama tu contricante?");
                        nombre = Console.ReadLine();
                    }

                    Console.WriteLine($"Tienes {coinsJugador} coins. {nombre} tiene {coinsComputadora} coins.");
                    Console.WriteLine("Escribe '21' para jugar 21 o 'salir' para terminar:");
                    switchControl = Console.ReadLine();
                    if (switchControl.ToLower() == "21")
                    {
                        switchControl = "21"; // Cambia a la opción de juego
                    }
                    else if (switchControl.ToLower() == "salir")
                    {
                        return; // Termina el programa
                    }
                    break;

                case "21":
                    if (coinsJugador <= 0 || coinsComputadora <= 0)
                    {
                        Console.WriteLine("No tienes suficientes coins o la computadora no tiene más coins. Fin del juego.");
                        return;
                    }

                    Console.WriteLine($"Tienes {coinsJugador} coins. ¿Cuánto deseas apostar?");
                    apuesta = int.Parse(Console.ReadLine());

                    if (apuesta > coinsJugador || apuesta > coinsComputadora)
                    {
                        Console.WriteLine("No puedes apostar más coins de los que tienes o de los que tiene la computadora.");
                        break;
                    }
                    compun = 0;
                    totalJugador = 0; // Reinicia el total del jugador

                    compun = random.Next(1, 13); // Valor de la computadora
                    compun += compun;
                    do
                    {
                        int num = random.Next(1, 12);
                        totalJugador += num;
                        Console.WriteLine("Toma tu carta");
                        Console.WriteLine($"Salió la carta: {num}");
                        Console.WriteLine("¿Deseas otra carta? (si/no)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta != "si")
                            break;

                    } while (true);

                    if (compun > 21)
                    {
                        mensaje = $"¡Ganaste! {nombre} se pasó.";
                        coinsJugador += apuesta;
                        coinsComputadora -= apuesta;
                        puntosJugador++;
                    }
                    else if (totalJugador > compun && totalJugador <= 21)
                    {
                        mensaje = "¡Ganaste!";
                        coinsJugador += apuesta;
                        coinsComputadora -= apuesta;
                        puntosJugador++;
                    }
                    else if (totalJugador == 21)
                    {
                        mensaje = "¡Ganaste con un 21!";
                        coinsJugador += apuesta;
                        coinsComputadora -= apuesta;
                        puntosJugador++;
                    }
                    else if (totalJugador > 21)
                    {
                        mensaje = "Perdiste. Te pasaste de 21.";
                        coinsJugador -= apuesta;
                        coinsComputadora += apuesta;
                        puntosComputadora++;
                    }
                    else if (totalJugador > 21 && compun > 21)
                    {
                        mensaje = "Se pasaron nadie gana esta ronda";
                    }
                    else
                    {
                        mensaje = "Perdiste. La computadora tiene un mejor puntaje.";
                        coinsJugador -= apuesta;
                        coinsComputadora += apuesta;
                        puntosComputadora++;
                    }

                    Console.WriteLine(mensaje);
                    Console.WriteLine($"Tienes {coinsJugador} coins.");
                    Console.WriteLine($"{nombre} tiene {coinsComputadora} coins.\n");
                    Console.WriteLine($"Puntos: Tú: {puntosJugador} | {nombre}: {puntosComputadora}\n");
                    Console.WriteLine($"Tu total es {totalJugador}");
                    Console.WriteLine($"El llevaba {compun}");

                    if (coinsJugador <= 0)
                    {
                        Console.WriteLine("Te has quedado sin coins. Fin del juego.");

                    }

                    if (coinsComputadora <= 0)
                    {
                        Console.WriteLine($"{nombre} se ha quedado sin coins. ¡Has ganado la apuesta!");

                    }

                    switchControl = "menu";
                    break;

                default:
                    Console.WriteLine("Opción no válida. Escribe '21' para jugar o 'salir' para terminar.");
                    switchControl = Console.ReadLine();
                    if (switchControl.ToLower() == "salir")
                        return;
                    break;
            }
        }
    }
}
