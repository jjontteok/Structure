using System;

namespace nayeong
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }

        public Node(T data, Node<T> next = null)
        {
            Data = data;
            NextNode = next;
        }
    }

    //맨 밑의 있는 노드의 NextNode가 null
    public class LinkedStack<T>
    {
        Node<T> _top;   //최상위 노드
        int _count;     //스택의 현재 노드 개수
        int _capacity;  //스택 최대 용량

        public LinkedStack()
        {
            _top = null;
            _count = 0;
            _capacity = 5;
        }

        //스택에 데이터를 넣는 함수

        public void Push(T data)
        {
            if (IsFull)
                throw new InvalidOperationException("스택이 꽉 차 있습니다.");

            Node<T> newNode = new Node<T>(data, _top);
            _top = newNode;
            _count++;
        }

        //스택에서 최상위 데이터를 반환하는 함수
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("스택이 비어 있습니다.");

            Node<T> remove = _top;  //최상위 노드
            _top = _top.NextNode;   //이전 노드를 최상위 노드로
            _count--;

            return remove.Data;
        }

        //스택에서 최상위 데이터를 제거하지 않고 반환하는 함수
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("스택이 비어 있습니다.");

            return _top.Data;
        }

        bool IsFull => _count >= _capacity;
        bool IsEmpty => _count == 0;

        public int Count => _count;
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);

            Console.WriteLine($"Stack Count : {stack.Count}");

            Console.WriteLine($"Stack Peek : {stack.Peek()}");

            Console.WriteLine($"Stack Pop : {stack.Pop()}");
            Console.WriteLine($"Stack Pop : {stack.Pop()}");
        }
    }
}
