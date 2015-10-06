using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPriorityQueue
{
    /// <summary>
    /// class  queue
    /// </summary>
    /// <typeparam name="Type">type of elements</typeparam>
    public class MyQueue<TypeElements>
    {
        /// <summary>
        /// queue of elements
        /// </summary>
        private List<TypeElements> queue;

        /// <summary>
        ///  default constructor
        /// </summary>
        public MyQueue()
        {
            this.queue = new List<TypeElements>();
        }

        /// <summary>
        /// constructor with parameter
        /// </summary>
        /// <param name="someQueue">list elements</param>
        public MyQueue(List<TypeElements> someQueue)
        {
            this.queue = new List<TypeElements>(someQueue);
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="someQueue">some queue</param>
        public MyQueue(MyQueue<TypeElements> someQueue)
        {
            this.queue = new List<TypeElements>(someQueue.queue);
        }

        /// <summary>
        /// add element to queue
        /// </summary>
        /// <param name="newElement">element to add</param>
        public void Push(TypeElements element)
        {
            this.queue.Add(element);
        }

        /// <summary>
        /// get element from head of queue
        /// </summary>
        /// <returns>firs element</returns>
        public TypeElements Top()
        {
            if (this.queue.Count != 0)
            {
                return this.queue[0];
            }
            else
            {
                throw new IndexOutOfRangeException("Queue is empty!");
            }
        }

        /// <summary>
        /// delete element from head of queue
        /// </summary>
        public void Pop()
        {
            if (this.queue.Count != 0)
            {
                this.queue.RemoveAt(0);
            }
            else
            {
                throw new IndexOutOfRangeException("Queue is empty!");
            }
        }

        /// <summary>
        /// get size of queue
        /// </summary>
        /// <returns>return size of queue</returns>
        public int Size()
        {
            return this.queue.Count;
        }
    }

    public class PriorityQueue<TypeElements>
    {
        private List<KeyValuePair<int, MyQueue<TypeElements>>> priorityQueue;

        /// <summary>
        /// default constructor
        /// </summary>
        public PriorityQueue()
        {
            this.priorityQueue = new List<KeyValuePair<int, MyQueue<TypeElements>>>();
        }

        /// <summary>
        /// constructor with parameter
        /// </summary>
        /// <param name="somePriorityQueue">some list of pairs: priority and queue</param>
        public PriorityQueue(List<KeyValuePair<int, MyQueue<TypeElements>>> somePriorityQueue)
        {
            this.priorityQueue = new List<KeyValuePair<int, MyQueue<TypeElements>>>(somePriorityQueue);
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="somePriorityQueue">some priority queue</param>
        public PriorityQueue(PriorityQueue<TypeElements> somePriorityQueue)
        {
            this.priorityQueue = new List<KeyValuePair<int, MyQueue<TypeElements>>>(somePriorityQueue.priorityQueue);
        }

        /// <summary>
        /// add element to priority queue
        /// </summary>
        /// <param name="priority">priority of element</param>
        /// <param name="element">element</param>
        public void Push(int priority, TypeElements element)
        {
            if (this.priorityQueue.Count == 0)
            {
                MyQueue<TypeElements> queue = new MyQueue<TypeElements>();
                queue.Push(element);
                this.priorityQueue.Add(new KeyValuePair<int, MyQueue<TypeElements>>(priority, queue));
            }
            else
            {
                bool checkAdd = false;
                int i = this.priorityQueue.Count - 1;
                while(!checkAdd && i >= 0)
                {
                    if (priority == this.priorityQueue[i].Key)
                    {
                        this.priorityQueue[i].Value.Push(element);
                        checkAdd = true;
                    }
                    else
                    {
                        if (priority > this.priorityQueue[i].Key)
                        {
                            MyQueue<TypeElements> queue = new MyQueue<TypeElements>();
                            queue.Push(element);
                            this.priorityQueue.Insert(i + 1, new KeyValuePair<int, MyQueue<TypeElements>>(priority, queue));
                            checkAdd = true;
                        }
                    }
                    i--;
                }
                if (!checkAdd && i == -1)
                {
                    MyQueue<TypeElements> queue = new MyQueue<TypeElements>();
                    queue.Push(element);
                    this.priorityQueue.Insert(0, new KeyValuePair<int, MyQueue<TypeElements>>(priority, queue));
                }
            }
        }

        /// <summary>
        /// get element from head of queue
        /// </summary>
        /// <returns>first element of queue</returns>
        public TypeElements Top()
        {
            if (this.priorityQueue.Count == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty!");
            }
            else
            {
                return this.priorityQueue[0].Value.Top();
            }
        }

        /// <summary>
        /// delete element from head of priority queue
        /// </summary>
        public void Pop()
        {
            if (this.priorityQueue.Count == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty!");
            }
            else
            {
                this.priorityQueue[0].Value.Pop();
                if (this.priorityQueue[0].Value.Size() == 0)
                {
                    this.priorityQueue.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// get size of queue
        /// </summary>
        /// <returns>return size of queue</returns>
        public int Size()
        {
            int size = 0;
            for (int i = 0; i < this.priorityQueue.Count; i++)
            {
                size += this.priorityQueue[i].Value.Size();
            }
            return size;
        }
    }
}
