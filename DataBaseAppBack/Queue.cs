namespace DataBaseAppBack
{
    class QueueItem
    {
        public Task<Task<string>> t;
        public int priority;

        public QueueItem(Task<Task<string>> t, int priority)
        {
            this.t = t;
            this.priority = priority;
        }
    }

    static class Queue
    {
       public static List<QueueItem> queue = new List<QueueItem>();

       public static Task<Task<string>> AddItem(Task<Task<string>> t, int priority)
       {
            queue.Add(new QueueItem(t, priority));
            return t;
       }

       public static void Resolve()
       {
           queue.Sort((x,y) => x.priority > y.priority ? 1 : -1);
           foreach(var item in queue)
           {
               item.t.Start();
               Thread.Sleep(item.priority * 1000);
           }
           queue.Clear();
       }
    }
}
