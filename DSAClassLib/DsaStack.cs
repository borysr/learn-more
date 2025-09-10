using System.Net.Sockets;

namespace DSAClassLib
{
    public static class DsaStack
    {
        public static string StackReverse(string input)
        {
            Stack<char> stack = new Stack<char>();
            var charList = new List<char>();
            foreach (char c in input)
            {
                stack.Push(c);
            }
            while (stack.Count > 0)
            {
                charList.Add(stack.Pop());
            }
            return string.Join("", charList);
        }
    }

    public class HanoiTower
    {
        public Stack<int> From { get; private set; }
        public Stack<int> To { get; private set; }
        public Stack<int> Aux { get; private set; }
        public int DiscsCount { get; private set; }
        public int MovesCount { get; private set; }
        public event EventHandler<EventArgs>? MovesCompleted;

        public HanoiTower(int disks)
        {
            To = new Stack<int>();
            Aux = new Stack<int>();
            From = new Stack<int>();
            DiscsCount = disks;
            for (int i = 0; i < DiscsCount; i++)
            {
                int size = disks - i;
                From.Push(size);
            }
        }
        public void Start()
        {
            Move(DiscsCount, From, To, Aux);
        }

        public void Move(int disks, Stack<int> from, Stack<int> to, Stack<int> aux)
        {
            if (disks > 1)
            {
                Move(disks - 1, from, aux, to);
                to.Push(from.Pop());
                MovesCount++;
                MovesCompleted?.Invoke(this, EventArgs.Empty);

                Move(disks - 1, aux, to, from);
            }
        }
    }
}
