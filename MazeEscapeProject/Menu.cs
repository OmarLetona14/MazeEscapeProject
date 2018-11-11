using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class Menu
    {

        MatrixObject[,] board1;
        RandomNumber random = new RandomNumber();
        Character currentCharacter = null;
        String option, name;
        int board = 0, limitX = 0, 
            limitY = 0, enemys = 0, obstacles = 0, xD, yD;


        public void MainMenu() {
            Console.WriteLine("----- BIENVENIDO A MAZE ESCAPE -----");
            Console.WriteLine("Por favor seleccione una opción: ");
            Console.WriteLine("1. Ingresar el nombre del personaje");
            Console.WriteLine("2. Iniciar juego");
            Console.WriteLine("3. Salir");
            option = Console.ReadLine();

            switch (option) {
                case "1":
                    nameMenu();
                    Console.Clear();
                    Console.WriteLine("Nombre Ingresado correctamente");
                    MainMenu();
                break;
                case "2":
                    boardMenu();
                    GameMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                break;

                default:
                    invalidOption(1);
                    break;

            }

        }

        public void boardMenu() {
            Console.WriteLine("Por favor seleccione el tablero a utilizar: ");
            Console.WriteLine("1. Tablero 1");
            Console.WriteLine("2. Tablero 2");
            Console.WriteLine("3. Tablero 3");
            option = Console.ReadLine();
            switch (option) {
                case "1":
                    generateBoard(1, 5, 5, 4, 4, 10, 5);
                    GameMenu();
                break;
                case "2":
                    generateBoard(2, 6, 6, 5, 5, 15, 10);
                    GameMenu();
                    break;
                case "3":
                    generateBoard(3, 8, 8, 7, 7, 20, 25);
                    GameMenu();
                    break;
                default:
                    invalidOption(2);
                    break;

            }

        }

        //Menu que se inicia inmediatamente despues de introducir el tablero
        public void GameMenu()
        {
           
            Console.WriteLine("*** JUEGO NUEVO ***");
            Console.WriteLine("1. Comandos");
            Console.WriteLine("2. Imprimir Tablero");
            Console.WriteLine("3. Estatus Personaje Principal");
            Console.WriteLine("4. Terminar partida");
            option = Console.ReadLine();
            switch (option) {
                case "1":
                    commandMenu();
                break;
                case "2":
                    printBoard();
                    GameMenu();
                    break;
                case "3":
                    printProfile();
                    GameMenu();
                    break;
                case "4":
                    restartGame();
                    MainMenu();
                    break;
                default:
                    invalidOption(3);
                    break;

            }
        }

        //Menu en donde se ingresa el nombre del personaje
        public void nameMenu() {
            
            Console.WriteLine("Ingrese el nombre del personaje: ");
            try {
                name = Console.ReadLine();
            } catch (Exception e) {
                Console.Clear();
                Console.WriteLine("Nombre invalido, por favor inténtelo de nuevo");
                nameMenu();
            }
            if (alphanumeric(name)) {
                
            }
            else{
                Console.Clear();
                Console.WriteLine("Nombre invalido, por favor inténtelo de nuevo");
                nameMenu();
            }
            
        }

        public void commandMenu() {
            Console.WriteLine("Ingrese un comando");
            Console.WriteLine("1. Mover a la derecha");
            Console.WriteLine("2. Mover a la izquierda");
            Console.WriteLine("3. Mover arriba");
            Console.WriteLine("4. Mover abajo");
            Console.WriteLine("5. Atacar a la izquierda");
            Console.WriteLine("6. Atacar a la derecha");
            Console.WriteLine("7. Atacar arriba");
            Console.WriteLine("8. Atacar abajo");
            Console.WriteLine("9. Regresar");
            option = Console.ReadLine();
            switch (option) {
                case "1":
                    if (currentCharacter.getX() + 1>limitX) {
                        Console.WriteLine("No se puede salir de los margenes del tablero");
                        Console.WriteLine("Se le restará 1 punto al personaje");
                        if (gameOver(currentCharacter.getLife()-1))
                        {
                            restartGame();
                        }
                        else { currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }
                        
                        GameMenu();
                    } else if (board1[currentCharacter.getX() + 1, currentCharacter.getY()].getSimbol().Equals(" ")) {
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX(), " ");

                        board1[currentCharacter.getX(), currentCharacter.getY()] = objecto;
                        currentCharacter.setX(currentCharacter.getX() + 1);
                        board1[currentCharacter.getX(), currentCharacter.getY()] = currentCharacter;
                        Console.WriteLine("Se movio el personaje a la posicion; X: " + currentCharacter.getX() +
                           ", Y: " + currentCharacter.getY());
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX() + 1, currentCharacter.getY()].getSimbol().Equals("X")) {
                        Console.WriteLine("Se ha encontrado con un enemigo, se le restará 1 punto de vida");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }
                    } else if (board1[currentCharacter.getX() + 1, currentCharacter.getY()].getSimbol().Equals("O")) {
                        Console.WriteLine("Se ha encontrado con un obstaculo, permancerá donde está");
                        GameMenu();
                    } else if (board1[currentCharacter.getX() + 1, currentCharacter.getY()].getSimbol().Equals("*")) {
                        Console.WriteLine("***************Encontró la estrella********************");
                        nextLevel(xD, yD, obstacles, enemys);
                    }
                    
                    break;
                case "2":
                    if (currentCharacter.getX() - 1 < 0)
                    {
                        Console.WriteLine("No se puede salir de los margenes del tablero");
                        Console.WriteLine("Se le restará 1 punto al personaje");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }else{currentCharacter.setLife(currentCharacter.getLife() - 1);}
                        GameMenu();}
                    else if (board1[currentCharacter.getX() - 1, currentCharacter.getY()].getSimbol().Equals(" "))
                    {
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX(), " ");

                        board1[currentCharacter.getX(), currentCharacter.getY()] = objecto;
                        currentCharacter.setX(currentCharacter.getX() - 1);
                        board1[currentCharacter.getX(), currentCharacter.getY()] = currentCharacter;
                        Console.WriteLine("Se movio el personaje a la posicion; X: " + currentCharacter.getX() +
                           ", Y: " + currentCharacter.getY());
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX() - 1, currentCharacter.getY()].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Se ha encontrado con un enemigo, se le restará 1 punto de vida");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }
                    }
                    else if (board1[currentCharacter.getX() - 1, currentCharacter.getY()].getSimbol().Equals("O"))
                    {
                        Console.WriteLine("Se ha encontrado con un obstaculo, permancerá donde está");
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX() - 1, currentCharacter.getY()].getSimbol().Equals("*"))
                    {
                        Console.WriteLine("***************Encontró la estrella********************");
                        nextLevel(xD,yD,obstacles, enemys );
                    }
                    break;
                case "3":
                    if (currentCharacter.getY() - 1 > limitY)
                    {
                        Console.WriteLine("No se puede salir de los margenes del tablero");
                        Console.WriteLine("Se le restará 1 punto al personaje");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }

                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()-1].getSimbol().Equals(" "))
                    {
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX(), " ");

                        board1[currentCharacter.getX(), currentCharacter.getY()] = objecto;
                        currentCharacter.setY(currentCharacter.getY() - 1);
                        board1[currentCharacter.getX(), currentCharacter.getY()] = currentCharacter;
                        Console.WriteLine("Se movio el personaje a la posicion; X: " + currentCharacter.getX() +
                           ", Y: " + currentCharacter.getY());
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()-1].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Se ha encontrado con un enemigo, se le restará 1 punto de vida");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()-1].getSimbol().Equals("O"))
                    {
                        Console.WriteLine("Se ha encontrado con un obstaculo, permancerá donde está");
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()-1].getSimbol().Equals("*"))
                    {
                        Console.WriteLine("***************Encontró la estrella********************");
                        nextLevel(xD, yD, obstacles, enemys);
                    }
                    break;
                case "4":
                    if (currentCharacter.getY() + 1 >limitX)
                    {
                        Console.WriteLine("No se puede salir de los margenes del tablero");
                        Console.WriteLine("Se le restará 1 punto al personaje");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }

                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()+1].getSimbol().Equals(" "))
                    {
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX(), " ");

                        board1[currentCharacter.getX(), currentCharacter.getY()] = objecto;
                        currentCharacter.setY(currentCharacter.getY() + 1);
                        board1[currentCharacter.getX(), currentCharacter.getY()] = currentCharacter;
                        Console.WriteLine("Se movio el personaje a la posicion; X: " + currentCharacter.getX() +
                           ", Y: " + currentCharacter.getY());
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()+1].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Se ha encontrado con un enemigo, se le restará 1 punto de vida");
                        if (gameOver(currentCharacter.getLife() - 1))
                        {
                            restartGame();
                        }
                        else
                        {
                            currentCharacter.setLife(currentCharacter.getLife() - 1);
                        }
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()+1].getSimbol().Equals("O"))
                    {
                        Console.WriteLine("Se ha encontrado con un obstaculo, permancerá donde está");
                        GameMenu();
                    }
                    else if (board1[currentCharacter.getX(), currentCharacter.getY()+1].getSimbol().Equals("*"))
                    {
                        Console.WriteLine("***************Encontró la estrella********************");
                        nextLevel(xD, yD, obstacles, enemys);
                    }
                    break;
                case "5":
                    if (currentCharacter.getX() - 1 < 0)
                    {
                        Console.WriteLine("No hay ningun enemigo en esta posición");
                        GameMenu();
                    }
                    
                    else if (board1[currentCharacter.getX() - 1, currentCharacter.getY()].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Ha eliminado a un enemigo");
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX() - 1, " ");
                        board1[currentCharacter.getX() - 1, currentCharacter.getY()] = objecto;

                        GameMenu();
                    }
                    else{
                        Console.WriteLine("El ataque no tuvo efecto");
                        GameMenu();
                    }
                    
                    break;
                case "6":
                    if (currentCharacter.getX() + 1 > limitX)
                    {
                        Console.WriteLine("No hay ningun enemigo en esta posicion");
                        GameMenu();
                    }

                    else if (board1[currentCharacter.getX() + 1, currentCharacter.getY()].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Ha eliminado a un enemigo");
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY(), currentCharacter.getX() + 1, " ");
                        board1[currentCharacter.getX() + 1, currentCharacter.getY()] = objecto;

                        GameMenu();
                    }
                    else
                    {
                        Console.WriteLine("El ataque no tuvo efecto");
                        GameMenu();
                    }
                    break;
                case "7":
                    if (currentCharacter.getY() - 1 <0)
                    {
                        Console.WriteLine("No hay ningun enemigo en esta posicion");
                        GameMenu();
                    }

                    else if (board1[currentCharacter.getX(), currentCharacter.getY() - 1].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Ha eliminado a un enemigo");
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY()-1, currentCharacter.getX(), " ");
                        board1[currentCharacter.getX(), currentCharacter.getY()-1] = objecto;

                        GameMenu();
                    }
                    else
                    {
                        Console.WriteLine("El ataque no tuvo efecto");
                        GameMenu();
                    }
                    break;
                case "8":
                    if (currentCharacter.getY() + 1 > limitY)
                    {
                        Console.WriteLine("No hay ningun enemigo en esta posicion");
                        GameMenu();
                    }

                    else if (board1[currentCharacter.getX(), currentCharacter.getY()+1].getSimbol().Equals("X"))
                    {
                        Console.WriteLine("Ha eliminado a un enemigo");
                        MatrixObject objecto = new MatrixObject(0, currentCharacter.getY()+1, currentCharacter.getX(), " ");
                        board1[currentCharacter.getX(), currentCharacter.getY()+1] = objecto;

                        GameMenu();
                    }
                    else
                    {
                        Console.WriteLine("El ataque no tuvo efecto");
                        GameMenu();
                    }
                    break;
                case "9":
                    GameMenu();
                    break;
                default:
                    invalidOption(4);
                    break;
            }

        }

        //Verifica si el valor de nombre ingresado es de caracter alfanumerico
        public Boolean alphanumeric(String value) {
            Boolean check = true;
            while (String.IsNullOrWhiteSpace(value)
                 || !value.All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c)))
            {
                check = false;
            }
            return check;
        }
        //Impreme todas las caracteristicas del personaje principal
        public void printProfile() {
            if (currentCharacter.getName() != null)
            {
                Console.WriteLine("Nombre del personaje: " + currentCharacter.getName());
                Console.WriteLine("Vida del personaje: " + currentCharacter.getLife());
                Console.WriteLine("Ubicacion del personaje\n" +
                    "En X: "+ currentCharacter.getX() + "\n"
                    +"En Y: "+ currentCharacter.getY());
            }
            else {
                Console.WriteLine("Nombre del personaje: " + "Aun no ha configurado un nombre para el" +
                    " personaje");
                Console.WriteLine("Vida del personaje: " + currentCharacter.getLife());
                Console.WriteLine("Ubicacion del personaje\n" +
                    "En X: " + currentCharacter.getX()
                    + "En Y: " + currentCharacter.getY());
            }
            
        }

        public void generateBoard(int board, int xDimension, int yDimension, int limitX, int limitY, int limObstacles, int limEnemys) {
                    Console.WriteLine("Generando tablero...");
                    this.board = board;this.limitX = limitX;this.limitY = limitY;this.obstacles = limObstacles;
                    this.enemys = limEnemys; this.xD = xDimension; this.yD = yDimension;
                    int star = 1, currObstacles = 1, currEnemys = 1;
                    board1 = new MatrixObject[xDimension, yDimension];
                    for (int y = 0; y <= limitY; y++)
                    {
                        for (int x = 0; x <= limitX; x++)
                        {
                            MatrixObject objecto = new MatrixObject(0, y, x, " ");
                            board1[y, x] = objecto;
                        }
                    }
                    currentCharacter = new Character(name, 5, 3, limitX, 0, "%");
                    board1[0, limitX] = currentCharacter;
                    while (star <= 1)
                    {
                        int randX = random.generateRandomX(board);
                        int randY = random.generateRandomY(board);
                        if (board1[randX, randY].getSimbol().Equals(" "))
                        {
                            Star nuevaEstrella = new Star(2, randY, randX, "*");
                            board1[randX, randY] = nuevaEstrella;
                            star++;
                        }
                    }

                    while (currObstacles <= limObstacles)
                    {
                        int randX = random.generateRandomX(board);
                        int randY = random.generateRandomY(board);
                        if (board1[randX, randY].getSimbol().Equals(" ") &&
                    isStarAlone(randX, randY, limitX, limitY))
                {
                            Obstacle nuevoObstaculo = new Obstacle(1, randY, randX, "O");
                            board1[randX, randY] = nuevoObstaculo;
                            currObstacles++;
                        }
                    }
                    while (currEnemys <= limEnemys)
                    {
                        int randX = random.generateRandomX(board);
                        int randY = random.generateRandomY(board);
                        if (board1[randX, randY].getSimbol().Equals(" "))
                        {
                            Enemy nuevoEnemigo = new Enemy(-1, randY, randX, "X");
                            board1[randX, randY] = nuevoEnemigo;
                            currEnemys++;
                        }
                    }
                    Console.WriteLine("Tablero generado correctamente");
            
        }

        //Imprime en consola el contenido de la matriz
        public void printBoard() {
            String line = "";
            for (int y = 0; y <= limitY + 1; y++)
            {
                if (y != 0 && !(y >= limitY + 2))
                {
                    Console.WriteLine(line);
                    line = "";
                }
                for (int x = 0; x <= limitX; x++)
                {
                    if (!(y >= limitY + 1))
                    {
                        line += "|" + board1[x, y].getSimbol() + "|";
                    }
                }
            }
        }
        //Reinicia el juego 
        public void restartGame() {
            Console.WriteLine("***************GAME OVER***************");
            board1 = null;
            MainMenu();
        }

        public void nextLevel(int x, int y, int ob, int en) {
            Console.WriteLine("\n***************SIGUIENTE NIVEL***************");
            generateBoard(board, x, y, limitX, limitY, ob, en);
        }

        public Boolean gameOver(int life) {
            if (life <= 0) {
                return true;
            }
            return false;
        }

        public void invalidOption(int menu) {
            Console.WriteLine("************* OPCION INVALIDA ************** \n\n");
            switch (menu) {
                case 1:
                    MainMenu();
                    break;
                case 2:
                    boardMenu();
                    break;
                case 3:
                    GameMenu();
                    break;
                case 4:
                    commandMenu();
                    break;

            }
        }

        public Boolean isStarAlone(int xR,int yR,int xLim, int yLim) {
            int count = 0;
            int count2 = 0;
            Boolean condition = false;
            if (xR + 1 <= xLim) {
                if (board1[xR + 1, yR].getSimbol().Equals("*"))
                { return false; }
                else { count += 1; }
            }
            else { count2 += 1; }
            if (!(xR - 1 < 0)) {
                if (board1[xR - 1, yR].getSimbol().Equals("*"))
                { return false; }
                else { count += 1; }
            }
            else { count2 += 1; }
            if (yR + 1 <= yLim) {
                if (board1[xR, yR + 1].getSimbol().Equals("*"))
                { return false; }
                else { count += 1; }
            }
            else { count2 += 1; }
            if (!(yR - 1 < 0)) {
                if (board1[xR, yR - 1].getSimbol().Equals("*"))
                { return false; }
                else { count += 1; }
            }
            else { count2 += 1; }
            if (count +count2 ==4) {
                condition = true;
            }
            return condition;
        }

    }
}
