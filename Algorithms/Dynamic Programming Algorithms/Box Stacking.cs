namespace AlgorithmsDSNetCore7
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Runtime.Intrinsics.Arm;

    public class Program
    {
        static void Main()
        {
            var boxesCount = int.Parse(Console.ReadLine());

            var boxes = new Box[boxesCount];

            for (int i = 0; i < boxesCount; i++)
            {
                var inp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                boxes[i] = new Box(inp[0], inp[1], inp[2]);
            }

            Console.WriteLine(MaxStackHeight(boxes, boxesCount));
        }

        private static int MaxStackHeight(Box[] boxes, int boxesCount)
        {
            var rot = new Box[boxesCount * 3];

            for (int i = 0; i < boxesCount; i++)
            {
                Box box = boxes[i];

                rot[3 * i] = new Box(box.Height, Math.Max(box.Width, box.Depth),
                                        Math.Min(box.Width, box.Depth));

                rot[3 * i + 1] = new Box(box.Width, Math.Max(box.Height, box.Depth),
                                           Math.Min(box.Height, box.Depth));

                rot[3 * i + 2] = new Box(box.Depth, Math.Max(box.Width, box.Height),
                                           Math.Min(box.Width, box.Height));
            }

            for (int i = 0; i < rot.Length; i++)
            {
                rot[i].Area = rot[i].Width * rot[i].Depth;
            }

            Array.Sort(rot);

            var count = 3 * boxesCount;

            int[] msh = new int[count];

            for (int i = 0; i < count; i++)
            {
                msh[i] = rot[i].Height;
            }

            for (int i = 0; i < count; i++)
            {
                msh[i] = 0;
                Box box = rot[i];
                int val = 0;

                for (int j = 0; j < i; j++)
                {
                    Box prevBox = rot[j];

                    if (box.Width < prevBox.Width && box.Depth < prevBox.Depth)
                    {
                        val = Math.Max(val, msh[j]);
                    }
                }
                msh[i] = val + box.Height;
            }

            return msh.Max();
        }
    }

    public class Box : IComparable<Box>
    {
        public Box(int height, int width, int depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Area { get; set; }

        public int CompareTo(Box? other)
        {
            return other.Area - this.Area;
        }
    }
}

