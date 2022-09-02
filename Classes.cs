using System.Drawing;

namespace Classes
{
	using System;
	using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
	using System.IO;
    using System.Windows.Forms;
    using static System.Math;

	//Base abstract class
	[Serializable]
	public abstract class Animel: IComparable<Animel>
	{
		float move_x;
		float move_y;
		float x;
		float y;
		float radius;
		float speed;
		bool is_hunter;
		bool is_hunted;     //if the lion "eats" the hunted animel the flag changes to true, and the animel deleted.
		float distance_from_lion;


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
		public bool IS_HUNTER
		{
			get { return is_hunter; }
			set { is_hunter = value; }
		}

		public bool IS_HUNTED
		{
			get { return is_hunted; }
			set { is_hunted = value; }
		}

		public float DISTANCE_FROM_LION
		{
			get { return distance_from_lion; }
			set { distance_from_lion = value; }
		}

		public int CompareTo(Animel other)
		{
			return (DISTANCE_FROM_LION).CompareTo(other.DISTANCE_FROM_LION);
		}

		public abstract void Move(Animel a);                 //the animel moves
		public abstract void Draw(Graphics g);				//draw the animal to screan
	}

	//Base inherited abstruct class
	[Serializable]
	public abstract class Hunter : Animel
	{
		public Hunter()
		{
			IS_HUNTER = true;
		}

		public abstract void Hunt(bool hunt);   //change to hunt mode	-new func	
	}

	//Lion inherited class
	[Serializable]
	public class Lion : Hunter
	{
		const float c_radius = 20;
		/////////////////addad icon
		static Size s_s = new Size((int)c_radius * 2, (int)c_radius * 2);
		static string s_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon s_icon = new Icon(s_path + "\\Pictures\\lion.ico", s_s);

		/////////////////speed consts
		const float rest = 0;
		const float hunt = 10;
		public Lion() : this(0, 0) { }

		public Lion(float xVal, float yVal)
		{
			Console.WriteLine(s_path);
			MOVE_X = 0;
			MOVE_Y = 0;
			X = xVal;
			Y = yVal;
			RADIUS = c_radius;
			SPEED = rest;
			DISTANCE_FROM_LION = -1;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(s_icon, (int)X, (int)Y);
		}

		/// <summary>
		/// change the speed so the lion will attack.
		/// </summary>
		/// <param name="start"></param>
		public override void Hunt(bool start)   //-new func implementation
		{
			if (start == true)
				SPEED = hunt;
			else
				SPEED = rest;
		}

		/// <summary>
		/// search for a hunted animel object, when allocated - move towword it. 
		/// </summary>
		public override void Move(Animel a = null)
		{
			//change move_x and move_y according to need.
			if (SPEED == rest || a == null)     /////////////////////////////addad expression a==null in case that there is no object to hunt
				return;
			double dist;
			int steps;

			//calculate the step towards the Hunted animel
			double x_val = (a.X - this.X);
			double y_val = (a.Y - this.Y);
			dist = Sqrt(x_val * x_val + y_val * y_val);
			steps = (int)(dist / SPEED);
			if (steps != 0)
			{
				this.MOVE_X = (a.X - this.X) / steps;
				this.MOVE_Y = (a.Y - this.Y) / steps;
			}
			//move toward the hunted animel
			X = X + MOVE_X;
			Y = Y + MOVE_Y;

			//if hunted change the flag of the animel to true
			if (dist <= (RADIUS) || steps == 0)   ////////////////////changed radius to this.radius from a.radius
			{
				a.IS_HUNTED = true;
			}
			return;
		}
	}

	//Base inherited abstruct class
	[Serializable]
	public abstract class Hunted : Animel
	{

		public Hunted()
		{
			IS_HUNTER = false;
		}

		

		/// <summary>
		/// calculate the distance from the lion and sets it the the proper property.
		/// </summary>
		/// <param name="a">Lion</param>
		public void SetDistFromLion(Animel a)
		{
			double dist;
			double x_val = (a.X - this.X);
			double y_val = (a.Y - this.Y);
			dist = Sqrt(x_val * x_val + y_val * y_val);
			DISTANCE_FROM_LION = (float)dist;
		}

		public abstract int HowMachISatisfaing();   //return the weight of the annimal for the lion's satisfactory.
	}

	//rabbit inherited class
	[Serializable]
	public class Rabbit : Hunted
	{
		const float c_radius = 10;
		/////////////////addad icon
		static Size s_s = new Size((int)c_radius * 2, (int)c_radius * 2);
		static string s_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon s_icon = new Icon(s_path + "\\Pictures\\rabbit.ico", s_s);

		public Rabbit() : this(0, 0) { }

		public Rabbit(float xVal, float yVal)
		{
			SPEED = 5;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED * SPEED + MOVE_X * MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = c_radius;
			IS_HUNTED = false;
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(s_icon, (int)X, (int)Y);
		}

		/// <summary>
		/// moving forword and change direction when hits a wall.
		/// saves the distance between the lion and the animel in each step of the animel.
		/// </summary>
		/// <param name="a">Lion</param>
		public override void Move(Animel a)
		{
			X = X + MOVE_X;
			Y = Y + MOVE_Y;
			if (X >= 1000 - c_radius * 2 || X <= 0)
				MOVE_X = -MOVE_X;
			if (Y >= 500 - c_radius * 2 || Y <= 0)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}

