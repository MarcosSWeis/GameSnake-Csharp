using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSnake.InConsole.Interfaces
{
    public interface IBoard
    {
        public void DrawBoard();
        public void DrawSnake(Snake snake);
        public void DrawApple(Apple apple);
        public void ClearPosition(Snake snake);
        public void GameOver();
        public void DrawStats(Snake snake);

    }
}
