using System;

namespace nayeong
{
    public class MyArrayStack<T>
    {
        T[] _items;
        int _top;
        int _capacity = 5;

        public MyArrayStack()
        {
            _items = new T[_capacity];
            _top = 0;
        }

        //스택에 요소를 넣는 함수
        public void Push(T item)
        {
             if(IsFull)
                throw new InvalidOperationException("스택 용량이 꽉 찼습니다.");
            _items[_top++] = item;

        }

        //스택에서 요소를 빼내는 함수
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("스택이 비어 있습니다");

            T item = _items[--_top];
            _items[_top] = default;
            return item;
        }

        //스택에서 최상위 요소를 제거하지 않고 보여주는 함수
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("스택이 비어 있습니다.");
            return _items[_top - 1];
        }


        public int Count => _top;           //스택의 현재 요소 개수를 반환하는 함수
        bool IsFull => _top == _capacity;   //스택이 차 있는지 확인하는 함수
        bool IsEmpty => _top == 0;          //스택이 비어 있는지 확인하는 함수
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyArrayStack<int> stack = new MyArrayStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Stack Count : {stack.Count}");
            Console.WriteLine($"Stack Peek : {stack.Peek()}");

            Console.WriteLine($"Stack Pop : {stack.Pop()}");
            Console.WriteLine($"Stack Pop : {stack.Pop()}");
            Console.WriteLine($"Stack Pop : {stack.Pop()}");
        }
    }
}