        public override int HowMachISatisfaing()
        {
            return 2;
        }
    }

	//Giraffe inherited class
	[Serializable]
	public class Giraffe : Hunted
	{
		const float c_radius = 25;
		/////////////////addad icon
		static Size s_s = new Size((int)c_radius * 2, (int)c_radius * 2);
		static string s_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon s_icon = new Icon(s_path + "\\Pictures\\giraffe.ico", s_s);

		public Giraffe() : this(0, 0) { }

		public Giraffe(float xVal, float yVal)
		{
			SPEED = 3;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED * SPEED + MOVE_X * MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = c_radius;
			IS_HUNTED = false;
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(s_icon, (int)X, (int)Y);
		}

		/// <summary>
		/// moving forword and change direction when hits a wall.
		/// saves the distance between the lion and the animel in each step of the animel.
		/// </summary>
		/// <param name="a">Lion</param>
		public override void Move(Animel a)
		{
			X = X + MOVE_X;
			Y = Y + MOVE_Y;
			if (X >= 1000 - c_radius || X <= 0)
				MOVE_X = -MOVE_X;
			if (Y >= 500 - c_radius || Y <= 0)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}

		public override int HowMachISatisfaing()
		{
			return 6;
		}
	}

	//Deer inherited class
	[Serializable]
	public class Deer : Hunted
	{
		const float c_radius = 15;
		/////////////////addad icon
		static Size s_s = new Size((int)c_radius * 2, (int)c_radius * 2);
		static string s_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon s_icon = new Icon(s_path + "\\Pictures\\deer.ico", s_s);

		public Deer() : this(0, 0) { }

		public Deer(float xVal, float yVal)
		{
			SPEED = 13;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED * SPEED + MOVE_X * MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = c_radius;
			IS_HUNTED = false;
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(s_icon, (int)X, (int)Y);
		}

		/// <summary>
		/// moving forword and change direction when hits a wall.
		/// saves the distance between the lion and the animel in each step of the animel.
		/// </summary>
		/// <param name="a">Lion</param>
		public override void Move(Animel a)
		{
			X = X + MOVE_X;
			Y = Y + MOVE_Y;
			if (X >= 1000 - c_radius || X <= 0)
				MOVE_X = -MOVE_X;
			if (Y >= 500 - c_radius || Y <= 0)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}

		public override int HowMachISatisfaing()
		{
			return 3;
		}
	}

	//Deer inherited class
	[Serializable]
	public class Zebra : Hunted
	{
		const float c_radius = 15;
		/////////////////addad icon
		static Size s_s = new Size((int)c_radius * 2, (int)c_radius * 2);
		static string s_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon s_icon = new Icon(s_path + "\\Pictures\\zebra.ico", s_s);

		public Zebra() : this(0, 0) { }

		public Zebra(float xVal, float yVal)
		{
			SPEED = 11;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED * SPEED + MOVE_X * MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = c_radius;
			IS_HUNTED = false;
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(s_icon, (int)X, (int)Y);
		}

		/// <summary>
		/// moving forword and change direction when hits a wall.
		/// saves the distance between the lion and the animel in each step of the animel.
		/// </summary>
		/// <param name="a">Lion</param>
		public override void Move(Animel a)
		{
			X = X + MOVE_X;
			Y = Y + MOVE_Y;
			if (X >= 1000 - c_radius || X <= 0)
				MOVE_X = -MOVE_X;
			if (Y >= 500 - c_radius || Y <= 0)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}

		public override int HowMachISatisfaing()
		{
			return 3;
		}
	}

	[Serializable]
    public class AnimelList
    {
        //animels[0] is allways the lion.
        //animels[1] is the hunted widch the lion pursuing.
        protected List<Animel> animels;

        public AnimelList()
        {
            animels = new List<Animel>();
        }

        public int Count()
        {
            return animels.Count;
        }

        public Hunted Get()
        {
            if (animels.Count > 1)
                return ((Hunted)animels[1]);
            return null;
        }

        public Lion Get_lion()
        {
            if (animels.Count != 0)
                return ((Lion)animels[0]);
            return null;
        }

        public void Add(Animel animel)
        {
            animels.Add(animel);
        }

        public int Remove()
        {
			int lion_satisfactory = ((Hunted)animels[1]).HowMachISatisfaing();
            animels.RemoveAt(1);
			return lion_satisfactory;
        }

        public void DrawAll(Graphics g)
        {
            animels.Sort();
            for (int i = 0; i < animels.Count; i++)
                (animels[i]).Draw(g);
        }

        public void Hunt(bool start)
        {
            ((Lion)animels[0]).Hunt(start);
        }

        /// <summary>
        /// moves all the hunted objects.
        /// must come before the lion's movement.
        /// </summary>
        /// <param name="lion"></param>
        public int MoveAll()
        {
            if (animels.Count > 1)
                if ((animels[1]).IS_HUNTED)
                    return Remove();
            if (animels.Count > 1)
                animels[0].Move(animels[1]);
            for (int i = 1; i < animels.Count; i++)
            {
                (animels[i]).Move(animels[0]);
            }
			return 0;
        }

    }

    
}
