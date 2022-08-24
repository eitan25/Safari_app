using System.Drawing;

namespace Classes
{
	using System;
	using System.Collections;
	using System.Drawing.Imaging;
	using static System.Math;

	//Base abstract class
	public abstract class Animel
	{
		float move_x;
		float move_y;
		float x;
		float y;
		float radius;
		float speed;
		bool isHunter;

		public float MOVE_X
        {
            get { return move_x; }
			set { move_x = value; }
        }
		public float MOVE_Y
		{
			get { return move_y; }
			set { move_y = value; }
		}
		public float X
        {
            get { return x; }
            set { x = value; }
        }
		public float Y
		{
			get { return y; }
			set { y = value; }
		}
		public float RADIUS
		{
			get { return radius; }
			set { radius = value; }
		}
		public float SPEED {
            get { return speed; }
            set { speed = value; }
		}
		public bool ISHUNTER
		{
			get { return isHunter; }
			set { isHunter = value; }
		}

		public abstract void Move(Hunted a = null);					//the animel moves
	}

	//Base inherited abstruct class
	public abstract class hunter:Animel
    {
		public hunter()
        {
			ISHUNTER = true;
		}
		
		public abstract void Hunt(bool hunt);	//change to hunt mode	-new func	
	}

	//Lion inherited class
	public class Lion : hunter
    {
		const float radius = 20;
		/////////////////addad icon
		static Size s = new Size((int)radius * 2, (int)radius * 2);
		static Icon icon = new Icon("/Users/aytan/source/repos/Safari_app/Safari_app/Pictures/lion.ico",s);
        const float rest = 0;
        const float hunt = 10;
        public Lion() :this(0, 0) { }

		public Lion(float xVal, float yVal)
        {
			MOVE_X = 0;
			MOVE_Y = 0;
			X = xVal;
			Y = yVal;
			RADIUS = radius;
			SPEED = rest;
		}

		public void Draw(Graphics g)
        {
			g.DrawIcon(icon,(int)X,(int)Y);
        }

		/// <summary>
		/// change the speed so the lion will attack.
		/// </summary>
		/// <param name="start"></param>
        public override void Hunt(bool start)	//-new func implementation
        {
			if (start == true)
				SPEED = hunt;
			else
				SPEED = rest;
        }

		/// <summary>
		/// search for a hunted animel object, when allocated - move towword it. 
		/// </summary>
        public override void Move(Hunted a)
        {
			//change move_x and move_y according to need.
			if (SPEED == rest || a==null)		/////////////////////////////addad expression a==null in case that there is no object to hunt
				return;
			double dist;
			int steps;
			
			//calculate the step towards the Hunted animel
			double x_val = (a.X - this.X);
			double y_val = (a.Y - this.Y);
			dist = Sqrt(x_val * x_val + y_val * y_val);
			steps = (int)(dist / SPEED) + 1;
			this.MOVE_X = (a.X - this.X) / steps;
			this.MOVE_Y = (a.Y - this.Y) / steps;
			//move toward the hunted animel
			X = X + MOVE_X;
			Y = Y + MOVE_Y;

			//if hunted change the flag of the animel to true
			if (dist < (RADIUS))	////////////////////changed radius to this.radius from a.radius
			{
				a.IS_HUNTED = true;
			}
			return;
        }
    }

	//Base inherited abstruct class
	public abstract class Hunted : Animel
	{
		//if the lion "eats" the hunted animel the flag changes to true, and the animel deleted.
		bool is_hunted;

		public Hunted()
        {
			ISHUNTER = false;
        }

		public bool IS_HUNTED
        {
            get { return is_hunted; }
			set { is_hunted = value; }
        }

	}

	//rabbit inherited class
	public class Rabbit : Hunted
    {
		const float radius = 10;
		/////////////////addad icon
		static Size s = new Size((int)radius * 2, (int)radius * 2);
		static Icon icon = new Icon("/Users/aytan/source/repos/Safari_app/Safari_app/Pictures/rabbit.ico", s);

		public Rabbit() : this(0, 0) { }

		public Rabbit(float xVal, float yVal)
		{
			SPEED = 5;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED*SPEED + MOVE_X*MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = radius;
			IS_HUNTED = false;
		}

		public void Draw(Graphics g)
		{
			g.DrawIcon(icon, (int)X, (int)Y);
		}

		/// <summary>
		/// moving forword and chage direction when hits a wall.
		/// </summary>
		public override void Move(Hunted a = null)
		{
			X = X + MOVE_X;
			Y = Y + MOVE_Y;
			if (X >= 1000 || X<=0)
				MOVE_X = -MOVE_X;
			if (Y >= 500 || Y<=0)
				MOVE_Y = -MOVE_Y;
        }
    }
}
