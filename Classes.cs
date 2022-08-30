using System.Drawing;

namespace Classes
{
	using System;
	using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
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
		bool is_hunted;     //if the lion "eats" the hunted animel the flag changes to true, and the animel deleted.


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

		public bool IS_HUNTED
		{
			get { return is_hunted; }
			set { is_hunted = value; }
		}

		public abstract void Move(Animel a = null);                 //the animel moves
		public abstract void Draw(Graphics g);
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
		static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon icon = new Icon(path + "\\Pictures\\lion.ico",s);

		/////////////////speed consts
        const float rest = 0;
        const float hunt = 10;
        public Lion() :this(0, 0) { }

		public Lion(float xVal, float yVal)
        {
			Console.WriteLine(path);
			MOVE_X = 0;
			MOVE_Y = 0;
			X = xVal;
			Y = yVal;
			RADIUS = radius;
			SPEED = rest;
		}

		public override void Draw(Graphics g)
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
        public override void Move(Animel a = null)
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
			steps = (int)(dist / SPEED);
			this.MOVE_X = (a.X - this.X) / steps;
			this.MOVE_Y = (a.Y - this.Y) / steps;
			//move toward the hunted animel
			X = X + MOVE_X;
			Y = Y + MOVE_Y;

			//if hunted change the flag of the animel to true
			if (dist <= (RADIUS))	////////////////////changed radius to this.radius from a.radius
			{
				a.IS_HUNTED = true;
			}
			return;
        }
    }

	//Base inherited abstruct class
	public abstract class Hunted : Animel
	{
		float distance_from_lion;

		public Hunted()
        {
			ISHUNTER = false;
        }

		public float DISTANCE_FROM_LION
        {
            get { return distance_from_lion; }
            set { distance_from_lion = value; }
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

	}

	//rabbit inherited class
	public class Rabbit : Hunted
	{
		const float radius = 10;
		/////////////////addad icon
		static Size s = new Size((int)radius * 2, (int)radius * 2);
		static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon icon = new Icon(path + "\\Pictures\\rabbit.ico", s);

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
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(icon, (int)X, (int)Y);
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
			if (X >= 1000-radius*2 || X <= 0+radius*2)
				MOVE_X = -MOVE_X;
			if (Y >= 500-radius*2 || Y <= 0+radius*2)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}
    }

	//Giraffe inherited class
	public class Giraffe : Hunted
    {
		const float radius = 35;
		/////////////////addad icon
		static Size s = new Size((int)radius * 2, (int)radius * 2);
		static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		static Icon icon = new Icon(path + "\\Pictures\\giraffe.ico", s);

		public Giraffe() : this(0, 0) { }

		public Giraffe(float xVal, float yVal)
		{
			SPEED = 3;
			Random rnd = new Random();
			MOVE_X = rnd.Next(-(int)SPEED, (int)SPEED);
			MOVE_Y = (float)Sqrt(SPEED * SPEED + MOVE_X * MOVE_X);
			X = xVal;
			Y = yVal;
			RADIUS = radius;
			IS_HUNTED = false;
			DISTANCE_FROM_LION = 0;
		}

		public override void Draw(Graphics g)
		{
			g.DrawIcon(icon, (int)X, (int)Y);
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
			if (X >= 1000 - radius * 2 || X <= 0 + radius * 2)
				MOVE_X = -MOVE_X;
			if (Y >= 500 - radius * 2 || Y <= 0 + radius * 2)
				MOVE_Y = -MOVE_Y;
			//calculate distance
			SetDistFromLion(a);
		}
	}

	public class AnimelList
	{
		protected ArrayList animels;

		public AnimelList()
        {
			animels = new ArrayList();
        }
		
		public int Count()
        {
			return animels.Count;
        }

		public Hunted Get()
        {
			if(animels.Count != 0)
				return (Hunted)animels[0];
			return null;
        }

		public void Add(Hunted animel)
        {
			animels.Add(animel);
        }

		public void Remove()
        {
			animels.RemoveAt(0);
        }

		public void DrawAll(Graphics g)
		{
            animels.Sort();
            for (int i = 0; i < animels.Count; i++)
				((Hunted)animels[i]).Draw(g);
		}

		/// <summary>
		/// moves all the hunted objects.
		/// must come before the lion's movement.
		/// </summary>
		/// <param name="lion"></param>
		public void MoveAll(Animel lion)
		{
			if(animels.Count != 0 )
				if (((Hunted)animels[0]).IS_HUNTED)
					Remove();
			for (int i = 0; i < animels.Count; i++)
			{
				((Hunted)animels[i]).Move(lion);
			}
		}

        //TODO: implement sort function.
    }


	///
	/*public class AnimelList
	{
		protected SortedList Animels;

		public AnimelList()
		{
			Animels = new SortedList();
		}

		public void Add(Hunted animel)
        {
			Animels.Add(animel);
        }

		public int NextIndex
		{
			get
			{
				return Animels.Count;
			}
		}

		public void Remove(int element)
		{
			if (Animels.Count != 0)
			{
				Animels.RemoveAt(0);
			}
		}

		public void DrawAll(Graphics g)
		{
			for (int i = 0; i < Animels.Count; i++)
				((Hunted)Animels[i]).Draw(g);
		}

		public void MoveAll(Animel lion)
        {
			for (int i = 0; i < Animels.Count; i++)
				((Hunted)Animels[i]).Move(lion);
        }

	}*/
}
