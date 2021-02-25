using System;
using System.Collections.Generic;
using System.Threading;


namespace Snake2
{
    class Program
    {
        public void game_draw()
        {
            Console.Clear();
            Console.Title = "Snake";
            Console.SetWindowSize(101, 26);
            HorizontalLIne upline = new HorizontalLIne(0, 100, 0, '+');
            HorizontalLIne downline = new HorizontalLIne(0, 100, 25, '+');
            VerticalLine leftline = new VerticalLine(1, 25, 0, '+');
            VerticalLine rightline = new VerticalLine(1, 25, 100, '+');
            upline.Draw();
            downline.Draw();
            leftline.Draw();
            rightline.Draw();
            

            Point p = new Point(4, 5, '*', ConsoleColor.Red);
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            FoodCreator foodCreator = new FoodCreator(101, 26, '¤', ConsoleColor.Green);
            Point food = foodCreator.CreateFood();
            food.Draw();
            Score score = new Score(0, 1);//score =0, level=1
            score.speed = 400;
            score.ScoreWrite();
            while (true)
            {
                if (snake.Eat(food))
                {
                    score.ScoreUp();
                    score.ScoreWrite();
                    food = foodCreator.CreateFood();
                    food.Draw();
                    //sound.Stop("stardust.mp3");
                    if (score.ScoreUp())
                    {
                        score.speed -= 10;
                    }
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(score.speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }
        }

        static void Main(string[] args)
        {
            Start start = new Start();
            if (start.choice() == 1)
            {
                Program prog = new Program();
                prog.game_draw();
            }
            else
            {
                start.Game_stop();
            }


            Console.ReadLine();
        }
    }
}







