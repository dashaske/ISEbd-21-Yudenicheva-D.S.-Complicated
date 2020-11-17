﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAirplane
{
    class Bomber : WarPlane
    {
        public bool Bombs { private set; get; } //бомбы

        private IDopElements boombs;

        /// Ширина отрисовки самолета
        private const int carWidth = 154;

        private const int carHeight = 80;


        /// Дополнительный цвет
        public Color DopColor { private set; get; }

        /// Признак наличия звезды
        public bool Star { private set; get; }

        /// Признак наличия бомб
        public bool Bomb { private set; get; }

        /// Признак наличия ракет
        public bool Rocket { private set; get; }

        public Bomber(int maxSpeed, float weight, Color mainColor, Color dopColor, Color bombColor,
        int bombs, int bombsForm, bool rocket, bool bomb, bool star)
            : base(maxSpeed, weight, mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Star = star;
            Rocket = rocket;
            Bomb = bomb;


            if (bombsForm == 0)
            {
                boombs = new BoombsStandart(bombs, bombColor);
            }
            else if (bombsForm == 1)
            {
                boombs = new PointedBoombs(bombs, bombColor);
            }
            else if (bombsForm == 2)
            {
                boombs = new BoombsCircular(bombs, bombColor);
            }
        }
       public override void DrawFly(Graphics g)
        {

            Pen pen = new Pen(Color.Black);
            //рисуем звезду

            if (Rocket)
            {
                g.DrawRectangle(pen, PosX + 80, PosY + 10, 40, 10);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, PosX + 80, PosY + 10, 40, 10);
                g.DrawRectangle(pen, PosX + 80, PosY + 80, 40, 10);
                g.FillRectangle(spoiler, PosX + 80, PosY + 80, 40, 10);
            }
            //рисуем бомбы
            if (Bomb)
            {
                g.DrawEllipse(pen, PosX + 90, PosY, 30, 10);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillEllipse(spoiler, PosX + 90, PosY, 30, 10);
                g.DrawEllipse(pen, PosX + 90, PosY + 90, 30, 10);
                g.FillEllipse(spoiler, PosX + 90, PosY + 90, 30, 10);
            }

            //отрисовка тела
            base.DrawFly(g);

            if (Star)
            {
                Point point1 = new Point((int)PosX + 85, (int)PosY + 60);
                Point point2 = new Point((int)PosX + 90, (int)PosY + 65);
                Point point3 = new Point((int)PosX + 95, (int)PosY + 60);
                Point point4 = new Point((int)PosX + 95, (int)PosY + 90);
                Point point5 = new Point((int)PosX + 90, (int)PosY + 85);
                Point point6 = new Point((int)PosX + 85, (int)PosY + 90);
                Point[] board = { point1, point2, point3, point4, point5, point6 };
                g.DrawPolygon(pen, board);
                Point point7 = new Point((int)PosX + 85, (int)PosY + 10);
                Point point8 = new Point((int)PosX + 90, (int)PosY + 15);
                Point point9 = new Point((int)PosX + 95, (int)PosY + 10);
                Point point10 = new Point((int)PosX + 95, (int)PosY + 40);
                Point point11 = new Point((int)PosX + 90, (int)PosY + 35);
                Point point12 = new Point((int)PosX + 85, (int)PosY + 40);
                Point[] board1 = { point7, point8, point9, point10, point11, point12 };
                g.DrawPolygon(pen, board1);
            }
            boombs.DrawElements(g, PosX, PosY);
        }
    }
}