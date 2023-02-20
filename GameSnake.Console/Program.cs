using GameSnake.InConsole;
using System.Diagnostics;

Board board = new Board(30,20);
Snake snake = new Snake(board);
Apple apple = new Apple(board);
board.DrawBoard();

int interval = 200;

DateTime nextTime = DateTime.Now.AddMilliseconds(interval);

while (snake.GetLifes() > 0)
{
    if (DateTime.Now >= nextTime)
    {
        board.DrawStats(snake);
        board.DrawApple(apple);
        board.ClearPosition(snake);
        snake.Move();
        apple = snake.EatAppel(apple,board);
        board.DrawSnake(snake);

        nextTime = DateTime.Now.AddMilliseconds(interval);
        snake.Dead(board);
    } else
    {
        Thread.Sleep(1);
    }
}
board.GameOver();






